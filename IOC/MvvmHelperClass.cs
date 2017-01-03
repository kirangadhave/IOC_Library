using IOC.IOCv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC
{
    public static class MvvmHelperClass
    {
        /// <summary>
        /// Reloads the DataContext for view object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view"></param>
        public static void ReloadDataContext<T>(this T view) where T : IView
        {
            var dc = view.DataContext;
            view.DataContext = null;
            view.DataContext = dc;
        }
    }
}
