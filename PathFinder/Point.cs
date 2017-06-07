namespace PathFinder
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEntrance { get; set; }
        public bool IsWall { get; set; }

        public override string ToString()
        {
            return IsEntrance ? "o"
                : IsWall ? "#"
                : "x";
        }
    }
}
