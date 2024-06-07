using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlLibrary1
{
    internal class Fun1 : IFunction
    {
        public double calc(double x, double z)
        {
            return Math.Pow(x, 2) + Math.Pow(z, 2);
        }
    }
    
}
