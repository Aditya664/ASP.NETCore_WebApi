using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApi.Data
{
    public class ContactsApiDbContext : DbContext
    {
        public ContactsApiDbContext(DbContextOptions options):base(options){

        }

        public DbSet<Contact> contacts {get;set;}
    }
}