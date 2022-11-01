using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.ch_m
{
    internal class ConsoleException : Exception
    {
        public ConsoleException(string message) : base(message)
        {

        }
    }
}
