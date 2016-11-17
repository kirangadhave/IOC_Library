using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    [Serializable]
    public class WindowViewModelBase:Notifier,IWindowViewModel
    {
        public IView View { get; set; }
        public IWindow Window { get; set; }
        public IContainer Container { get; set; }

        public WindowViewModelBase(IWindow window, IContainer container)
        {
            Window = window;
            Window.DataContext = this;
            Container = container;
        }

        protected void ShowView<T>() where T : IViewModel
        {
            View = Container.GetInstance<T>().View;
            OnPropertyChanged(nameof(View));
        }
    }
}
