using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XileConsole.MapData
{
    public sealed class MapDataSerializer
    {
        private static readonly MapDataSerializer instance = new MapDataSerializer();
        static MapDataSerializer() { } 
        private MapDataSerializer() { } 

        public static MapDataSerializer Instance { get { return instance; } }


        public MapInfoHolder mapInfoHolder;

        public bool LoadMapInfos()
        {
            if(!File.Exists("Resources/mapData.txt"))
            {
                return false;
            }
            string mapData = File.ReadAllText("Resources/mapData.txt");
            mapInfoHolder = JsonConvert.DeserializeObject<MapInfoHolder>(mapData);
            return true;
        }

        public void SaveMapInfos()
        {
            string mapInfos = JsonConvert.SerializeObject(mapInfoHolder);

            if(File.Exists("Resources/mapData.txt"))
            {
                File.Delete("Resources/mapData.txt");
            }

            File.WriteAllText("Resources/mapData.txt",mapInfos);
        }

        public void DeleteMapInfo(MapInfo mapInfo)
        {
            if(mapInfoHolder != null)
            {
                mapInfoHolder.MapInfos.Remove(mapInfo);
            }
        }

        public void AddMapInfo(MapInfo mapInfo)
        {
            if(mapInfoHolder == null)
            {
                mapInfoHolder = new MapInfoHolder();
            }

            mapInfoHolder.MapInfos.Add(mapInfo);
        }
    }
}
