using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PathFinder.Tests
{
    public class Mock
    {
        public static Bitmap Tiny1 => new Bitmap(@"..\..\..\..\TestData\tiny-1.png");
        public static Bitmap Tiny2 => new Bitmap(@"..\..\..\..\TestData\tiny-2.png");

        public static Bitmap Small1 => new Bitmap(@"..\..\..\..\TestData\small-1.png");
        public static Bitmap Small2 => new Bitmap(@"..\..\..\..\TestData\small-2.png");
        public static Bitmap Small3 => new Bitmap(@"..\..\..\..\TestData\small-3.png");
        public static Bitmap Small4 => new Bitmap(@"..\..\..\..\TestData\small-4.png");
        
    }
}
