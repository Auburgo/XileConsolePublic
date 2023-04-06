using Newtonsoft.Json;
using Terminal.Gui;
using XileConsole.Events;

public class MapIdentifier
{
    public List<MapInfo> mapInfos = new List<MapInfo>();

    public void Init()
    {
        if (File.Exists("Resources/userData.txt"))
        {
            string file = File.ReadAllText("Resources/userData.txt");
            UserData userData = JsonConvert.DeserializeObject<UserData>(file);

            new Thread(() =>
            {
                string logString = "";
                bool initialRead = false;

                using (var fs = new FileStream(userData.clientTxt + "\\Client.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                using (var reader = new StreamReader(fs))
                {
                    while (true)
                    {
                        var line = reader.ReadToEnd();
                        line = line.ToLower();
                        
                        

                        if (!String.IsNullOrWhiteSpace(line) && initialRead)
                        {
                            if (line.Contains("instance server at"))
                            {
                                string v = line.Substring(line.IndexOf("at") + 3);
                                v = v.Substring(0, v.IndexOf("\n") - 1);
                                //File.AppendAllText("log.txt",v + "\n");
                                logString += v + " - ";
                                mapInfos.Add(new MapInfo(v, ""));
                            }

                            if (line.Contains("have entered"))
                            {
                                if (!line.Contains("hideout"))
                                {
                                    string v = line.Substring(line.IndexOf("entered") + 8);
                                    v = v.Substring(0, v.IndexOf("\n") - 2);
                                    //File.AppendAllText("log.txt", v + "\n");
                                    logString += v + " - ";
                                    mapInfos[mapInfos.Count - 1].mapName = v;

                                    MapInfo mi = mapInfos[mapInfos.Count - 1].Clone();

                                    Application.MainLoop.Invoke(() =>
                                    {
                                        Eventbus.Instance.Publish<OnEnterMapEvent>(this, new OnEnterMapEvent(mi));
                                    });
                                }
                                else
                                {
                                    mapInfos.RemoveAt(mapInfos.Count - 1);
                                    logString = "";
                                    Application.MainLoop.Invoke(() =>
                                    {
                                        Eventbus.Instance.Publish<OnEnterHideoutEvent>(this, new OnEnterHideoutEvent());
                                    });
                                    continue;

                                }

                                if (mapInfos.Count > 1)
                                {
                                    if (mapInfos[mapInfos.Count - 1].Equals(mapInfos[mapInfos.Count - 2]))
                                    {
                                        //File.AppendAllText("log.txt", "Entered old map\n");
                                        logString += "Old map\n";
                                        //File.AppendAllText("log.txt", logString);
                                        logString = "";
                                    }
                                    else
                                    {
                                        //File.AppendAllText("log.txt", "Entered new map\n");
                                        logString += "New map\n";
                                        //File.AppendAllText("log.txt", logString);
                                        logString = "";

                                        MapInfo mi2 = mapInfos[mapInfos.Count - 2].Clone();

                                        Application.MainLoop.Invoke(() => 
                                        { 
                                            Eventbus.Instance.Publish<OnNewMapEnterEvent>(this, new OnNewMapEnterEvent(mi2)); 
                                        });
                                        
                                    }
                                }
                                else
                                {
                                    logString += "New map\n";
                                    //File.AppendAllText("log.txt", logString);
                                    logString = "";
                                }
                            }


                        }
                        if (line.Contains("to " + userData.poeCharacterName.ToLower() + ": end") && mapInfos.Count > 0)
                        {
                            Application.MainLoop.Invoke(() =>
                            {
                                Eventbus.Instance.Publish<OnEnterMapEvent>(this, new OnEnterMapEvent(new MapInfo("", "")));
                            });
                        }
                        Thread.Sleep(100);
                        initialRead = true;
                    }
                }
            }).Start();



        }
    }
}


