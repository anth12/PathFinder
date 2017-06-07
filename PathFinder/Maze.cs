using System.Collections.Generic;
using System.Text;

namespace PathFinder
{
    public class Maze
    {
        public int Heigh { get; set; }
        public int Width { get; set; }
        public List<List<Point>> Rows { get; set; } = new List<List<Point>>();

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var row in Rows)
            {
                foreach (var point in row)
                {
                    result.Append(point.ToString());
                }

                if (Rows.IndexOf(row) < Rows.Count - 1)
                    result.AppendLine();
            }

            return result.ToString();
        }
    }
}