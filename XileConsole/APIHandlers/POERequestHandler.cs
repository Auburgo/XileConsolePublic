using System.Net;
using Newtonsoft.Json;
using XileConsole.InventoryData;

static class POERequestHandler
{
    public static POEItems SendInventoryRequest()
    {
        string re = "";
        if (!File.Exists("Resources/inv.txt"))
        {
            string file = File.ReadAllText("Resources/userData.txt");
            UserData userData = JsonConvert.DeserializeObject<UserData>(file);

            Cookie cookie = new Cookie("POESESSID", userData.poeSessId, "/", ".pathofexile.com");

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://pathofexile.com/character-window/get-items?league="+userData.leagueName+"&accountName="+userData.poeAccountName+"&character="+userData.poeCharacterName);

            webRequest.CookieContainer = new CookieContainer();
            webRequest.CookieContainer.Add(cookie);
            WebResponse response = webRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader responseStreamReader = new StreamReader(responseStream);
            re = responseStreamReader.ReadToEnd();

            File.WriteAllText("Resources/inv.txt", Util.JsonPrettify(re));
        }
        else
        {
            re = File.ReadAllText("Resources/inv.txt");
        }
        POEItems items = JsonConvert.DeserializeObject<POEItems>(re);
        return items;
    }
}


