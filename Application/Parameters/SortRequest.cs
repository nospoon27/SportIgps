using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Parameters
{
    public class SortRequest : ISortRequest
    {
        public string Sort { get; set; } // asc, desc
    }

    public interface ISortRequest
    {
        public string Sort { get; set; } // asc, desc
    }
}
