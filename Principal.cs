using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetPatitas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));

            t.Start();

            Thread.Sleep(5550);

            InitializeComponent();

            t.Abort();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.MdiParent = this;
            login.Show();
        }

        public void SplashStart()
        {
            Application.Run(new SplashVeterinaria());
        }

        private void tsCargo_TextChanged(object sender, EventArgs e)
        {
            menuStrip1.Enabled = true;

            if (tsCargo.Text.Equals("Administrador"))
            {
                menuConfiguracion.Visible = true;
            }
            else
            {
                menuConfiguracion.Visible = false;
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = this.MdiChildren.FirstOrDefault(x => x is Empleado);

            if (existe == null)
            {
                Empleado empleado = new Empleado();
                empleado.MdiParent = this;
                empleado.Show();
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = this.MdiChildren.FirstOrDefault(x => x is Cliente);

            if (existe == null)
            {
                Cliente cliente = new Cliente();
                cliente.MdiParent = this;
                cliente.Show();
            }
        }
    }
}
