using System;
using System.Drawing;
using System.Linq;

namespace PathFinder.Map
{
    public class MapProcessor
    {
        private readonly Bitmap image;
        public Color backgroundColor;
        public Color wallColor;
        public int pointSize;
        
        public MapProcessor(Bitmap image)
        {
            if (image.Size.Height < 5 || image.Size.Width < 5)
                throw new Exception("Image too small");

            this.image = image;
        }

        public Maze Read()
        {
            FindColors();
            FindPointSize();



            return new Maze();
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

        public void FindWalls()
        {
            var col = 0;
            var row = 0;

            while (backgroundColor == Color.Empty && backgroundColor != wallColor)
            {
                backgroundColor = image.GetPixel(row, col);

                // Move to the next cell
                if (col >= image.Size.Width)
                {
                    col = 0;
                    row += 1;
                }
                else if(row >= image.Size.Height)
                {

                }
                else
                    col++;
            }
        }

        public void FindPointSize()
        {
            // Find shortest difference between colors

            pointSize = 1; // TODO: support larger point sizes
        }
    }
}
