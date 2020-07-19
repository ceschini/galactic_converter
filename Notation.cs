namespace desafio_dell
{
    public class Notation {
        public string Galactic;
        public string Roman;

        public Notation(string gal, string rom)
        {
            Galactic = gal;
            Roman = rom;
        }

        public override bool Equals(object obj)
        {
            Notation outraNotation = (Notation)obj;
            bool mesmoGalactic = Galactic == outraNotation.Galactic;
            bool mesmoRoman = Roman == outraNotation.Roman;
            return mesmoGalactic && mesmoRoman;
        }

        public override int GetHashCode()
        {
            return Galactic.Length;
        }
    }
}