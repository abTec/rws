namespace Application.Contracts
{
    public interface IPriceCalculator
    {
        double CalculatePrice(int contentLength);
    }
}
