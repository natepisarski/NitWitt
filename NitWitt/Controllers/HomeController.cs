using System.Web.Http;

namespace NitWitt.Controllers
{
    public class ViewController : ApiController
    {
        [HttpGet]
        public IHttpActionResult View(string twitterHandle) {
            return Ok($"WebAPI works! {twitterHandle}");
        }
    }
}