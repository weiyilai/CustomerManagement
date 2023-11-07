namespace Application.Requests
{
    public class CustomersQueryRequest
    {
        public string? Name { get; set; }
        public int? StartAge { get; set; }
        public int? EndAge { get; set; }
        public string? Gender { get; set; }
        public PageRequest Paging { get; set; }
    }
}
