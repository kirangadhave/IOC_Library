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
        }

        /// <summary>
        /// Adds Child VM to this VM.
        /// </summary>
        /// <param name="childViewModel"></param>
        public void AddChild(IViewModel2 childViewModel)
        {
            if (childViewModel == null)
                throw new ArgumentNullException(nameof(childViewModel));
            Children.Add(childViewModel);
            childViewModel.SetParent(this);
        }

        /// <summary>
        /// Sets Parent VM for this VM.
        /// </summary>
        /// <param name="parentViewModel"></param>
        public void SetParent(IViewModel2 parentViewModel)
        {
            if (parentViewModel == null)
                throw new ArgumentNullException(nameof(parentViewModel));
            Parent = parentViewModel;
        }

        /// <summary>
        /// Gets ChildVM of type T from Children collection if exists. Else returns null.
        /// </summary>
        /// <typeparam name="T">Generic Param. Must implement IViewModel2</typeparam>
        /// <returns>IViewModel2 object from Children if its type matches T, else returns null.</returns>
        public IViewModel2 GetChild<T>() where T: IViewModel2
        {
            if(Children != null && Children.Count > 0)
                foreach(var a in Children)
                    if (a is T)
                        return a;
            return null;
        }
    }
}
