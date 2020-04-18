using MongoDbGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class ContactDocument :Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
    }
}
