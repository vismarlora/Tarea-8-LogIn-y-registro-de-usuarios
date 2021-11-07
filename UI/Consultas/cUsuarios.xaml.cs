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
using Tarea8LogIn.BLL;
using Tarea8LogIn.Entidades;

namespace Tarea8LogIn.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void BuscarCButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0:

                    listado = UsuariosBLL.GetUsuarios();

                    break;
            }

            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;
        }
    }
}
