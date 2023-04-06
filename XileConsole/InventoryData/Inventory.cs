using XileConsole.InventoryData;

public class Inventory
{
    public List<CustomItem> customItems;
    public float divinePrice = -1;

    //a is old inventory, b is new inventory
    public static Inventory operator -(Inventory a, Inventory b)
    {
        Inventory newInv = new Inventory();
        foreach (CustomItem customItem in a.customItems)
        {
            if(b.customItems.Contains(customItem))
            {
                var value = b.customItems.First(i => i.Equals(customItem));
                int newItemSize = customItem.stackSize - value.stackSize;

                if (newItemSize <= 0) continue;

                newInv.Add(new CustomItem(customItem.name, customItem.ItemType, newItemSize, customItem.price));
            }
            else
            {
                newInv.Add(customItem);
            }
        }

        return newInv;
    }

    public static Inventory operator +(Inventory a, Inventory b)
    {
        Inventory newInv = new Inventory();
        foreach (CustomItem customItem in b.customItems)
        {
            newInv.Add(customItem);            
        }
        foreach (CustomItem customItem in a.customItems)
        {
            newInv.Add(customItem);
        }

        return newInv;
    }



    public IEnumerator<CustomItem> GetEnumerator()
    {
        return customItems.GetEnumerator();
    }

    public Inventory()
    {
        customItems = new List<CustomItem>();
        NinjaRequestHandler ninjaRequestHandler = new NinjaRequestHandler(Constants.LEAGUENAME);
        NinjaCurrencyItem dP = ninjaRequestHandler.SendNinjaRequest<NinjaCurrencyItem, NinjaCurrencyItems>("divine orb", Util.GetLink(ItemType.Currency, Constants.LEAGUENAME), ItemType.Currency.ToString());
        this.divinePrice = dP.chaosEquivalent;
    }

    public Inventory(Inventory i)
    {
        customItems = new List<CustomItem>();
        foreach (CustomItem customItem in i.customItems)
        {
            customItems.Add(customItem);
        }
        if(i.divinePrice == -1)
        {
            NinjaRequestHandler ninjaRequestHandler = new NinjaRequestHandler(Constants.LEAGUENAME);
            NinjaCurrencyItem dP = ninjaRequestHandler.SendNinjaRequest<NinjaCurrencyItem, NinjaCurrencyItems>("divine orb", Util.GetLink(ItemType.Currency, Constants.LEAGUENAME), ItemType.Currency.ToString());
            this.divinePrice = dP.chaosEquivalent;
        }

        this.divinePrice = i.divinePrice;
        
    }

    public void Add(CustomItem item)
    {
        item.name = item.name.ToLower();
        if(customItems.Contains(item))
        {
            var value = customItems.First(i => i.Equals(item));
            value.stackSize += item.stackSize;
        }
        else
        {
            customItems.Add(item);
        }
        
    }

    public float Sum()
    {
        return customItems.Aggregate(0f, (sum, next) => sum + next.GetTotalPriceInChaos());
    }

    public override string ToString()
    {
        return string.Join("\n", customItems.Select(x => x.ToString()));
    }

    public void AssignTypes()
    {
        foreach (var item in customItems)
        {
            if (item.name.Contains("resonator"))
            {
                item.ItemType = ItemType.Resonator;
            }

            if (item.name.Contains("delirium"))
            {
                item.ItemType = ItemType.DeliriumOrb;
            }

            if (item.name.Contains("essence"))
            {
                item.ItemType = ItemType.Essence;
            }

            if (item.name.Contains("oil"))
            {
                item.ItemType = ItemType.Oil;
            }

            if (item.name.Contains("fossil"))
            {
                item.ItemType = ItemType.Fossil;
            }

            if (item.name.Contains("scarab"))
            {
                item.ItemType = ItemType.Scarab;
            }

            if (item.name.Contains("invitation") || item.name.Contains("writ"))
            {
                item.ItemType = ItemType.Invitation;
            }

            if (item.name.Contains("splinter") || item.name.Contains("fragment") || item.name.Contains("mortal"))
            {
                item.ItemType = ItemType.Fragment;
            }

        }
    }

    public void UpdateDivinePrice(float divinePrice)
    {
        this.divinePrice = divinePrice;
    }
}


