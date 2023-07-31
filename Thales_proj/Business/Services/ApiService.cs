using Models.Dtos;
using Newtonsoft.Json;

namespace Business.Services
{
    public class ApiService
    {
        private readonly string _baseAddress;

        public ApiService(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public EmployeesDTO GetEmployeesAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(_baseAddress + "/employees").Result;

                    // Deserializar el JSON en una instancia de ApiResponse
                    var apiResponse = JsonConvert.DeserializeObject<EmployeesDTO>(response);

                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
