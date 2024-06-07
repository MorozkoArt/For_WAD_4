using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlLibrary1
{
    internal class Fun2 : IFunction
    {
        public double calc(double x, double z)
        {
            return -Math.Pow((Math.Pow(Math.Cos(x), 2) + (Math.Pow(Math.Cos(z), 2))), 2)+1;
        }
    }
}
