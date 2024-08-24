using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using System.Data.OleDb;

namespace Zekotec01.DAL
{
    class MyContext:DbContext
    {




      

        // For migration test
        public MyContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext, MyContextMigrationConfiguration>(true));
        }


        public MyContext(DbConnection connection)
            : base(connection, false)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Yoklama> Yoklamas { get; set; }
        public DbSet<Cihaz> Cihazs { get; set; }
        public DbSet<YoklamaDefault> YoklamaDefaults { get; set; }

        public DbSet<Izin> Izins { get; set; }

    }
}




