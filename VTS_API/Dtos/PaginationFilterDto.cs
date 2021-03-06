namespace VTS_API.Dtos
{
    public class PaginationFilterDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilterDto()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilterDto(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
