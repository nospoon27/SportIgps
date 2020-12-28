using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Permissions.Queries.GetCurrentUserPermissions
{
    public class GetCurrentUserPermissionsResponse
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Value { get; set; }
    }
}
