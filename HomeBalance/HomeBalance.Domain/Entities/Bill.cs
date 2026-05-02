using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBalance.Domain.Entities
{
    class Bill
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public Guid PaidByUserId { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = null!;

        public bool IsPaid { get; set; } = false;

        public DateTime DueDate { get; set; }
    }
}
