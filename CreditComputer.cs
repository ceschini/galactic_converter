namespace desafio_dell
{
    public class CreditComputer
    {
        public int CalculateCredits(int queryAmount, int baseAmount, int baseCredits) {
            if (queryAmount == baseAmount) {
                return baseCredits;
            }
            return (queryAmount * baseCredits) / baseAmount;
        }
    }
}