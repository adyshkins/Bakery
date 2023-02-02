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

namespace Bakery.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Context.UserAccount.ToList()
                .Where(i => i.LoginName == TbLogin.Text &&
                i.PasswordHash == PbPassword.Password)
                .FirstOrDefault();

            if (userAuth != null)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}

///
///
///
///
//////
///
///
///
//////
///
///
///
///
