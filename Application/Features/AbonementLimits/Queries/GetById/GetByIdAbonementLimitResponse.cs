using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AbonementLimits.Queries.GetById
{
    public class GetByIdAbonementLimitResponse
    {
        public int VisitAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
