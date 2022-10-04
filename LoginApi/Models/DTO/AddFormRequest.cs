namespace LoginApi.Models.DTO
{
    public class AddFormRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }

        public string? MobileNumber { get; set; }

        public string? Course { get; set; }
    
}

}
