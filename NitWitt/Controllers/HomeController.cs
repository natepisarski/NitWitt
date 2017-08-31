using System.Web.Http;
using NitWitt.Markov.Graph;

namespace NitWitt.Controllers
{
    public class GenerateModel
    {
        public string Text { get; set; }
        
        public int Length { get; set; }
        
    }
    public class ViewController : ApiController
    {
        
        [HttpGet]
        public IHttpActionResult View(string twitterHandle) {
            return Ok($"WebAPI works! {twitterHandle}");
        }

        [HttpPost]
        public IHttpActionResult Generate(GenerateModel model) {
            MarkovGraph graph = new MarkovGraph(model.Text);
            return Ok(graph.GenerateSentence(model.Length));
        }
    }
}