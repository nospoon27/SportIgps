using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Спорт, напр. 
    /// </summary>
    public class Sport : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
