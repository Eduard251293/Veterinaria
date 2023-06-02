using Datos;
using DevExpress.Utils.Extensions;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetPatitas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            EmpleadoDAO empleadoDAO = new EmpleadoDAO();
            Entidad.Empleado empleado = new Entidad.Empleado();

            empleado = empleadoDAO.Login(txtUsuario.Text, txtContraseña.Text);
            if (empleado != null)
            {
                this.Hide();
                ((Principal)MdiParent).tsUsuario.Text = empleado.Nombre + " " + empleado.Apellido;
                ((Principal)MdiParent).tsCargo.Text = empleado.Cargo;
                if (empleado.Cargo.Equals("Administrador"))
                    ((Principal)MdiParent).tsCargo.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("El usuario y/o contraseña es incorrecta!");
                txtUsuario.Clear();
                txtContraseña.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
