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


namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = Context.Product.ToList();

            // поиск, сортировка, фильтрация

            LvProduct.ItemsSource = products;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow();
            addEditProductWindow.ShowDialog();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var product = button.DataContext as Product;

            AddEditProductWindow editProductWindow = new AddEditProductWindow(product);
            editProductWindow.ShowDialog();
        }
    }
}

////