using System.Diagnostics;
using XileConsole.Events;
using XileConsole.InventoryData;
using XileConsole.MapData;
using XileConsole.Misc;

public class DataHandler
{
    bool lastVisitedPlaceWasHideout = false;
    bool lastPlaceVisitedWasTownOrActArea = false;
    List<Inventory> inventories = new List<Inventory>();
    MapInfo? currentMap;

    bool firstTimeInNewMap = false;

    public InventoryHandler inventoryHandler;
    private static bool hasInitialized = false;
    private static bool hasSubscribed = false;

    private static readonly DataHandler internalInstance = new DataHandler();
    static DataHandler() { }
    private DataHandler(){ }

    public static DataHandler Instance { get { return internalInstance; } }

    public void OnEnterHideout()
    {
        if(lastVisitedPlaceWasHideout || lastPlaceVisitedWasTownOrActArea)
        {
             return;
        }

        lastVisitedPlaceWasHideout = true;
        lastPlaceVisitedWasTownOrActArea = false;
        FetchInventory();
        var inventory = inventoryHandler.GetInventory();

        inventories.Add(new Inventory(inventory));
    }

    public void OnEnterNewMap(MapInfo mapInfo)
    {
        Logger.Log("OnEnterNewMap method called");
        List<Inventory> mapLootInventories = new List<Inventory>();

        int crashFix = 0;

        if(inventories.Count % 2 != 0) 
        {
            Logger.Log("Something wrong happened");
            Logger.Log("Number of inventories: " + inventories.Count);
            crashFix = 1;
        }

        for(var i = 0; i < inventories.Count-crashFix; i+=2)
        {
            Inventory newInv = inventories[i + 1] - inventories[i];
            mapLootInventories.Add(newInv);
        }
        Logger.Log("Number of recorded inventories: "+inventories.Count);

        Inventory realMapLoot = new Inventory();

        foreach(var i in mapLootInventories)
        {
            realMapLoot += i;
        }

        mapInfo.inventory = realMapLoot;

        mapInfo.exitMapTimes = currentMap.exitMapTimes;
        mapInfo.enteredMapTimes = currentMap.enteredMapTimes;

        TimeSpan ts = new TimeSpan();

        if(mapInfo.exitMapTimes.Count > 0 && mapInfo.enteredMapTimes.Count > 0)
        {
            for (int i = 0; i < mapInfo.enteredMapTimes.Count; i++)
            {
                ts += mapInfo.exitMapTimes[i] - mapInfo.enteredMapTimes[i];
            }
        }
        else
        {
            if(mapInfo.enteredMapTimes.Count == 0)
            {
                
            }
            if (mapInfo.exitMapTimes.Count == 0)
            {
                Logger.Log("exitMapTimes.Count == 0");
            }

        }

        Logger.Log("enterMapTimes.Count = "+mapInfo.enteredMapTimes.Count);
        Logger.Log("exitMapTimes.Count = "+mapInfo.exitMapTimes.Count);



        mapInfo.timeInMap = ts;

        MapDataSerializer.Instance.AddMapInfo(mapInfo);
        MapDataSerializer.Instance.SaveMapInfos();
        Eventbus.Instance.Publish<OnMapFinishedEvent>(this, new OnMapFinishedEvent(mapInfo));
        
        Inventory lastInv = inventories.Last();
        inventories.Clear();
        //instance.inventories.Add(new Inventory(lastInv));
        lastVisitedPlaceWasHideout = false;
        lastPlaceVisitedWasTownOrActArea = false;
    }

    public void OnEnterMap() 
    {
        lastVisitedPlaceWasHideout = false;
        lastPlaceVisitedWasTownOrActArea = false;
        FetchInventory();
        var inventory = inventoryHandler.GetInventory();

        inventories.Add(new Inventory(inventory));
    }

    public void FetchInventory()
    {
        Logger.Log("Fetching inventory");
        if (File.Exists("Resources/inv.txt"))
        {
            File.Delete("Resources/inv.txt");
        }
        Init();
    }

    public void Init()
    {
        if (!hasSubscribed)
        {
            Eventbus.Instance.Suscribe<OnEnterHideoutEvent>((sender, e) =>
            {
                Logger.Log("Event: OnEnterHideOut");
                if(currentMap != null)
                {
                    if(!lastVisitedPlaceWasHideout && !lastPlaceVisitedWasTownOrActArea)
                    {
                        currentMap.exitMapTimes.Add(DateTime.Now);
                    }
                    Logger.Log("Exit time timestamp");
                }
                OnEnterHideout();
            });

            Eventbus.Instance.Suscribe<OnNewMapEnterEvent>((sender, e) =>
            {
                //instance.OnEnterNewMap(e.mi);
            });

            Eventbus.Instance.Suscribe<OnEnterMapEvent>((sender, e) =>
            {
                if(Constants.townNames.Contains(e.mapInfo.mapName) || Constants.actAreas.Contains(e.mapInfo.mapName))
                {
                    lastPlaceVisitedWasTownOrActArea = true;
                    Logger.Log("Entered town or act area");
                    return;
                }

                Logger.Log("Event: OnEnterMap: " + e.mapInfo.mapName);
                
                if (currentMap == null) 
                {
                    currentMap = e.mapInfo;
                    Logger.Log("Entering first map since launch");
                }
                
                if (e.mapInfo.Equals(currentMap))
                {
                    currentMap.enteredMapTimes.Add(DateTime.Now);
                    Logger.Log("Recognized old instance");
                    Logger.Log("Enter timestamp");
                }
                else
                {
                    OnEnterNewMap(currentMap);
                    currentMap = e.mapInfo;
                    currentMap.enteredMapTimes.Add(DateTime.Now);
                    Logger.Log("Setting new mapInfo");
                    Logger.Log("Enter timestamp");
                }

                OnEnterMap();

            });
            hasSubscribed = true;
        }

        hasInitialized = true;
        //Fetch inventory
        POEItems items = POERequestHandler.SendInventoryRequest();
        items.items = items.items.Where(x => x.inventoryId == "MainInventory").ToList();

        InventoryHandler invHandler = new InventoryHandler(items);
        NinjaRequestHandler ninjaRequestHandler = new NinjaRequestHandler(Constants.LEAGUENAME);
        ninjaRequestHandler.FetchNinjaCurrency();
        foreach (var item in invHandler.GetInventory())
        {
            Price price = ninjaRequestHandler.SendRequest(item);
            if (price != null)
            {
                item.price = price;
            }
        }

        inventoryHandler = invHandler;
        NinjaCurrencyItem divinePrice = ninjaRequestHandler.SendNinjaRequest<NinjaCurrencyItem, NinjaCurrencyItems>("divine orb", Util.GetLink(ItemType.Currency, Constants.LEAGUENAME), ItemType.Currency.ToString());
        inventoryHandler.GetInventory().UpdateDivinePrice(divinePrice.chaosEquivalent);
    }
}


