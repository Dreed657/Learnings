namespace PointinRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Point topLeft { get; set; }
        public Point bottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool insideXaxies = this.topLeft.x <= point.x && this.bottomRight.x >= point.x;
            bool insideYaxies = this.topLeft.y <= point.y && this.bottomRight.y >= point.y;

            return insideXaxies && insideYaxies;
        }
    }
}
