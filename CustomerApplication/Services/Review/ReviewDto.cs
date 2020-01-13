using System;
namespace ReviewApplication.Services
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public long CustomerID { get; set; }
        public long ProductID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public bool Visible { get; set; }

    }
}
