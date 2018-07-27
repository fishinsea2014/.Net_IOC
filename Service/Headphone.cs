using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Headphone : IHeadphone
    {
        public Headphone()
        {
            Console.WriteLine("Headphone is constructed");
        }
    }
}
