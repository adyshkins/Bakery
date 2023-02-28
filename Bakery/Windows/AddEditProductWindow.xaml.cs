﻿using System;
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

        private bool isEdit = false;

        private Product editProduct;



        public AddEditProductWindow()
        {
            InitializeComponent();

            CMBTypeProduct.ItemsSource = Context.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";
        }

        public AddEditProductWindow(Product product)
        {
            InitializeComponent();

            CMBTypeProduct.ItemsSource = Context.ProductType.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "TypeName";

            TbNameProduct.Text = product.ProductName.ToString();
            TbDisc.Text = product.Description.ToString();
            CMBTypeProduct.SelectedItem = Context.ProductType.Where(i => i.IdProdType == product.IdProdType).FirstOrDefault();

            if (product.Image != null)
            {
                using (MemoryStream stream = new MemoryStream(product.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;

                }
            }
           

            isEdit = true;

            editProduct = product;

        }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            // валидация


            if (isEdit)
            {
                //изменение товара

                editProduct.ProductName = TbNameProduct.Text;
                editProduct.Description = TbDisc.Text;
                editProduct.IdProdType = (CMBTypeProduct.SelectedItem as ProductType).IdProdType;
                if (pathPhoto != null)
                {
                    editProduct.Image = File.ReadAllBytes(pathPhoto);
                }
                Context.SaveChanges();
                MessageBox.Show("OK");
            }
            else
            {
                //добавление товара
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

            this.Close();
            
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
