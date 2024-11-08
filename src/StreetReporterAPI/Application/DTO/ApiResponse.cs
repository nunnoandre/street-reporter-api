namespace StreetReporterAPI.Application.DTO
{
    public class ApiResponse<T>
    {
        public T? ResponseObject;
        public string? ErrorMessage;       
    }
}
