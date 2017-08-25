namespace NitWitt.Models
{
    namespace Nitwitt.API.Models
    {
        public enum ViewDetail
        {
            Light,
            Medium,
            Heavy
        }

        public class ViewRequest
        {

            public string TwitterHandle { get; set; }

            public ViewDetail View { get; set; }
        }
    }
}