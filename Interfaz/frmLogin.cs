using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;

namespace Interfaz
{
    public partial class frmLogin : Form
    {
        Negocio Data = new Negocio();

        public frmLogin()
        {
            InitializeComponent();
        }
#region eventos

#endregion
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Digite un usuario");
                return;
            }
            if (txtClave.Text == "")
            {
                MessageBox.Show("Digite la contraseña");
                return;
            }
            DataTable dt;

            Data.BuscarUsuario(txtUsuario.Text, txtClave.Text);


        }
    }
}
