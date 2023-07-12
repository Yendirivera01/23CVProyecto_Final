using _23CVProyecto_Final.Entities;
using _23CVProyecto_Final.Services;
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

namespace _23CVProyecto_Final.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        private void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
            throw new NotImplementedException();
        }

        UsuarioService services = new UsuarioService();

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPkUser.Text == " ")
            {
                Usuario usuario = new Usuario();

                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUser.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelectRol.SelectedValue.ToString());
                services.AddUser(usuario);

                txtNombre.Clear();
                txtUser.Clear();
                txtPassword.Clear();

                MessageBox.Show("Se agrego correctamente");
                GetUserTable();
            }
            else
            {

            }

        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();


            usuario = (sender as FrameworkElement).DataContext as Usuario;

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUser.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
        }

        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }

       
    }
    
   
}

