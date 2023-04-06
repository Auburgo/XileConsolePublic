using System.Globalization;

public class MapInfo
{
    public string instanceIP;
    public string mapName;
    
    public List<DateTime> enteredMapTimes;
    public List<DateTime> exitMapTimes;

    public TimeSpan timeInMap;
    public Inventory inventory;

    public MapInfo(string instanceIP, string mapName)
    {
        enteredMapTimes = new List<DateTime>();
        exitMapTimes = new List<DateTime>();

        this.instanceIP = instanceIP;
        this.mapName = mapName;
    }

    public bool Equals(MapInfo other)
    {
        if (other.instanceIP == this.instanceIP && mapName == other.mapName)
        {
            return true;
        }
        return false;
    }


    public MapInfo Clone()
    {
        MapInfo newMI = new MapInfo(this.instanceIP, this.mapName);
        newMI.enteredMapTimes = enteredMapTimes.Select(x => x).ToList();
        newMI.exitMapTimes = exitMapTimes.Select(x => x).ToList();
        newMI.timeInMap = timeInMap;
        newMI.inventory = inventory;
        return newMI;
    }
}


