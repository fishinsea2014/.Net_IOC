using Interface;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IOC
{
    public class IOCTest
    {
        public static void Show()
        {
            Console.WriteLine("=====Basic Usage of Unity=========");
            IUnityContainer container = new UnityContainer(); //1. Declare a container
            container.RegisterType<IPhone, AndriodPhone>(); //2. Initiate the container, register the type
            IPhone phone = container.Resolve<IPhone>(); //3. Create an object by reflection
            phone.Call();
        } 
    }
}

