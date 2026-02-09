using System;
using Inspa.abst;
using Inspa.Models;
namespace Inspa.Impo;

public class Stream : Paths, IStream
{

    //geting the user appdata/local destination
    private readonly static string pathNeed = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    static readonly string riotPath = Path.Combine(pathNeed, Rio);

    readonly string lolPath = Path.Combine(riotPath, LolCache);

    readonly string lolPath1 = Path.Combine(riotPath, LolLog);

    readonly string riotClientPath = Path.Combine(riotPath, RiotCache);

    readonly string riotClientPath1 = Path.Combine(riotPath, RiotLog);

    public async Task GetLol()
    {
        if (Directory.Exists(lolPath) || Directory.Exists(lolPath1))
        {
            string[] cacheFiles = Directory.GetFiles(lolPath); // getting all files in cache folder
            string[] logFiles = Directory.GetFiles(lolPath1); //getting all files in log folder
            string[] allfiles = [.. cacheFiles, .. logFiles];

            string[] cachFolders = Directory.GetDirectories(lolPath); // getting all folders in cache folder
            string[] logFolders = Directory.GetDirectories(lolPath1);
            string[] allFolders = [.. cachFolders, .. logFolders];


            foreach (var fi in allfiles)
            {
                try { await Task.Run(() => File.Delete(fi)); }
                catch (IOException)
                {
                    //skip file in use if lol open
                }
            }
            foreach (var fo in allFolders)
            {
                try
                {
                    await Task.Run(() => Directory.Delete(fo, true));
                }
                catch (IOException)
                { }
            }

        }
        else
        {
            Console.WriteLine("No lol folder found");
        }
    }

    public async Task GetRiot()
    {
        if (Directory.Exists(riotClientPath) || Directory.Exists(riotClientPath1))
        {
            string[] cacheFiles = Directory.GetFiles(riotClientPath); // getting all files in cache folder
            string[] logFiles = Directory.GetFiles(riotClientPath1); //getting all files in log folder
            string[] allfiles = [.. cacheFiles, .. logFiles];

            string[] cachFolders = Directory.GetDirectories(riotClientPath); // getting all folders in cache folder
            string[] logFolders = Directory.GetDirectories(riotClientPath1);
            string[] allFolders = [.. cachFolders, .. logFolders];

            foreach (var fi in allfiles)
            {
                try { await Task.Run(() => File.Delete(fi)); }
                catch (IOException)
                { }
            }
            foreach (var fo in allFolders)
            {
                try
                {
                    await Task.Run(() => Directory.Delete(fo, true));
                }
                catch (IOException)
                { }
            }

        }
        else
        {
            Console.WriteLine("No riot client folder found");
        }
    }
}