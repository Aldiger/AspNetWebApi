using Assecor.Services.Interfaces;
using Assecor.Services.Services;
using System.Collections.Generic;
using System.Web.Http;


namespace Assecor.WebApi.Controllers
{

    public class PersonController : ApiController
    {
        public IColorService _colorService { get; set; }
        public IPersonService _personService { get; set; }
        //public PersonController(IColorService colorService)
        //{
        //    _colorService = colorService;
        //}
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/color/{colors}")]
        public IHttpActionResult GetColors(string colors)
        {
            dynamic result = _colorService.GetColors();
            return Ok(result);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
