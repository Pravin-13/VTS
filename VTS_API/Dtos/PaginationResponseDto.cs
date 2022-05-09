namespace VTS_API.Dtos
{
    public class PaginationResponseDto<T>
    {
        public PaginationResponseDto()
        {
        }
        public PaginationResponseDto(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
