using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using static Bakery.ClassHelper.EFClass;
using Bakery.Windows;
using Bakery.DB;


namespace Bakery.ClassHelper
{
    internal class CartProductClass
    {
        public static List<Product> products = new List<Product>();
        public static ObservableCollection<Product> observableCollectionProduct = new ObservableCollection<Product>(ClassHelper.CartProductClass.products);

        
    }
}
