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
using Microsoft.Win32;
using System.IO;

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {

        private string pathPhoto = null;

        public AddEditProductWindow()
        {
            InitializeComponent();

            CMBTypeProduct.ItemsSource = Context.ProductType.ToList();  
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductName = TbNameProduct.Text;
            product.Description = TbDisc.Text;
            product.IdProdType = (CMBTypeProduct.SelectedItem as ProductType).IdProdType;
            if (pathPhoto != null)
            {
                product.Image = File.ReadAllBytes(pathPhoto);
            }

            Context.Product.Add(product);

            Context.SaveChanges();
            MessageBox.Show("OK");
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}
