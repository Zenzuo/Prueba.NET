using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using capaNegocio;

namespace Interfaz
{
    public partial class frmModuloAdministrativo : Form
    {
        Negocio Data = new Negocio();

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public frmModuloAdministrativo()
        {
            try
            {
                InitializeComponent();
                cargarCombos();
                buscarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
            
        }
        #region eventos
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtNumero.Text = "";
                txtHoraSalida.Text = "";
                txtHoraLlegada.Text = "";
                txtFechaSalida.Text = "";
                txtFechaLlegada.Text = "";
                cmbAerolinea.SelectedIndex = 0;
                cmbCiudadDestino.SelectedIndex = 0;
                cmbCiudadOrigen.SelectedIndex = 0;
                cmbEstado.SelectedIndex = 0;
                BtnActualizar.Enabled = false;

                cargarCombos();
                buscarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                int val = validaciones();

                if (val == 0)
                {
                    string aerolinea = "", origen = "", destino = "", estado = "", fechaSal = "", fechaLleg = "";
                    aerolinea = cmbAerolinea.SelectedText.Substring(0, 1);
                    origen = cmbAerolinea.SelectedText.Substring(0, 1);
                    destino = cmbAerolinea.SelectedText.Substring(0, 1);
                    estado = cmbAerolinea.SelectedText.Substring(0, 1);
                    fechaSal = txtFechaSalida.Text + " " + txtHoraSalida.Text;
                    fechaLleg = txtFechaLlegada.Text + " " + txtHoraLlegada.Text;

                    Data.insertVuelo(aerolinea, origen, destino, fechaSal, fechaLleg, estado);
                    MessageBox.Show("Datos Grabados con exito");
                    BtnNuevo_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw;
            }
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int val = validaciones();

                if (val == 0)
                {
                    string aerolinea = "", origen = "", destino = "", estado = "", fechaSal = "", fechaLleg = "";
                    aerolinea = cmbAerolinea.SelectedText.Substring(0, 1);
                    origen = cmbAerolinea.SelectedText.Substring(0, 1);
                    destino = cmbAerolinea.SelectedText.Substring(0, 1);
                    estado = cmbAerolinea.SelectedText.Substring(0, 1);
                    fechaSal = txtFechaSalida.Text + " " + txtHoraSalida.Text;
                    fechaLleg = txtFechaLlegada.Text + " " + txtHoraLlegada.Text;

                    Data.updateVuelo(txtNumero.Text,aerolinea, origen, destino, fechaSal, fechaLleg, estado);
                    MessageBox.Show("Datos Actualizados con exito");
                    BtnNuevo_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                throw;
            }
        }

        #endregion

        #region metodos
        public void cargarCombos()
        {
            
            dt = Data.buscarCiudades();
            int cont = 0;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {

                    cmbCiudadDestino.Items.Insert(cont, row[0].ToString() + " - " + row[1].ToString());
                    cmbCiudadOrigen.Items.Insert(cont, row[0].ToString() + " - " + row[1].ToString());

                    cont ++;
                }
            }

            dt1 = Data.buscarAerolineas();
            cont = 0;
            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {

                    cmbAerolinea.Items.Insert(cont, row[0].ToString() + " - " + row[1].ToString());

                    cont++;
                }
            }

        }
        public void buscarRegistros()
        {
            dt2 = Data.buscarVuelos();
            if (dt2 != null)
            {
                grdVuelos.DataSource = dt2;
                txtNumero.Text = Data.buscarUltimoVuelo();

            }
            else
            {
                txtNumero.Text = "1";
            }
            
        }
        public int validaciones()
        {
            if (cmbAerolinea.SelectedText == "")
            {
                MessageBox.Show("Seleccione una aerolinea");
                return 1;
            }
            if (cmbCiudadOrigen.SelectedText == "")
            {
                MessageBox.Show("Seleccione una ciudad origen");
                return 1;
            }
            if (cmbCiudadDestino.SelectedText == "")
            {
                MessageBox.Show("Seleccione una ciudad destino");
                return 1;
            }
            if (cmbEstado.SelectedText == "")
            {
                MessageBox.Show("Seleccione un estado");
                return 1;
            }


            if (txtFechaSalida.Text == "")
            {
                MessageBox.Show("Digite una fecha de salida");
                return 1;
            }
            if (txtHoraSalida.Text == "")
            {
                MessageBox.Show("Digite una hora de salida");
                return 1;
            }
            if (txtFechaLlegada.Text == "")
            {
                MessageBox.Show("Digite una fecha de llegada");
                return 1;
            }
            if (txtHoraLlegada.Text == "")
            {
                MessageBox.Show("Digite una hora de llegada");
                return 1;
            }
            return 0;
        }


        #endregion

        
    }
}
