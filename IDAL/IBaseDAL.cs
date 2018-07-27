using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDAL
    {
        void Add();
        void Delete();
        void Update();
        void Find();

    }
}
