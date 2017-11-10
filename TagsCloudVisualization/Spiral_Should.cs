using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    [NUnit.Framework.TestFixture]
    public class Spiral_Should
    {
       
        [NUnit.Framework.Test]
        public void GetCorrectPoints()
        {
            var center = new Point(0, 0);
            var spiral = new Spiral(center, 1);
            spiral.GetPoints().Take(5).ToArray()
                .ShouldAllBeEquivalentTo(new []
                {
                    new Point(0, 0),
                    new Point(-1, 0), 
                    new Point(-1, 1), 
                    new Point(0, 1), 
                    new Point(1, 1), 
                });
        }

        [Test]
        public void ThrowArgumentException_IfScaleLessThanOne()
        {
            Action action = () => new Spiral(new Point(0, 0), -1);
            action.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void DoSomething_WhenSomething()
        {
            
        }
    }
}
