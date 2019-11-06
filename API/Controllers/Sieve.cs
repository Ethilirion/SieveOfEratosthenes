using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SieveOfEratosthenesDomain;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sieve : ControllerBase
    {
        [HttpGet("{sieveThreshold}")]
        public ActionResult<List<uint>> GetSieveListOfResult(uint sieveThreshold)
        {
            SieveOfEratosthenes sieve = new SieveOfEratosthenesImplementation(sieveThreshold);
            var primes = sieve.FindPrimeNumbers();
            return primes.ToList();
        }
    }
}
