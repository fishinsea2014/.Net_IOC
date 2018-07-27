using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCExer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IOCTest.Show();

                Console.Read();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }
    }
}
