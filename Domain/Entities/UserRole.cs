using Domain.Common;
using Domain.Enums;
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
            RoleId = (RoleId)Enum.ToObject(typeof(RoleId), roleId);
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public RoleId RoleId { get; set; }
        public Role Role { get; set; }
    }
}
