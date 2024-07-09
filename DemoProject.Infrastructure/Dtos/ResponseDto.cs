namespace DemoProject.Dtos
{
    public class ResponseDto
    {
        public ResponseDto()
        {
            statusCode = 200;
        }
        public int statusCode { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }
    }
}
