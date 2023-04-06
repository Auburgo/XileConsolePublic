using Newtonsoft.Json;
using ReactiveExample;
using ReactiveUI;
using System.Reactive.Concurrency;
using Terminal.Gui;
using XileConsole;
using XileConsole.Misc;

public class Program
{
    static void Main(string[] args) 
    {

        Logger.Log("--------------------- XileConsole start ---------------------");

        if (!Directory.Exists("Resources"))
        {
            Directory.CreateDirectory("Resources");
        }

        
        Application.Init();
        RxApp.MainThreadScheduler = TerminalScheduler.Default;
        RxApp.TaskpoolScheduler = TaskPoolScheduler.Default;


        if (File.Exists("Resources/userData.txt"))
        {
            string file = File.ReadAllText("Resources/userData.txt");
            UserData userData = JsonConvert.DeserializeObject<UserData>(file);
            Colors.Base.Normal = Application.Driver.MakeAttribute(userData.foregroundColor, userData.backgroundColor);
        }
        else
        {
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Cyan, Color.Black);
        }
        

        try
        {
            Application.Run(new MainMenuView());
        }



        catch (Exception e)
        {
            File.WriteAllText("errorLog.txt", e.Message + "\n" + e.InnerException + "\n" + e.Source + "\n" + e.StackTrace + "\n" + e.Data);
            MessageBox.Query("Error", e.Message, "Ok");
            Environment.Exit(0);

        }

        finally
        {
            Application.Shutdown();
        }
    }

    
}




