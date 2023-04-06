using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Tests
{
    public static class FunctionExampleTest
    {
        //naming convention - ClassName_MethodName_ExpectedResult
        public static void FunctionExample_ReturnsPikachuIfZero_ReturnsString()
        {
            try
            {
                //------Arrange - Go get your variables, classes,functions (whatever we need)

                int num= 0;
                FunctionExample example = new FunctionExample();

                //------Act - execute the function

                string result = example.ReturnsPikachuIfZero(num);

                //------Assert - whatever is returned, is it what you wanted?

                if(result == "Pickchu")
                {
                    Console.WriteLine("Passed: FunctionExample.ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("Failed");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
