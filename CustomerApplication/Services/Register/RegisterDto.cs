using System;
namespace RegisterApplication.Services
{
    public class RegisterDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public bool IsComplete { get; set; }
    }
}