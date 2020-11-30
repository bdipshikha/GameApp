namespace TheGameApp.Models
{
    public class Payload
    {
        public string msg;
        public Body body;

        public Payload(string msg, Body body)
        {
            this.msg = msg;
            this.body = body;
        }
    }
}
