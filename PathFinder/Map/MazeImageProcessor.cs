using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PathFinder.Map
{
    public class MazeImageProcessor
    {
        private readonly Bitmap image;
        public Color backgroundColor;
        public Color wallColor;
        public int pointSize;
        
        public MazeImageProcessor(Bitmap image)
        {
            if (image.Size.Height < 5 || image.Size.Width < 5)
                throw new Exception("Image too small");

            this.image = image;
        }

        public Maze Read()
        {
            FindColors();
            FindPointSize();

            return FindWalls();
        }

        public void FindColors()
        {
            // On the slight off chance of an entrance starting on a corner, take the most common corner color
            wallColor = new[]
            {
                image.GetPixel(0, 0),
                image.GetPixel(0, 0)
            }.GroupBy(c=> c)
            .OrderByDescending(c=> c.Count())
            .First().First();

            var col = 1;
            var row = 1;

            while (backgroundColor == Color.Empty && backgroundColor != wallColor)
            {
                backgroundColor = image.GetPixel(row, col);
                
                // Move to the next cell
                if (col >= image.Size.Width)
                {
                    col = 0;
                    row += 1;
                } else
                    col++;
            }
        }

        public Maze FindWalls()
        {
            var result = new Maze
            {
                Heigh = image.Size.Height / pointSize,
                Width = image.Size.Width / pointSize
            };

            for (var rowIndex = 0; rowIndex < result.Heigh; rowIndex++)
            {
                var row = new List<Point>();

                for (var colIndex = 0; colIndex < result.Width; colIndex++)
                {
                    var isWall = image.GetPixel(colIndex, rowIndex) == wallColor;
                    row.Add(
                        new Point
                        {
                            X = colIndex,
                            Y = rowIndex,
                            IsWall = isWall,
                            IsEntrance = !isWall 
                                        && (rowIndex == 0 
                                            || rowIndex == result.Heigh-1
                                            || colIndex == 0 
                                            || colIndex == result.Width -1)
                        }
                    );
                }

                result.Rows.Add(row);
            }

            return result;
        }

        public void FindPointSize()
        {
            // Find shortest difference between colors

            pointSize = 1; // TODO: support larger point sizes
        }
    }
}
