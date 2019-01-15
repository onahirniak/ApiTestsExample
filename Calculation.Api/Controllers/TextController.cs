using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calculation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController
    {
        // GET api/text
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/text/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/text
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/text/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/text/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
