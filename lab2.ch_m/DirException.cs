using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.ch_m
{
    internal class DirException : Exception
    {
        public DirException(string message) : base(message)
        {

        }
    }
}
