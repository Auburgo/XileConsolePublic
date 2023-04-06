public class CustomItem
{
    public ItemType ItemType;
    public string name;
    public int stackSize;
    public Price price;

    public CustomItem(string name, ItemType itemType, int stackSize, Price price) //old currency item
    {
        this.name = name;
        this.stackSize = stackSize;
        this.price = price;
        this.ItemType = itemType;
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomItem item &&
               ItemType == item.ItemType &&
               name == item.name;
    }

    public float GetTotalPriceInChaos()
    {
        return price.chaos * stackSize;
    }

    public override string ToString()
    {
        return "Name: " + name + ", Stacksize: " + stackSize + ", Price: " + price.ToString();
    }

    
}


