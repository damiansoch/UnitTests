using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class FunctionExample
    {
        public string ReturnsPikachuIfZero(int num)
        {
            if (num == 0)
            {
                return "Pickchu";
            }
            else
            {
                return "Squirtle";
            };
        }
    }
}
