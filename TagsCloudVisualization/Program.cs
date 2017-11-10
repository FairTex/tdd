using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var layouter = new CircularCloudLayouter(new Point(1000, 1000));

            var rnd = new Random();
            var sizes = new Size[15].Select(s => new Size(rnd.Next(10, 600), rnd.Next(10, 600))).ToArray();
            
            foreach (var size in sizes)
            {
                layouter.PutNextRectangle(size);
            }            

            var rS = layouter.GetRectangles();

            var v = new Visualizator(2000, 2000);
            v.Visualizate(rS, "test3.jpeg");

        }
    }
}
