using Inspa.Helper;
using Inspa.Impo;
namespace Inspa;

public class Program : Init
{
    static readonly Impo.Stream lol = new();

    //gets likely name of user from pc
    private readonly static string propreiter = Environment.UserName;

    public static void Main(string[] args)
    {
        Ques.GetQues($"--------------------------------Welcome {propreiter}, Choose an Option : -------------------------------");

        bool prog = true;

        while (prog)
        {
            int begin = Chose();

            switch (begin)
            {
                case 1:
                     lol.GetLol();
                     lol.GetRiot();
                    Console.Write("Cleaning Done.");
                    break;
                case 2:
                    Open();
                    Console.Write("Openning Game....");
                    return;
                default:
                    prog = false;
                    break;
            }
        }
        Console.WriteLine("Closing...");
    }
}
