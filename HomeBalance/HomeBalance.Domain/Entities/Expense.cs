using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBalance.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public Guid PaidByUserId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
