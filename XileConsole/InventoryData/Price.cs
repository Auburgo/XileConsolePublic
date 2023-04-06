using XileConsole.InventoryData;

public class Price
{
    public float chaos;
    public float divine;

    public Price(NinjaCurrencyItem currency)
    {
        chaos = currency.chaosEquivalent;
        divine = 0;
    }

    public Price(NinjaBaseItem nri)
    {
        chaos = nri.chaosValue;
        divine = 0;
    }

    public Price()
    {

    }

    public override string ToString()
    {
        return chaos.ToString();
    }
}


