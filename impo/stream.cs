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

            //creating task list for all files and folders
            var alTask = new List<Task>();

            foreach (var fi in allFiles)
            {
                //adding running task to list
                alTask.Add(
                    Task.Run(() =>
                    {
                        try { File.Delete(fi); }
                        catch (IOException)
                        {
                            //skips files that are running 
                        }
                    })
                );
            }

            foreach (var fo in allFolders)
            {
                alTask.Add(
                    Task.Run(() =>
                    {
                        try { Directory.Delete(fo, true); }
                        catch (IOException)
                        {
                            //skips folder that are running 
                        }
                    })
                );
            }
            //invoking await for the whole list
            await Task.WhenAll(alTask);
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

            var alTask = new List<Task>();

            foreach (var fi in allfiles)
            {
                alTask.Add(
                    Task.Run(() =>
                    {
                        try { File.Delete(fi); }
                        catch (IOException)
                        { }
                    })
                );
            }
            foreach (var fo in allFolders)
            {
                alTask.Add(
                    Task.Run(() =>
                    {
                        try { Directory.Delete(fo, true); }
                        catch (IOException)
                        { }
                    })
                );
            }
            await Task.WhenAll(alTask);
        }
        else
        {
            Console.WriteLine("No riot client folder found");
        }
    }
}
