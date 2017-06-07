
using System.Collections.Generic;
using System.Drawing;

namespace PathFinder.Map
{
    public class SolutionWriter
    {
        private Maze maze;

        public Color PathColor = Color.Maroon;
        public Color WallColor = Color.RoyalBlue;
        public Color BackgroundColor = Color.White;

        public SolutionWriter(Maze maze)
        {
            this.maze = maze;
        }

        public void WriteNextTo(string originalFilePath, List<Point> path)
        {
            var extensionIndex = originalFilePath.LastIndexOf('.');
            var filePath = originalFilePath.Insert(extensionIndex - 1, "_solved");

            Write(filePath, path);
        }

        public void Write(string filePath, List<Point> path)
        {
            var image = new Bitmap(maze.Width, maze.Heigh);

            // Write the maze
            foreach (var row in maze.Rows)
            {
                foreach (var point in row)
                {
                    image.SetPixel(point.X, point.Y, point.IsWall ? WallColor : BackgroundColor);
                }
            }

            // Write the solution
            foreach (var point in path)
            {
                image.SetPixel(point.X, point.Y, PathColor);
            }            

            image.Save(filePath);
        }
    }
}
