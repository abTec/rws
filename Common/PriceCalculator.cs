using Application.Contracts;

namespace Common
{
    public sealed class PriceCalculator : IPriceCalculator
    {
        /// <summary>
        /// todo settings
        /// </summary>
        const double PricePerCharacter = 0.01;

        public double CalculatePrice(int contentLength) => contentLength * PricePerCharacter;
    }
}
