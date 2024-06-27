namespace ECommerceWebApp.Controllers.Request
{
    public class UpdateUserRequestDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Guid? DocumentId { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}
