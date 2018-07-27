using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extend
{
    public class Microphone : IMicrophone
    {

        //[Dependency]
        //public ApplePhone ApplePhone { get; set; }
        public Microphone()
        {
            Console.WriteLine("Microphone Extend is constructed");
        }
    }
}
