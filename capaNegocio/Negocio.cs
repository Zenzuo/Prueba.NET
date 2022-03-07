using System;
using System.Data;
using capaBD;

namespace capaNegocio
{
    public class Negocio
    {
        conexion conexion = new conexion();
        string SQL;
        DataTable dt1 = new DataTable();

        public void conectar()
        {
            conexion.abrirConexion();
        }
        public DataTable buscarUsuario(string USID)
        {

            SQL = "SELECT USID, USNOMBRE, USCLAVE FROM Usuarios WHERE USID = '" + USID + "' ";

            return conexion.consultarDT(SQL);
        }
        public DataTable buscarCiudades()
        {
            SQL = "SELECT CIID, CINOMBRE, CIESTADO FROM CIUDADES";
            return conexion.consultarDT(SQL);
        }
        public DataTable buscarVuelos()
        {
            SQL = "SELECT VSNUMERO, VSAEROLINEA, VSCIUDADORI, VSCIUDADDES, VSFECHASAL, VSFECHALLEG, VSESTADO FROM VUELOS";
            return conexion.consultarDT(SQL);
        }
        public string buscarUltimoVuelo()
        {
            SQL = "SELECT MAX(VSNUMERO) + 1 FROM VUELOS";

            dt1 = conexion.consultarDT(SQL);
            string ultimoVuelo = "";
            foreach (DataRow row in dt1.Rows)
            {
                ultimoVuelo = row[0].ToString();
            }

            return ultimoVuelo;
        }
        public DataTable buscarAerolineas()
        {
            SQL = "SELECT * FROM Aerolineas";
            return conexion.consultarDT(SQL);

        }
        public int insertVuelo(String VSAEROLINEA, string VSCIUDADORI, string VSCIUDADDES, string VSFECHASAL, string VSFECHALLEG, string VSESTADO)
        {
            SQL = "INSERT INTO VUELOS (VSAEROLINEA, VSCIUDADORI, VSCIUDADDES, VSFECHASAL, VSFECHALLEG, VSESTADO) " +
                "VALUES ('" + VSAEROLINEA + "','" + VSCIUDADORI + "','" + VSCIUDADDES + "','" + VSFECHASAL + "','"+ VSFECHALLEG + "','" + VSESTADO + "')";
            conexion.execute(SQL);
            return 1;
        }

        public int updateVuelo(string VSNUMERO, String VSAEROLINEA, string VSCIUDADORI, string VSCIUDADDES, string VSFECHASAL, string VSFECHALLEG, string VSESTADO)
        {
            SQL = "UPDATE VUELOS SET VSAEROLINEA = '" + VSAEROLINEA + "', VSCIUDADORI = '" + VSCIUDADORI + "', VSCIUDADDES = '" + VSCIUDADDES + "', " +
                "VSFECHASAL = '" + VSFECHASAL + "', VSFECHALLEG = '" + VSFECHALLEG + "', VSESTADO = '" + VSESTADO + "') WHERE VSNUMERO = '"+ VSNUMERO + "' ";
            conexion.execute(SQL);
            return 1;
        }
    }
}
