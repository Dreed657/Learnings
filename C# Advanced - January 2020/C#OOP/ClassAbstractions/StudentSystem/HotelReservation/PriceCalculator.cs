namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount = Discount.None)
        {
            decimal price = pricePerDay * days * (int)season;

            if (discount != Discount.None) price -= price * (int)discount / 100;
            
            return price;
        }
    }
}
