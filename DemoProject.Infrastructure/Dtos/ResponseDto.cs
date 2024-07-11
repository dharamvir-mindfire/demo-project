
namespace DemoProject.Dtos
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ResponseDto()
        {
            StatusCode = 200;
        }
    }
    public class ResponseDto<T> : ResponseDto
    {
        public T? Data { get; set; }

        public ResponseDto()
        {
            Data = default;
        }
    }
}
