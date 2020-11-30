using System.Web;
using System.Web.Http;
using TheGameApp.Models;

namespace TheGameApp.Controllers
{
    public class ServerController : ApiController
    {
        [Route("initialize")]
        [HttpGet]
        public Models.Payload Get()
        {
            var session = HttpContext.Current.Session;
            session["game"] = new Game();

            return PayloadHelper.initialize();
        }


        [Route("node-clicked")]
        [HttpPost]
        public Payload Post([FromBody] Point point)
        {
            var session = HttpContext.Current.Session;
            return ((Game)session["game"]).addPoint(point);
        }

    }
}
