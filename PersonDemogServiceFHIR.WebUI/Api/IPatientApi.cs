using PersonDemogServiceFHIR.WebUI.Api.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDemogServiceFHIR.WebUI.Api
{
    public interface IPatientApi
    {
        [Get("/Patient/{Id}")] ///Patient/9000000033
        Task<PatientExistResponse> SearchPatientExist(string Id, [HeaderCollection] IDictionary<string, string> headers);

        [Patch("/Patient/{Id}")] ///Patient/9000000033
        Task<PatientDodNotifyResponse> PatientDodNotify(int Id,[Body] PatientDodNotifyRequest request, [HeaderCollection] IDictionary<string, string> headers);
    }
}
