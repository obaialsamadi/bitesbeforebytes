using CafeteriaAspx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CafeteriaAspx.Models
{
    public class AppDB : DbContext //Inherits from this database to be able to make queries and connections
    {
        public AppDB(): base("CafeteriaData") //taken from Web.config in connection strings
        {

        }
        //These are for the models we need. So if you create a model and need to hook up to db, here's where to do it
        // follow this formula: public set name <model name> Name of Model inside the table
        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}