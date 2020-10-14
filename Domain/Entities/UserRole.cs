using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public UserRole(){}
        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
