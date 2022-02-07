using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReadJSONFromFile.Models;
using System.Net;
using Newtonsoft.Json;

namespace ReadJSONFromFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarksController : Controller
    {
        private readonly ILogger<MarksController> _logger;

        public MarksController(ILogger<MarksController> logger)
        {
            _logger = logger;
        }        
       
        [HttpGet]
        public IActionResult GetCalculatedMarks(string subjectName)
        {
            //Fetch the JSON string from URL.
            string json = (new WebClient()).DownloadString("https://raw.githubusercontent.com/tester1-1/testdata/main/data.json");

            //Deserialize the object
            var markList = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, double>>>(json);

            //Find min and max value
            MarkCalculation result = new MarkCalculation()
            {
                Min = markList.SelectMany(x => x.Value).Where(y => y.Key == subjectName).Min(z => z.Value),
                Max = markList.SelectMany(x => x.Value).Where(y => y.Key == subjectName).Max(z => z.Value)
            };

            //Serialize and Return the JSON string.
            return Json(result);
        }
    }
}
