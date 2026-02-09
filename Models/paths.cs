
namespace Inspa.Models;

public class Paths
{
    private static string  rio = "Riot Games";
    public static string Rio
    {
        get
        {
            return rio;
        }
        set
        {
            if (value != rio)
            {
                throw new Exception("Invalid value");
            }
            rio = value;
        }
    }

    private static string lolCache = "League of Legends/Cache";

    private static string lolLog = "League of Legends/Logs";

    private static string riotCache = "Riot Client/Cache";

    private static string riotLog = "Riot Client/Logs";
    public static string LolCache
    {
        get
        {
            return lolCache;
        }
        set
        {
            if (value != lolCache)
            {
                throw new Exception("Invalid value");
            }
            lolCache = value;
        }
    }
    public static string LolLog
    {
        get
        {
            return lolLog;
        }
        set
        {
            if (value != lolLog)
            {
                throw new Exception("Invalid value");
            }
            lolLog = value;
        }
    }
    public static string RiotCache
    {
        get
        {
            return riotCache;
        }
        set
        {
            if (value != riotCache)
            {
                throw new Exception("Invalid value");
            }
            riotCache = value;
        }
    }

    public static string RiotLog
    {
        get
        {
            return riotLog;
        }
        set
        {
            if (value != riotLog)
            {
                throw new Exception("Invalid value");
            }
            riotLog = value;
        }
    }
}