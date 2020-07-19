namespace desafio_dell
{
    public class Mineral {
        public int Amount;
        public string Name;
        public int Credits;

        public void GetValues()
        {
            System.Console.Write($"Amount: {Amount} ");
            System.Console.Write($"Name: {Name} ");
            System.Console.Write($"Credits: {Credits}\n");
        }
    }
}