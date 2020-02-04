using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD.Models
{
    public class MyContext :DbContext
    {
        

        public MyContext(DbContextOptions<MyContext> options ):base(options)
        {

        }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<UserBill> UserBills { get; set; }
    }
}
