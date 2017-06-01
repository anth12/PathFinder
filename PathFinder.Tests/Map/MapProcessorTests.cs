using Xunit;
using PathFinder.Map;
using System.Drawing;
using System.IO;

namespace PathFinder.Tests.Map
{
    public class MapProcessorTests
    {
        [Fact]
        public void Can_get_black_and_white_border_colors()
        {
            var processor = new MapProcessor(Mock.Tiny1);
            processor.FindColors();

            Assert.Equal(Color.FromArgb(0,0,0), processor.wallColor);
            Assert.Equal(Color.FromArgb(255, 255, 255), processor.backgroundColor);
        }

        [Fact]
        public void Can_get_green_and_white_border_colors()
        {
            var processor = new MapProcessor(Mock.Small1);
            processor.FindColors();

            Assert.Equal(Color.FromArgb(63, 122, 34), processor.wallColor);
            Assert.Equal(Color.FromArgb(255, 255, 255), processor.backgroundColor);
        }
    }
}
