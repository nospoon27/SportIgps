using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Models
{
    public class SieveOptions
    {
        public bool CaseSensitive { get; set; } = false;

        public int DefaultPageSize { get; set; } = 0;

        public int MaxPageSize { get; set; } = 0;

        public bool ThrowExceptions { get; set; } = false;
    }
}
