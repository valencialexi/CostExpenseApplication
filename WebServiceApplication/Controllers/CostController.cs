using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using WebServiceApplication.Models;

namespace WebServiceApplication.Controllers
{
    public class CostController : ApiController
    {
        // GET: Cost
       [Route("api/cost")]
       [HttpPost]
        public IHttpActionResult Index(HttpRequestMessage requestMessage)
        {
            var readRequest = Request.Content.ReadAsStringAsync().Result.ToLower();
            
            //Add a opening and closing tag for the whole string
            readRequest = "<root>" + readRequest +  "</root>";
            try
            {
                XElement request = XElement.Parse(readRequest);

                //check if Total is existing
                if (request != null && request.Element("total") != null)
                {
                    //build  the json response
                    dynamic obj = new ExpandoObject();
                    obj.discoverySchemaVersion = "1.0.0";
                    obj.result = new ExpandoObject();

                    var costModel = CostModel.CalculateExtractedResult(request);
                    var jsonToReturn = JsonConvert.SerializeObject(costModel);


                    if (null != jsonToReturn)
                    {
                        return Ok(jsonToReturn);
                    }
                }

                return NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception("Invalid message. Please try again." + ex.Message);
            }
        }
    }
}