using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    /// <summary>
    /// Секция / Занятие
    /// </summary>
    public class Section : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Sport Sport { get; set; }
        public int SportId { get; set; }
    }
}
