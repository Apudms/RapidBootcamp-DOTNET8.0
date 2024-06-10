using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public interface ICrud
    {
        void Insert();
        void Select();
        void Update();
        void Delete();
    }
}
