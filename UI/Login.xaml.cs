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
using Tarea8LogIn.BLL;
using Tarea8LogIn.Entidades;

namespace Tarea8LogIn.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();

        MainWindow Principal = new MainWindow();

        public Login()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = LoginBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                this.Close();

                Principal.Show();
            }
            else
            {
                MessageBox.Show("El Nombre de Usuario o la Contraseña está incorrecto, verifica e intenta de nuevo...", "Error!");

                ContrasenaPasswordBox.Clear();

                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
