namespace Car_Dealership.Models
{
    public class ServiceResponse<T> //T is the actual type of the data we want to return 
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; }   
        public string Message { get; set; } = string.Empty;
    }
}
