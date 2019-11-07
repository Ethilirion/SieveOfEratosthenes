using System;
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
            try
            {
                SieveDomain.Sieve sieve = new SieveOfEratosthenesImplementation(sieveThreshold);
                var primes = sieve.FindPrimeNumbers();
                return primes.ToList();
            }
            catch (IncorrectValue)
            {
                if (HttpContext != null)
                    HttpContext.Response.StatusCode = 422;
                return new List<uint>();
            }
#pragma warning disable CS0162 // Impossible d'atteindre le code détecté
            return new List<uint>();
#pragma warning restore CS0162 // Impossible d'atteindre le code détecté
        }
    }
}
