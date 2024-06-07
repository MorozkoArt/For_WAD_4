using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlLibrary1
{
    internal class Fun4 : IFunction
    {
        public double calc(double x, double z)
        {
            return Math.Cos(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2)));
        }
    }       
}
