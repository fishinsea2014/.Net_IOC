using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Microphone: IMicrophone
    {
        public Microphone()
        {
            Console.WriteLine("Microphone is constructed");
        }

    }
}
