using TheGameApp.Models;

namespace TheGameApp.Controllers
{

    public class PayloadHelper
    {
        public static Payload initialize()
        {
            return new Payload("INITIALIZE",
                new Body(
                    null,
                    "Player 1",
                    "Awaiting Player 1's Move."));
        }


        public static Payload validStartNode()
        {
            return new Payload("VALID_START_NODE",
                new Body(
                    null,
                    "Player 2",
                    "Select a second node to complete the line"));
        }

        public static Payload gameOverNode(Point fromPoint, Point toPoint)
        {
            return new Payload("GAME_OVER",
                new Body(
                    new Line(fromPoint, toPoint),
                    "Game Over",
                    "Player 2 Wins!"));
        }

        public static Payload validEndNode(Point fromPoint, Point toPoint)
        {
            return new Payload("VALID_END_NODE",
                new Body(
                    new Line(fromPoint, toPoint),
                    "Player 1",
                    null));
        }

        public static Payload invalidEndNode()
        {
            return new Payload("INVALID_END_NODE",
                new Body(
                    null,
                    "Player 2",
                    "Invalid Move!"));
        }
    }
}
