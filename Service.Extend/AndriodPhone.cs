using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extend
{
    public class AndriodPhone : IPhone
    {
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }

        public AndriodPhone()
        {
            Console.WriteLine("{0}Construction method", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0} Extend make a call", this.GetType().Name); ;
        }
    }
}
