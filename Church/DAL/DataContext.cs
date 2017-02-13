using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Configuration;
using Church.Models;

namespace Church.DAL
{
    public class DataContext: DbContext
    {
        public DataContext()
                : base(nameOrConnectionString: ConnectionStringName)
        {

        }

        public static DataContext Create()
        {
            return new DataContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Member> Member { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }
                return "DefaultConnection"; // undefined for now
            }
        }
    }
}