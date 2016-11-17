using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC
{
    [Serializable]
    public class ViewModelBase : Notifier, IViewModel
    {
        public IContainer Container { get; set; }
        public IView View { get; set; }

        public ViewModelBase(IView view, IContainer container)
        {
            View = view;
            Container = container;
            View.DataContext = this;
        }

    }
}
