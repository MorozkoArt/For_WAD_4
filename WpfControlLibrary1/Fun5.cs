using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlLibrary1
{
    internal class Fun5 : IFunction
    {
        public double calc(double x, double z)
        {
            return Math.Sin((Math.Pow(x,2) + Math.Pow(z,2))/2)+0.5;
        }
    }
}
