using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace IOC.IOCv2
{
    public interface IViewModel2 : IViewModel
    {
        IViewModel2 Parent { get; }
        ObservableCollection<IViewModel2> Children { get; }

        void SetParent(IViewModel2 parentViewModel);
        void AddChild(IViewModel2 childViewModel);
        IViewModel2 GetChild<T>() where T : IViewModel2;
    }
}
