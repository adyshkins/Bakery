using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using static Bakery.ClassHelper.EFClass;
using Bakery.Windows;
using Bakery.DB;
using Bakery.ClassHelper;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartProductWindow.xaml
    /// </summary>
    public partial class CartProductWindow : Window
    {
        public CartProductWindow()
        {
            InitializeComponent();

            LvCartProduct.ItemsSource = ClassHelper.CartProductClass.products;
        }

        

        private void BtnDelToCartProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            if (product != null)
            {
                ClassHelper.CartProductClass.products.Remove(product);

                LvCartProduct.ItemsSource = ClassHelper.CartProductClass.products;

                MessageBox.Show(product.ProductName + " Delete");
            }
        }

        private void BtnBuyProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
