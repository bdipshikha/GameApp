using System;
namespace TheGameApp.Models
{
    public class Point
    {
        public int x;
        public int y;

        public Point() { }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Point point = (Point)o;

            return x == point.x &&  y == point.y;
        }


        public override String ToString()
        {
            return "models.Point{" +
                    "x=" + x +
                    ", y=" + y +
                    '}';
        }

        public bool Valid()
        {
            return x >= 0 && x < 4 && y >= 0 && y < 4;
        }

    }
}
