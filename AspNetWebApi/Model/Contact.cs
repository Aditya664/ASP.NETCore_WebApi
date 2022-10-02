using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApi.Model
{
    public class Contact
    {
        public Guid Id {get;set;}
        public string FullName {get;set;}
        public string Email {get;set;}
        public long Phone{get;set;}
    }
}