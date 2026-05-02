using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeBalance.Domain.Entities;


namespace HomeBalance.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<HomeBalance.Domain.Entities.Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }

        public DbSet<Bill> Bills { get; set; }
    }
}
