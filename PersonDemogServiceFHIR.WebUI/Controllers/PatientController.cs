using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonDemogServiceFHIR.WebUI.Api;
using PersonDemogServiceFHIR.WebUI.Api.Responses;
using Refit;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonDemogServiceFHIR.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientApi patientApi;
        private readonly IConfiguration configuration;

        public PatientController(IPatientApi patientApi, IConfiguration configuration)
        {
            this.patientApi = patientApi;
            this.configuration = configuration;
        }

        // GET: api/<PatientController>
        [HttpGet]
        [SwaggerOperation(Summary = "this example works")]
        public async Task<PatientExistResponse> Get()
        {
            var headers = new Dictionary<string, string> { 
                { "Authorization", "Bearer g1112R_ccQ1Ebbb4gtHBP1aaaNM" }, 
                { "X-Request-ID", "60E0B220-8136-4CA5-AE46-1D97EF59D068" } 
            };

            try
            {
                return await patientApi.SearchPatientExist("9000000009", headers);
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }
            

        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Patch api/<PatientController>/1
        [HttpPatch("id")]
        [SwaggerOperation(Summary = "this example works")]
        public async Task<PatientDodNotifyResponse> NotifyDeath(int id)
        {
            var headers = new Dictionary<string, string> {
                { "Authorization", "Bearer g1112R_ccQ1Ebbb4gtHBP1aaaNM" },
                { "X-Request-ID", "60E0B220-8136-4CA5-AE46-1D97EF59D068" }
            };

            var deathNotifyString = configuration.GetSection("ApiFHIR").GetValue<PatientDodNotifyRequest>("DeathNotifyRequest");

            //var patientDodNotifyRequest = JsonSerializer.Deserialize<PatientDodNotifyRequest>(deathNotifyString);


            try
            {
                return await patientApi.PatientDodNotify(1, deathNotifyString, headers);
            }
            catch (ApiException ex)
            {
                // Extract the details of the error
                var errors = await ex.GetContentAsAsync<Dictionary<string, string>>();
                // Combine the errors into a string
                var message = string.Join("; ", errors.Values);
                // Throw a normal exception
                throw new Exception(message);
            }

        }
    }
}
