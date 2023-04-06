using System.Net;
using Newtonsoft.Json;
using XileConsole.InventoryData;

class NinjaRequestHandler
{
    string leaguename;
    public NinjaRequestHandler(string leaguename)
    {
        this.leaguename = leaguename;
    }

    public void DeleteCache()
    {
       
        DirectoryInfo d = new DirectoryInfo("Resources");
        List<string> excludedFiles = new List<string>()
        {
            "inv.txt",
            "userData.txt"
        };

        foreach (var file in d.GetFiles("*.txt"))
        {
            if (file.Name.Contains("inv") || file.Name.Contains("userData")) continue;
            file.Delete();
            
        }
    }

    public void FetchNinjaCurrency()
    {
        SendNinjaRequest<NinjaCurrencyItem, NinjaCurrencyItems>("", Util.GetLink(ItemType.Currency, leaguename), ItemType.Currency.ToString());
    }

    public Price SendRequest(CustomItem item)
    {
        
        switch (item.ItemType)
        {
            case ItemType.Fragment:
            case ItemType.Currency:
                NinjaCurrencyItem nci = SendNinjaRequest<NinjaCurrencyItem, NinjaCurrencyItems>(item.name, Util.GetLink(item.ItemType, leaguename), item.ItemType.ToString());
                if (nci == null)
                {
                    return item.price;
                }
                return new Price(nci);
            case ItemType.Resonator:
            case ItemType.Essence:
            case ItemType.Oil:
            case ItemType.Fossil:
            case ItemType.Scarab:
            case ItemType.Invitation:
            case ItemType.DeliriumOrb:
                NinjaBaseItem nbi = SendNinjaRequest<NinjaBaseItem, NinjaBaseItems>(item.name, Util.GetLink(item.ItemType, leaguename), item.ItemType.ToString());
                if (nbi == null)
                {
                    return item.price;
                }
                return new Price(nbi);
            case ItemType.UniqueItem:
                FetchAllUniquePrices();
                NinjaBaseItem unique = FetchPriceForItemInFile(item.name, "allUniques");
                return new Price(unique);
            case ItemType.Default:
                GenerateCombinedList();
                NinjaBaseItem bi = FetchPriceForItemInFile(item.name, "allItems");
                if (bi == null)
                {
                    return item.price;
                }
                return new Price(bi);
            default:
                return item.price;
        }
    }

    private NinjaBaseItem FetchPriceForItemInFile(string itemName, string filename)
    {
        string file = File.ReadAllText("Resources/" + filename + ".txt");

        NinjaBaseItems items = JsonConvert.DeserializeObject<NinjaBaseItems>(file);
        NinjaBaseItem price = items.GetLines().Where(x => x.GetName().ToLower() == itemName.ToLower()).FirstOrDefault();

        if (price == null)
        {
            Console.WriteLine("Could not find price for: " + itemName + " in " + filename + ".txt");
            price = new NinjaBaseItem(itemName, 0);
        }

        return price;
    }

    private void FetchAllUniquePrices()
    {
        NinjaBaseItems uniqueMaps = GetNinjaItemList(Util.GetLink(ItemType.UniqueMap, leaguename), "uniqueMaps");
        NinjaBaseItems uniqueJewels = GetNinjaItemList(Util.GetLink(ItemType.UniqueJewel, leaguename), "uniqueJewels");
        NinjaBaseItems uniqueFlasks = GetNinjaItemList(Util.GetLink(ItemType.UniqueFlask, leaguename), "uniqueFlasks");
        NinjaBaseItems uniqueWeapons = GetNinjaItemList(Util.GetLink(ItemType.UniqueWeapon, leaguename), "uniqueWeapons");
        NinjaBaseItems uniqueArmours = GetNinjaItemList(Util.GetLink(ItemType.UniqueArmour, leaguename), "uniqueArmours");
        NinjaBaseItems uniqueAccessories = GetNinjaItemList(Util.GetLink(ItemType.UniqueAccessory, leaguename), "uniqueAccessories");

        NinjaBaseItems allUniques = new NinjaBaseItems();
        allUniques.lines.AddRange(uniqueMaps.lines);
        allUniques.lines.AddRange(uniqueJewels.lines);
        allUniques.lines.AddRange(uniqueFlasks.lines);
        allUniques.lines.AddRange(uniqueWeapons.lines);
        allUniques.lines.AddRange(uniqueArmours.lines);
        allUniques.lines.AddRange(uniqueAccessories.lines);

        string res = JsonConvert.SerializeObject(allUniques, Formatting.Indented);
        File.WriteAllText("Resources/allUniques.txt", res);
    }

    private void GenerateCombinedList()
    {
        //does not include currency and fragments
        NinjaBaseItems allItems = new NinjaBaseItems();

        IEnumerable<ItemType> itemTypesEnum = Util.GetValues<ItemType>();

        List<ItemType> excludedTypes = new List<ItemType>()
        {
            ItemType.Currency,
            ItemType.Fragment,
            ItemType.UniqueItem,
            ItemType.ChaosOrb,
            ItemType.Default
        };

        foreach (var i in itemTypesEnum)
        {
            if (excludedTypes.Contains(i)) continue;

            NinjaBaseItems content = GetNinjaItemList(Util.GetLink(i, leaguename), i.ToString());
            allItems.lines.AddRange(content.lines);
        }

        string res = JsonConvert.SerializeObject(allItems, Formatting.Indented);
        File.WriteAllText("Resources/allItems.txt", res);
    }



    public T SendNinjaRequest<T, V>(string item, string link, string filename) where V : HasLines<T> where T : HasName
    {
        string line = "";
        if (!File.Exists("Resources/" + filename + ".txt"))
        {
            WebRequest wr = WebRequest.Create(link);
            WebResponse webResponse = wr.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            using StreamReader sr = new StreamReader(stream);
            line = sr.ReadToEnd();
            File.WriteAllText("Resources/" + filename + ".txt", Util.JsonPrettify(line));
        }
        else
        {
            line = File.ReadAllText("Resources/" + filename + ".txt");
        }

        V i = JsonConvert.DeserializeObject<V>(line);


        T c = i.GetLines().Where(x => x.GetName().ToLower() == item.ToLower()).FirstOrDefault();

        return c;
    }

    NinjaBaseItems GetNinjaItemList(string link, string filename)
    {
        string line = "";
        if (!File.Exists("Resources/" + filename + ".txt"))
        {
            WebRequest wr = WebRequest.Create(link);
            WebResponse webResponse = wr.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            using StreamReader sr = new StreamReader(stream);
            line = sr.ReadToEnd();
            File.WriteAllText("Resources/" + filename + ".txt", Util.JsonPrettify(line));
        }
        else
        {
            line = File.ReadAllText("Resources/" + filename + ".txt");
        }

        NinjaBaseItems list = JsonConvert.DeserializeObject<NinjaBaseItems>(line);

        return list;
    }

}


