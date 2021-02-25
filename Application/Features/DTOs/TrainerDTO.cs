using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class TrainerDTO : BaseEntity
    {
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
        public string FullName { get => $"{User?.LastName} {User?.FirstName} {User?.MiddleName}"; }
    }
}
