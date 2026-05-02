using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBalance.Domain.Entities
{
    public class GroupMember
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid GroupId { get; set; }

        public string Role { get; set; } = "Member";
    }
}
