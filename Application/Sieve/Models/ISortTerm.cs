using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Models
{
    public interface ISortTerm
    {
        string Sort { set; }
        bool Descending { get; }
        string Name { get; }
    }
}
