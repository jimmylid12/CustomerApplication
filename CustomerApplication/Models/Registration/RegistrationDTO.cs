using System;
namespace CustomerApplication.Models.Registration
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string PostCode{ get; set; }
        public string TelephoneNumber { get; set; }
     }
}