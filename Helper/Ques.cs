
namespace Inspa.Helper;

internal class Ques
{
    public static string? GetQues(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }

    public static int GetQuesInt(string question)
    {
        Console.WriteLine(question);
        bool tru = int.TryParse(Console.ReadLine(), out int result);
        while (!tru)
        {
            Console.WriteLine("Invalid Input Retry : ");
            tru = int.TryParse(Console.ReadLine(), out result);
        }
        return result;
    }
}