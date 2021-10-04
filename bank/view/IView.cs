using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.view
{
    public interface IView
    {
        void setHeader();
        void setMain();
        void setAside();
    }
}
