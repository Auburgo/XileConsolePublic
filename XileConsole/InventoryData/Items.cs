using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XileConsole.InventoryData
{
    public class POEItems
    {
        public List<POEItem> items = new List<POEItem>();
    }

    public class POEItem
    {
        public string name;
        public string baseType;
        public int frameType;
        public string inventoryId;
        public int stackSize;

        public override string ToString()
        {
            return "POEItem - BaseType: " + baseType + ", FrameType: " + frameType + ", InventoryId: " + inventoryId + ", StackSize: " + stackSize + "\n";
        }
    }

    public class NinjaBaseItems : HasLines<NinjaBaseItem>
    {
        public List<NinjaBaseItem> lines = new List<NinjaBaseItem>();

        public List<NinjaBaseItem> GetLines()
        {
            return lines;
        }
    }

    public class NinjaBaseItem : HasName
    {
        public string name;
        public float chaosValue;

        public NinjaBaseItem(string name, float chaosValue)
        {
            this.name = name;
            this.chaosValue = chaosValue;
        }

        public override string ToString()
        {
            return name + "\nChaos: " + chaosValue;
        }

        public string GetName()
        {
            return name;
        }
    }

    public class NinjaCurrencyItems : HasLines<NinjaCurrencyItem>
    {
        public List<NinjaCurrencyItem> lines = new List<NinjaCurrencyItem>();

        public List<NinjaCurrencyItem> GetLines()
        {
            return lines;
        }
    }

    public class NinjaCurrencyItem : HasName
    {
        public string currencyTypeName;
        public float chaosEquivalent;

        public NinjaCurrencyItem(string name, string currencyTypeName, float chaosEquivalent)
        {
            this.currencyTypeName = currencyTypeName;
            this.chaosEquivalent = chaosEquivalent;
        }

        public override string ToString()
        {
            return currencyTypeName + "\n Chaos: " + chaosEquivalent;
        }

        public string GetName()
        {
            return currencyTypeName;
        }
    }
}
