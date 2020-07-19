using System.IO;
using System.Reflection;

namespace desafio_dell
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "entry.txt");
            RomanConverter r = new RomanConverter();
            TextHandler th = new TextHandler();
            th.NotationsReader(path);
            th.MineralsReader(path);
            th.QueriesReader(path);
        }
    }
}
