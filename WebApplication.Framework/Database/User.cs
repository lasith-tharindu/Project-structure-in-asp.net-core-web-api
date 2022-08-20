using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Framework.Database
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CodeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string UserRole { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
