using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC.IOCv2
{
    public interface IViewModel2 : IViewModel
    {
        IViewModel2 Parent { get; }
        List<IViewModel2> Children { get; }
    }
}
