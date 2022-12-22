using System;

namespace INF2course.Controllers
{
    internal class Session
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        public string Email { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
