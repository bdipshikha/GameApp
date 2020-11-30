using System;

namespace TheGameApp.Models
{
    public class Line
    {
        public Point start;
        public Point end;

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public bool isCrossing(Line line)
        {
            Line intersectingLine = new Line(new Point(start.x, end.y), new Point(end.y, start.y));
            
            //reversed of above
            Line intersectingLineReversed = new Line(new Point(end.x, start.y), new Point(start.x, end.y));

            return line.Equals(intersectingLine) || line.Equals(intersectingLineReversed);
        }
    }
}
