using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Zekotec01.DAL
{
   
        internal sealed class MyContextMigrationConfiguration : DbMigrationsConfiguration<Zekotec01.DAL.MyContext>
        {
            public MyContextMigrationConfiguration()
            {
                AutomaticMigrationsEnabled = true;
               // AutomaticMigrationDataLossAllowed = true;
               // ContextKey = "Zekotec01.DAL.MyContext";
             }
        }

   

}

