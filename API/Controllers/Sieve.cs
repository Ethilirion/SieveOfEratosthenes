using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SieveDomain;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sieve : ControllerBase
    {
        [HttpGet("{sieveThreshold}")]
        public ActionResult<List<uint>> GetSieveListOfResult(uint sieveThreshold)
        {
            SieveDomain.Sieve sieve = new SieveOfEratosthenesImplementation(sieveThreshold);
            var primes = sieve.FindPrimeNumbers();
            return primes.ToList();
        }
    }
}
