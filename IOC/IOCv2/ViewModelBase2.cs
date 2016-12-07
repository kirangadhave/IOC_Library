using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Reflection;
using System.Collections.ObjectModel;

namespace IOC.IOCv2
{
    [Serializable]
    public class ViewModelBase2 : ViewModelBase, IViewModel2
    {
        public event EventHandler Initialized;

        public IViewModel2 Parent { get; private set; }

        public ObservableCollection<IViewModel2> Children { get; private set; }

        public ViewModelBase2(IView2 view, IContainer container) : base(view, container)
        {
            Children = new ObservableCollection<IViewModel2>();
            Children.CollectionChanged += Children_CollectionChanged;
            Initialized += ViewModelBase2_Initialized;
        }

        private void ViewModelBase2_Initialized(object sender, EventArgs e)
        {
            LoadChildren();
        }

        private void LoadChildren()
        {
            var selfType = GetType();
            foreach (var a in selfType.GetProperties())
            {
                if (a != null && a.GetType() == typeof(IViewModel2))
                    AddChild(a.GetValue(this,null) as IViewModel2);
            }
        }

        private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            e.NewItems.Cast<IViewModel2>().ToList().ForEach(x =>
            {
                x.SetParent(this);
            });
        }

        public void AddChild(IViewModel2 childViewModel)
        {
            if (childViewModel == null)
                throw new ArgumentNullException(nameof(childViewModel));
            Children.Add(childViewModel);   
        }

        public void SetParent(IViewModel2 parentViewModel)
        {
            if (parentViewModel == null)
                throw new ArgumentNullException(nameof(parentViewModel));
            Parent = parentViewModel;
        }   
    }
}
