using Application.Contracts;

namespace Common
{
    public class PriceCalculator : IPriceCalculator
    {
        /// <summary>
        /// todo settings
        /// </summary>
        const double PricePerCharacter = 0.01;

        public double CalculatePrice(int contentLength) => contentLength * PricePerCharacter;
    }
}
