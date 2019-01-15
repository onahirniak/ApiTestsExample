using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calculation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost("multiply")]
        public async Task<ActionResult<ValueResponse>> Post([FromBody] MultiplyValueRequest request)
        {
            return new ValueResponse {Result = request.Value1 * request.Value2};
        }

        [HttpPost("sum")]
        public async Task<ActionResult<ValueResponse>> Post([FromBody] SumValueRequest request)
        {
            return new ValueResponse { Result = request.Value1 + request.Value2 };
        }

        [HttpPost("divide")]
        public async Task<ActionResult<ValueResponse>> Post([FromBody] DivideValueRequest request)
        {
            return new ValueResponse { Result = (decimal)request.Value1 / request.Value2  };
        }

        // Next task
        /*
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> Get()
        {
            return Storage.Values;
        }

        // GET api/values/5
        [HttpGet("{index}")]
        public async Task<ActionResult<int>> Get(int index)
        {
            return Storage.Values[index];
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddValueRequest request)
        {
            Storage.Values.Add(request.Value);

            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{index}")]
        public async Task<IActionResult> Put(int index, [FromBody] AddValueRequest request)
        {
            Storage.Values[index] = request.Value;

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{index}")]
        public async Task<IActionResult> Delete(int index)
        {
            Storage.Values.Remove(Storage.Values.LastIndexOf(index));

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            Storage.Values.Clear();

            return NoContent();
        }
        */
    }
}
