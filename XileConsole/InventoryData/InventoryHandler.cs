using XileConsole.InventoryData;

public class InventoryHandler
{
    public Inventory inventory;
    POEItems items;

    public InventoryHandler(POEItems items)
    {
        inventory = new Inventory();
        this.items = items;
        ConstructInventory();
    }

    public void PrintInventory()
    {
        Console.WriteLine(inventory.ToString());
    }

    public float GetInventoryValueInChaos()
    {
        return inventory.Sum();
    }

    public float GetInventoryValueInDivine()
    {
        return inventory.Sum() / inventory.divinePrice;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void ConstructInventory()
    {

        //Filter inventory to currency items (also includes essences, fossils etc.)
        List<POEItem> currencyInInventory = items.items.Where(x => x.frameType == 5).ToList();
        List<POEItem> fragmentsInInventory = items.items.Where(x => x.frameType == 0).ToList();
        List<POEItem> uniquesInInventory = items.items.Where(x => x.frameType == 3).ToList();
        List<POEItem> MiscInInventory = items.items.Where(x => x.frameType != 0 && x.frameType != 5 && x.frameType != 3).ToList();

      
        // -------------------------------

        //Handle chaos orbs seperately
        List<POEItem?> chaosOrbs = currencyInInventory.Where(x => x.baseType.ToLower() == "chaos orb").ToList();

        if (chaosOrbs.Count > 0)
        {
            foreach (var item in chaosOrbs)
            {
                inventory.Add(new CustomItem(item.baseType, ItemType.ChaosOrb, item.stackSize, new Price(new NinjaCurrencyItem(item.baseType, item.baseType, 1))));
            }
        }

        //Remove chaos orbs
        currencyInInventory = currencyInInventory.Where(x => x.baseType.ToLower() != "chaos orb").ToList();

        foreach (var item in currencyInInventory)
        {
            //Set default price at -99
            Price price = new Price(new NinjaCurrencyItem(item.baseType, item.baseType, Constants.DEFAULT_PRICE));
            CustomItem ci = new CustomItem(item.baseType, ItemType.Currency, item.stackSize, price);
            inventory.Add(ci);
        }

        // -------------------------------


        foreach (var item in fragmentsInInventory)
        {
            inventory.Add(new CustomItem(item.baseType, ItemType.Fragment, 1, new Price(new NinjaBaseItem(item.name, Constants.DEFAULT_PRICE))));
        }

        foreach (var item in uniquesInInventory)
        {
            if (item.name != "")
            {
                inventory.Add(new CustomItem(item.name, ItemType.UniqueItem, 1, new Price(new NinjaBaseItem(item.name, Constants.DEFAULT_PRICE))));
            }
            else
            {
                inventory.Add(new CustomItem(item.baseType, ItemType.UniqueItem, 1, new Price(new NinjaBaseItem(item.name, Constants.DEFAULT_PRICE))));
            }
            
        }

        foreach (var item in MiscInInventory)
        {
            inventory.Add(new CustomItem(item.baseType, ItemType.Default, 1, new Price(new NinjaBaseItem(item.name, Constants.DEFAULT_PRICE))));
        }

        // -------------------------------

        inventory.AssignTypes();
    }
}


