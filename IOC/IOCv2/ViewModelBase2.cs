using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace IOC.IOCv2
{
    [Serializable]
    public class ViewModelBase2 : ViewModelBase, IViewModel2
    {
        public IViewModel2 Parent { get; private set; }

        public List<IViewModel2> Children { get; private set; }

        public ViewModelBase2(IView2 view, IContainer container) : base(view, container)
        {
            Children = new List<IViewModel2>();
        }

        public void AddChild(IViewModel2 childViewModel)
        {
            if (childViewModel != null)
                Children.Add(childViewModel);
            else
                throw new NullReferenceException();
        }

        public void SetParent(IViewModel2 parentViewModel)
        {
            if (parentViewModel != null)
                Parent = parentViewModel;
            else
                throw new NullReferenceException();
        }   
    }
}
