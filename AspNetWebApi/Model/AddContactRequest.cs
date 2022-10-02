using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApi.Model
{
    public class AddContactRequest
    {
        public string FullName {get;set;}
        public string Email {get;set;}
        public long Phone{get;set;}
        public string Address{get;set;}
    }
}