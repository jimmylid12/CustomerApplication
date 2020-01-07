using System;
namespace RegisterApplication.Services
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string PostCode { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
