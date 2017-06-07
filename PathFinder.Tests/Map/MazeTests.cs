using PathFinder.Map;
using System.Text;
using Xunit;

namespace PathFinder.Tests.Map
{
    public class MazeTests
    {
        [Fact]
        public void Can_print_maze_as_string()
        {
            var processor = new MazeImageProcessor(Mock.Tiny1);
            var maze = processor.Read();
            Assert.Equal(string.Join("\r\n",
                        "#o###",
                        "#xxx#",
                        "###x#",
                        "#xxx#",
                        "#o###"), maze.ToString());
        }
    }
}
