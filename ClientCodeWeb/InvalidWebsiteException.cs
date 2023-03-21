using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCodeWeb
{
    internal class InvalidWebsiteException : Exception
    {
        public InvalidWebsiteException(string message) : base(message) { }
    }
}
