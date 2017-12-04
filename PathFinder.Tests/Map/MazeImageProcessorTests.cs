using Xunit;
using PathFinder.Map;
using System.Drawing;

namespace PathFinder.Tests.Map
{
    public class MazeImageProcessorTests
    {
        [Fact]
        public void Can_get_black_and_white_border_colors()
        {
            var processor = new MazeImageProcessor(Mock.Tiny1);
            processor.FindColors();
            {
                Assert.Equal(Color.FromArgb(0, 0, 0), processor.wallColor);
                Assert.Equal(Color.FromArgb(255, 255, 255), processor.backgroundColor);
            }
        }

        [Fact]
        public void Can_get_green_and_white_border_colors()
        {
            var processor = new MazeImageProcessor(Mock.Small1);
            processor.FindColors();
            {
                Assert.Equal(Color.FromArgb(63, 122, 34), processor.wallColor);
                Assert.Equal(Color.FromArgb(255, 255, 255), processor.backgroundColor);
            }
        }

        [Fact]
        public void Can_find_measure_maze_height_width()
        {
            var processor = new MazeImageProcessor(Mock.Small1);
            var maze = processor.Read();
            {
                Assert.Equal(8, maze.Width);
                Assert.Equal(8, maze.Heigh);
            }
        }

        [Fact]
        public void Can_find_entrances()
        {
            var processor = new MazeImageProcessor(Mock.Small1);
            var maze = processor.Read();
            {
                Assert.True(maze.Rows[0][2].IsEntrance);
                Assert.True(maze.Rows[7][1].IsEntrance);
            }
        }

    }
}
