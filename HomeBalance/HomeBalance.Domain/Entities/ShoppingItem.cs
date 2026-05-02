using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBalance.Domain.Entities
{
    class ShoppingItem
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsPurchased { get; set; } = false;
    }
}
