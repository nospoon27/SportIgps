using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Объект {name} ({key}) не был найден.")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
