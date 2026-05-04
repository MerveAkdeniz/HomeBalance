using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBalance.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<GroupMember> Members { get; set; } = new List<GroupMember>();

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

        public ICollection<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
    }
}
