using Microsoft.AspNetCore.Mvc;

namespace Car_Dealership
{
    public class Result
    {
        public Result(int statusCode, object? response)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public int StatusCode { get; set; }
        public object? Response { get; set; }

        public ObjectResult ToObjectResult(bool? returnJsonResponseBody = false)
        {
            ObjectResult objectResult = new(null)
            {
                StatusCode = StatusCode,
                Value = Response
            };

            return objectResult;
        }
    }
}
