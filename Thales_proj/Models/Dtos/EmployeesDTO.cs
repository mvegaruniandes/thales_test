namespace Models.Dtos
{
    public class EmployeesDTO
    {
        public string? status { get; set; }
        public List<EmployeeDTO>? data { get; set; }
        public string? message { get; set; }
    }
}
