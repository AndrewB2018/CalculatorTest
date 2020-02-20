using Calculator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ISimpleCalculator _calculator;

        public CalculatorController(ISimpleCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        [Route("add/{start:int}/{amount:int}")]
        public int Add(int start = 0, int amount = 0)
        {
            int result = _calculator.Add(start, amount);

            return result;
        }

        [HttpGet]
        [Route("subtract/{start:int}/{amount:int}")]
        public int Subtract(int start = 0, int amount = 0)
        {
            return _calculator.Subtract(start, amount);
        }

        [HttpGet]
        [Route("divide/{start:int}/{amount:int}")]
        public int Divide(int start = 0, int amount = 0)
        {
            return _calculator.Divide(start, amount);
        }

        [HttpGet]
        [Route("multiply/{start:int}/{amount:int}")]
        public int Multiply(int start = 0, int amount = 0)
        {
            return _calculator.Multiply(start, amount);
        }
    }
}
