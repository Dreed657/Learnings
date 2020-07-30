namespace Models
{
    public class RealEstatePropertyTag
    {
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public int PropertyId { get; set; }

        public virtual RealEstateProperty Property { get; set; }
    }
}
