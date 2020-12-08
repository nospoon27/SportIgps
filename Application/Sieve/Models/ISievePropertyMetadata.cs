using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Models
{
    public interface ISievePropertyMetadata
    {
        string Name { get; set; }
        string FullName { get; }
        bool CanFilter { get; set; }
        bool CanSort { get; set; }
    }
}
