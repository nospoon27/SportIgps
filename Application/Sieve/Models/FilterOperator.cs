using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Models
{
    public enum FilterOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Contains,
        StartsWith,
    }
}
