using System.Diagnostics;
using Inspa.Helper;
namespace Inspa.Impo;

public class Init
{
    enum ChoicesType
    {
        clean = 1,
        play
    }

    internal static int Chose()
    {
        int ret = Ques.GetQuesInt("\n1. Clean\n2. Play");
        return Enum.IsDefined(typeof(ChoicesType), ret) ? ret : -1;
    }
    internal static void Open()
    {
        try
        {
            string? gamePath = @"C:\GAMES\Riot Games\League of Legends\LeagueClient.exe";
            Process.Start(gamePath);
        }
        catch (Exception)
        {
            throw new Exception("Cannot find Lol location");
        }
    }
}