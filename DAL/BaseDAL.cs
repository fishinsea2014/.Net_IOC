using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL : IBaseDAL
    {
        public void Add()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{nameof(Add)}");
        }

        public void Delete()
        {
            Console.WriteLine($"{nameof(Delete)}");
        }

        public void Find()
        {
            Console.WriteLine($"{nameof(Find)}");
        }

        public void Update()
        {
            Console.WriteLine($"{nameof(Update)}");
        }
    }
}
