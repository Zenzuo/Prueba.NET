using System;
using System.Data;
using capaBD;

namespace capaNegocio
{
    public class Negocio
    {
        conexion conexion = new conexion();
        string SQL;
        public void conectar()
        {
            conexion.abrirConexion();
        }
        public DataTable buscarUsuario(string USID)
        {

            SQL = "SELECT USID, USNOMBRE, USCLAVE FROM Usuarios WHERE USID = '" + USID + "' ";

            return conexion.consultarDT(SQL);
        }
    }
}
