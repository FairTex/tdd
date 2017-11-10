using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        [Test]
        public void PutNextRectangle_ShouldPutRectangleOnCenter_IfItsFirst()
        {
            var center = new Point(0, 0);
            var layouter = new CircularCloudLayouter(center, 1);

            layouter.PutNextRectangle(new Size(10, 10));
            layouter.GetRectangles()[0].ShouldBeEquivalentTo(new Rectangle(new Point(-5, -5), new Size(10, 10)));
        }

        [Test]
        public void DoesIntersect_ShouldCheckIntersaction_BetweenAllRectangles()
        {
            var center = new Point(0, 0);
            var layouter = new CircularCloudLayouter(center, 1);
            layouter.PutNextRectangle(new Size(10, 10));
            var r = new Rectangle(new Point(-10, -10), new Size(6, 6));
            layouter.DoesIntersect(r).Should().BeTrue();

            var s = new Rectangle(new Point(-10, -10), new Size(5, 5));
            layouter.DoesIntersect(s).Should().BeFalse();
        }

        [Test]
        public void TryShiftToCenter_ShouldShiftRectangleToCenter_WhileNotIntersectWithOtherRectangles()
        {
            var center = new Point(0, 0);
            var layouter = new CircularCloudLayouter(center, 1);
            layouter.PutNextRectangle(new Size(2, 2));

            var rectToShift = new Rectangle(new Point(-7, -1), new Size(2, 2));
            var rectResult = new Rectangle(new Point(-3, 0), new Size(2, 2));
            layouter.TryShiftToCenter(rectToShift).ShouldBeEquivalentTo(rectResult);
        }

        [Test]
        public void TryShiftToCenter_ShouldShiftRectangleToCenter_WhileNotIntersectWithOtherRectangles2()
        {
            var center = new Point(0, 0);
            var layouter = new CircularCloudLayouter(center, 1);
            layouter.PutNextRectangle(new Size(2, 2));

            var rectToShift = new Rectangle(new Point(3, -5), new Size(2, 2));
            var rectResult = new Rectangle(new Point(0, -3), new Size(2, 2));
            layouter.TryShiftToCenter(rectToShift).ShouldBeEquivalentTo(rectResult);
        }

        [Test]
        public void TryShiftToCenter_ShouldShiftRectangleToCenter_WhileNotIntersectWithOtherRectangles3()
        {
            var center = new Point(0, 0);
            var layouter = new CircularCloudLayouter(center, 1);
            layouter.PutNextRectangle(new Size(2, 2));

            var rectToShift = new Rectangle(new Point(5, 5), new Size(2, 2));
            var rectResult = new Rectangle(new Point(0, 1), new Size(2, 2));
            layouter.TryShiftToCenter(rectToShift).ShouldBeEquivalentTo(rectResult);
        }
    }
}