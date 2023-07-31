using Models.Dtos;
using Newtonsoft.Json;

namespace Business.Services
{
    public class GetEmployeeById
    {
        private readonly string _baseAddress;

        public GetEmployeeById(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public EmployeesDTO GetEmployeeByIdAsync(int? Id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(_baseAddress + "/employee/" + Id).Result;

                    // Deserializar el JSON en una instancia de ApiResponse
                    var apiResponse = JsonConvert.DeserializeObject<EmployeesDTO>(response);

                    decimal months = 12;

                    foreach (var employee in apiResponse.data)
                    {
                        // Calcula el nuevo salario aumentando el salario actual en el porcentaje deseado.
                        employee.employee_salary_calc += employee.employee_salary * months;
                    }

                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                var apiResponse = new EmployeesDTO();

                apiResponse.message = "Too Many Requests.";
                apiResponse.status = ex.Message;

                return apiResponse;
            }
        }
    }
}
