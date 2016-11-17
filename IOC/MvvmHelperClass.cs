using IOC.IOCv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC
{
    public static class MvvmHelperClass
    {
        public static void ReloadDataContext<T>(this T view) where T : IView
        {
            var dc = view.DataContext;
            view.DataContext = null;
            view.DataContext = dc;
            dc = null;
        }

        public static T GetChildByType<T>(this IViewModel2 vm) where T:IViewModel2
        {
            var v = default(T);
            vm.Children.ForEach(x => {
                if (x.GetType() == typeof(T))
                {
                    v = (T)x;
                }
            });
            return v;
        }

    }
}
