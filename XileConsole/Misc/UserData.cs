using System.Drawing;

public class UserData
{
    public string poeSessId;
    public string poeAccountName;
    public string poeCharacterName;
    public string leagueName;
    public string clientTxt;
    public Terminal.Gui.Color foregroundColor;
    public Terminal.Gui.Color backgroundColor;

    public UserData(string poeSessId, string poeAccountName, string poeCharacterName, string leagueName, string clientTxt, Terminal.Gui.Color backgroundColor, Terminal.Gui.Color foregroundColor)
    {
        this.poeSessId = poeSessId;
        this.poeAccountName = poeAccountName;
        this.poeCharacterName = poeCharacterName;
        this.leagueName = leagueName;
        this.clientTxt = clientTxt;
        this.backgroundColor = backgroundColor;
        this.foregroundColor = foregroundColor;
    }
}


