using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace IOC.IOCv2
{
    public class WindowViewModelBase2 : WindowViewModelBase
    {
        public WindowViewModelBase2(IWindow2 window, IContainer container) : base(window, container)
        {

        }
    }
}
