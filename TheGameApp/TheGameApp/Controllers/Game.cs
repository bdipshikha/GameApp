using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheGameApp.Models;

namespace TheGameApp.Controllers
{
    public class Game
    {
        LinkedList<Point> points = new LinkedList<Point>();

        public Payload addPoint(Point newPoint)
        {
            if (points.Contains(newPoint))
            {
                return PayloadHelper.invalidEndNode();
            }

            if (points.Count() == 0)
            {
                points.AddFirst(newPoint);
                return PayloadHelper.validStartNode();
            }
            else if
              (isNeighbour(points.Last(), newPoint) && !crossingAnyLine(new Line(points.Last(), newPoint)))
            {
                Point last = points.Last();
                points.AddLast(newPoint);

                if (isEnd(newPoint))
                {
                    return PayloadHelper.gameOverNode(last, newPoint);
                }
                return PayloadHelper.validEndNode(last, newPoint);
            }
            else if (isNeighbour(points.First(), newPoint) && !crossingAnyLine(new Line(points.First(), newPoint)))
            {
                Point first = points.First();
                points.AddFirst(newPoint);

                if (isEnd(newPoint))
                {
                    return PayloadHelper.gameOverNode(first, newPoint);
                }

                return PayloadHelper.validEndNode(first, newPoint);
            }

            return PayloadHelper.invalidEndNode();
        }



        private bool isEnd(Point a)
        {
            return !isMoveAvailable(points.First()) && !isMoveAvailable(points.Last());
        }

        private bool isMoveAvailable(Point a)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    Point newPoint = new Point(a.x + dx, a.y + dy);
                    if (!newPoint.Equals(a)
                        && newPoint.Valid()
                        && !points.Contains(newPoint))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private bool crossingAnyLine(Line line)
        {
            IEnumerator<Point> itr = points.GetEnumerator();
            Point prev = null;
            while (itr.MoveNext())
            {
                Point current = itr.Current;
                if (prev != null)
                {
                    if (line.isCrossing(new Line(prev, current))) return true;
                }
                prev = current;
            }
            return false;
        }

        private bool isNeighbour(Point a, Point b)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (a.x == b.x + dx && a.y == b.y + dy)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
