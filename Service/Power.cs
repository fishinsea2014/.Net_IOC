using IDAL;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Power :IPower
    {
        public Power(IBaseDAL baseDAL)
        {

        }

        public Power()
        {
            Console.WriteLine("Power is constructed");

        }
    }
}
