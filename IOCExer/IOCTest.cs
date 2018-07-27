using DAL;
using IDAL;
using Interface;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
//using Unity;
using System.IO;

namespace IOCExer
{
    public class IOCTest
    {
        public static void Show()
        {
            {
                Console.WriteLine("=====Basic Usage of Unity=========");
                IUnityContainer container = new UnityContainer(); //1. Declare a container
                container.RegisterType<IPhone, AndriodPhone>(); //2. Initiate the container, register the type
                                                                // This is an interface
                IPhone phone = container.Resolve<IPhone>(); //3. Create an object by reflection
                phone.Call();

                container.RegisterType<AbstractPad, ApplePad>(); // This is an abstract class
                AbstractPad pad = container.Resolve<AbstractPad>();
                pad.Show();

                container.RegisterType<ApplePad, ApplePadChild>(); //This is an example of parent and child
                ApplePad applePad = container.Resolve<ApplePad>();
                applePad.Show();

                //One to many
                container.RegisterType<AbstractPad, ApplePad>("childPad"); //One to many, use alias
                container.RegisterType<AbstractPad, ApplePadChild>("grandChildPad");
                var childPad = container.Resolve<AbstractPad>("childPad");
                var grandChildPad = container.Resolve<AbstractPad>("grandChildPad");
                childPad.Show();
                grandChildPad.Show();

                //Register an instance
                container.RegisterInstance<ITV>(new AppleTV(123));
                var tv = container.Resolve<ITV>();
                tv.Show();
                Console.WriteLine("====End of basic utility===");
            }

            {
                Console.WriteLine("====Dependency injection, implementing multi layer structure ====");
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, ApplePhone>();
                container.RegisterType<IMicrophone, Microphone>();
                container.RegisterType<IPower, Power>();
                container.RegisterType<IHeadphone, Headphone>();
                container.RegisterType<IBaseDAL, BaseDAL>();
                IPhone phone = container.Resolve<IPhone>();
                phone.Call();
                Console.WriteLine("====End of dependency injection====");
            }

            {
                Console.WriteLine("====Life circly management====");
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IPhone, AndriodPhone>();//Default is transient lifecycle
                container.RegisterType<IPhone, AndriodPhone>(new TransientLifetimeManager());
                container.RegisterType<IPhone, AndriodPhone>(new ContainerControlledLifetimeManager());//container implement sigleton method
                var phone1 = container.Resolve<IPhone>();
                var phone2 = container.Resolve<IPhone>();
                Console.WriteLine(object.ReferenceEquals(phone1, phone2)); // in transient mode, return false; in container controll mode, return true.

                {
                    Console.WriteLine("====Singleton mode in a thread"); // The instances in same thread is same one.
                    container.RegisterType<IPhone, AndriodPhone>(new PerThreadLifetimeManager());
                    IPhone iphone1 = null;
                    Action act1 = new Action(() =>
                    {
                        iphone1 = container.Resolve<IPhone>();
                        Console.WriteLine($"iphone1 is created by thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    var result1 = act1.BeginInvoke(null, null);

                    IPhone iphone2 = null;
                    Action act2 = new Action(() =>
                    {
                        iphone2 = container.Resolve<IPhone>();
                        Console.WriteLine($"iphone2 is created by thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    IPhone iphone3 = null;

                    var result2 = act2.BeginInvoke(t =>
                   {
                       iphone3 = container.Resolve<IPhone>();
                       Console.WriteLine($"iphone1 is created by thread: {Thread.CurrentThread.ManagedThreadId}");
                       Console.WriteLine($"object.ReferenceEquals(iphone2, iphone3)={object.ReferenceEquals(iphone2, iphone3)}");
                   }, null);

                    act1.EndInvoke(result1);
                    act2.EndInvoke(result2);

                    //iphone1 and iphone2 are created by same thread, so they are equal
                    Console.WriteLine($"iphone1 is equals to iphone2 is {object.ReferenceEquals(iphone1, iphone2)}");
                }

                {
                    Console.WriteLine("===Each layer container's singleton model=====");
                    container.RegisterType<IPhone, AndriodPhone>(new HierarchicalLifetimeManager());
                    IUnityContainer childContainer = container.CreateChildContainer();
                }

                {
                    Console.WriteLine("====Releaseable singleton from outside====");
                    container.RegisterType<IPhone, AndriodPhone>(new ExternallyControlledLifetimeManager());
                }

                {
                    Console.WriteLine("====Recycle referenced container====");
                    container.RegisterType<IPhone, AndriodPhone>(new PerResolveLifetimeManager());
                }

                {
                    Console.WriteLine("====Create container from configuration file====");
                    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                    fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
                    Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                    UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

                    //IUnityContainer containerF = new UnityContainer();
                    //section.Configure(containerF, "testContainer");
                    //IPhone phone = containerF.Resolve<IPhone>();
                    //phone.Call();

                    Console.WriteLine("====Extend class Android phone====");

                    //IUnityContainer containerE = new UnityContainer();
                    //section.Configure(containerE, "testContainerE");
                    //IPhone phoneE = containerF.Resolve<IPhone>();
                    //phoneE.Call();

                    Console.WriteLine("====IOC + AOP from config file====");
                    IUnityContainer containerAOP = new UnityContainer();
                    section.Configure(containerAOP, "testContainerAOP");
                    IPhone phoneAOP = containerAOP.Resolve<IPhone>();
                    phoneAOP.Call();

                    //IPhone android = containerF.Resolve<IPhone>("Android");
                    //android.Call();

                }

                {

                }
            }


        } 
    }
}

