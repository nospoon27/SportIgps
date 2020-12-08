using Application.Sieve.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SieveAttribute : Attribute, ISievePropertyMetadata
    {
        /// <summary>
        /// Override name used 
        /// </summary>
        public string Name { get; set; }

        public string FullName => Name;

        public bool CanSort { get; set; }
        public bool CanFilter { get; set; }
    }
}
