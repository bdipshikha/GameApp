using System;

namespace TheGameApp.Models
{
    public class Body
    {
        public Line newLine;
        public string heading;
        public string message;

        public Body(Line newLine, String heading, String message)
        {
            this.newLine = newLine;
            this.heading = heading;
            this.message = message;
        }
    }
}
