using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace TestAOP
{
    public class AuthorizeBehavior : IInterceptionBehavior

    {
        public bool WillExecute {
            get { return true; }
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Check the authorization of the user role ");
            if (true)
            {
                Console.WriteLine("The user pass the authorization check");
                return getNext()(input, getNext);
            }
            else
            {
                return input.CreateExceptionMethodReturn(new Exception("Authorization check failed."));
            }
        }
    }
}
