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
            string[] allFiles = [ //get files from lol cache and log
                 ..Directory.GetFiles(lolPath),
                 ..Directory.GetFiles(lolPath1)];

            string[] allFolders = [ // gets folders from lol cache and log
                ..Directory.GetDirectories(lolPath),
                ..Directory.GetDirectories(lolPath1)];

            foreach (var fi in allFiles)
            {
                try { File.Delete(fi); }
                catch (IOException)
                {
                    //skips files that are running 
                }
            }

            foreach (var fo in allFolders)
            {
                try { Directory.Delete(fo, true); }
                catch (IOException)
                {
                    //skips folder that are running 
                }
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
            string[] allfiles = [.. Directory.GetFiles(riotClientPath), .. Directory.GetFiles(riotClientPath1)];

            string[] allFolders = [.. Directory.GetDirectories(riotClientPath), .. Directory.GetDirectories(riotClientPath1)];

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