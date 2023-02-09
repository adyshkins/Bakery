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


namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationUserWindow.xaml
    /// </summary>
    public partial class RegistrationUserWindow : Window
    {
        public RegistrationUserWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация 
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Пустой логин");
                return;
            }

            // добавление пользоватля

            Context.UserAccount.Add(new DB.UserAccount 
            {
                Login = TbLogin.Text,
                Password = PbPassword.Password,
                Email = TbEmail.Text,
                IdRole = 1
            });

            Context.SaveChanges();

            MessageBox.Show("OK");

        }
    }
}
