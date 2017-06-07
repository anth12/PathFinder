﻿namespace PathFinder.Map
{
    public class Point
    {
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
