using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace Service
{
    public class ApplePhone : IPhone
    {
        [Dependency] //Inject attributes, good, but depend on container
        public IMicrophone iMicrophone { get; set; }
        public IHeadphone iHeadphone { get; set; }

        public IPower iPower { get; set; }

        public ApplePhone()
        {
            Console.WriteLine("{0} construction method", this.GetType().Name);
        }

        [InjectionConstructor] //Constructor injection, good, the default is to find the constructor with the most parameters.
        public ApplePhone(IHeadphone headphone)
        {
            this.iHeadphone = headphone;
            Console.WriteLine("{0}construction with arguments", this.GetType().Name);
        }

        public void Call()
        {
            Console.WriteLine("{0}打电话", this.GetType().Name);
        }

        [InjectionMethod ] //Method injection, not good, broken the encapsulation
        public void Init1234 (IPower power)
        {
            this.iPower = power;
        }


    }
}
