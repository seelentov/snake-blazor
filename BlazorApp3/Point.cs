namespace BlazorApp3
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public override string ToString() => $"({X}, {Y})";

        public Point GetDir(Direction direction)
        {
            int newX = direction == Direction.left ? this.X - 1 :
                direction == Direction.right ? this.X + 1 :
                this.X;
            int newY = direction == Direction.up ? this.Y - 1 :
                direction == Direction.down ? this.Y + 1 :
                this.Y;

            return new Point(newX, newY);
        }

        public void Move(Direction direction)
        {
            int newX = direction == Direction.left ? this.X - 1 :
                direction == Direction.right ? this.X + 1 :
                this.X;
            int newY = direction == Direction.up ? this.Y - 1 :
                direction == Direction.down ? this.Y + 1 :
                this.Y;

            X = newX;
            Y = newY;
        }

        public Point Copy()
        {
            return new Point(X, Y);
        }
    }
}
