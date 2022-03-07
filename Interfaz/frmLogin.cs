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
        DataTable dt = new DataTable();

        public frmLogin()
        {
            InitializeComponent();

            txtClave.PasswordChar = '*';
        }

        #region eventos
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
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

                dt = Data.buscarUsuario(txtUsuario.Text);

                string clave = "", nombre = "";

                if (dt == null)
                {
                    MessageBox.Show("Usuario no encontrado");
                    return;
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        //row[0].ToString();
                        nombre = row[1].ToString();
                        clave = row[2].ToString();
                    }
                    
                    if (encriptar(txtClave.Text) == clave)
                    {
                        //Iniciar Sesion
                        MessageBox.Show("Bienvenido " + nombre);
                        frmModuloAdministrativo frm = new frmModuloAdministrativo();
                        frmLogin frmLogin = new frmLogin();
                        frmLogin.Close();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta");
                        return;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

        }



        #endregion

        #region metodos
        public string encriptar(string clave)
        {

            int valor;
            int N_clave = 0;

            for (int i = 0; i < clave.Length; i++)
            {
                valor = 0;
                valor = Convert.ToChar(clave.Substring(i, 1));
                N_clave = N_clave + valor;
            }

            N_clave = 5000 - N_clave + clave.Length;

            string c_clave = Convert.ToString(N_clave);

            return c_clave;
        }
        public void limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
        }
        #endregion
    }
}
