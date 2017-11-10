using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class Visualizator
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Brush[] BrushesList { get; set; }
        private int BrushIndex { get; set; } = 0;

        public Visualizator(int screenWidth, int screenHeight)
        {
            Width = screenWidth;
            Height = screenHeight;
            BrushesList = new [] {
                Brushes.Blue, Brushes.Azure, Brushes.BlueViolet, Brushes.Green, Brushes.Yellow,
                Brushes.Coral, Brushes.Turquoise, Brushes.DarkOrange, Brushes.Khaki, Brushes.Pink
            };
        }

        private Brush GetBrush()
        {
            return BrushesList[BrushIndex++ % BrushesList.Length];
        }

        public void Visualizate(Rectangle[] rectangles, string filename)
        {
            var bitmap = new Bitmap(Width, Height);
            var g = Graphics.FromImage(bitmap);

            Array.ForEach(rectangles, r => g.FillRectangle(GetBrush(), r));

            g.FillEllipse(Brushes.White, new Rectangle(new Point(Width / 2 - 5, Height / 2 - 5), new Size(10, 10)));
            bitmap.Save(filename, ImageFormat.Jpeg);
        }
    }
}
