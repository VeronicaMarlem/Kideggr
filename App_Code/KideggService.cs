﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de KideggService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class KideggService : System.Web.Services.WebService {

    public KideggService () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }
    [WebMethod]
    public string[] accesoA(string u, string p)
    {
        String[] f = new String[4];
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        String Cadsql = "exec CONS_ACCESO1 '" + u + "', '" + p + "'";
        SqlConnection cnn = new SqlConnection(Cc);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandText = Cadsql;
        cmd.CommandType = CommandType.Text;
        cnn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            f[0] = dr.GetValue(0).ToString(); //Nombre
            f[1] = dr.GetValue(3).ToString();//User
            f[2] = dr.GetValue(2).ToString();//Rol
            f[3] = "true";
        }
        else {
            f[0] = "[Inciar Sessión]";
            f[1] = "[Inciar Sessión]";
            f[2] = "[Inciar Sessión]";
            f[3] = "false";
        }
        cnn.Close();
        return f;
    }
    [WebMethod]
    public String[] accesoJ(string u, string p)
    {
        String[] f = new String[4];
        String Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        String Cadsql1 = "exec CONS_ACCESO '" + u + "', '" + p + "'";
        SqlConnection cnn = new SqlConnection(Cc);
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = cnn;
        cmd1.CommandText = Cadsql1;
        cmd1.CommandType = CommandType.Text;
        cnn.Open();
        SqlDataReader dr1 = cmd1.ExecuteReader();
        if (dr1.HasRows)
        {
            dr1.Read();
            f[0] = dr1.GetValue(0).ToString();
            f[1] = dr1.GetValue(3).ToString();
            f[2] = dr1.GetValue(2).ToString();
            f[3] = "true";
        }
        else
        {
            f[0] = "[Inciar Sessión]";
            f[1] = "[Inciar Sessión]";
            f[2] = "[Inciar Sessión]";
            f[3] = "false";
        }
        cnn.Close();
        return f;
    }
    [WebMethod]
    public int insertar(String nombre, String apellidopaterno, String apellidomaterno, String edad, String genero)
    {

        string sql = "insert into niño (niñ_nombre, niñ_apellido_paterno, niñ_apellido_materno, niñ_edad, nin_genero) values ('" + nombre + "','" + apellidopaterno + "','" + apellidomaterno + "','" + edad + "','" + genero + "')";
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        SqlConnection   cadenaconn = new SqlConnection(Cc);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cadenaconn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;

        cadenaconn.Open();
        int resultado = cmd.ExecuteNonQuery();
        cadenaconn.Close();
        return resultado;
    }
    [WebMethod]
    public int eliminar(String clave)
    {

        string sql = "DELETE FROM niño WHERE niñ_cve_niño = '" + clave + "'";
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        SqlConnection cadenaconn = new SqlConnection(Cc);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cadenaconn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;

        cadenaconn.Open();
        int resultado = cmd.ExecuteNonQuery();
        cadenaconn.Close();
        return resultado;
    }
    [WebMethod]
    public int actualizar(String clave, String nombre, String apellidopaterno, String apellidomaterno, String edad, String genero)
    {
        string sql = "UPDATE niño SET NIÑ_NOMBRE = '" + nombre + "' ,NIÑ_APELLIDO_PATERNO = '" + apellidopaterno + "' ,NIÑ_APELLIDO_MATERNO = '" + apellidomaterno + "' ,NIÑ_EDAD = '" + edad + "' ,NIN_GENERO = '" + genero + "' WHERE NIÑ_CVE_NIÑO = '" + clave + "'";
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        SqlConnection cadenaconn = new SqlConnection(Cc);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cadenaconn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;

        cadenaconn.Open();
        int resultado = cmd.ExecuteNonQuery();
        cadenaconn.Close();
        return resultado;
    }
    [WebMethod]
    public DataSet dsNiños() {
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        String strSQL = " select niñ_cve_niño, niñ_nombre, niñ_apellido_paterno, niñ_apellido_materno, niñ_edad, nin_genero ";
        strSQL = strSQL + " from niño ";
        SqlDataAdapter da = new SqlDataAdapter(strSQL, Cc);
        DataSet ds = new DataSet();
        da.Fill(ds, "NIÑO");
        return ds;
    }
    [WebMethod]
    public int insertarPuntaje(int b, int c)
    {
        string sql = "insert into puntaje (PUN_RANKING, JUE_CVE_JUEGO) values (" + b + ", " + c + ")";
        string Cc = "Data Source=HP-BEATS\\SQLEXPRESS; Initial Catalog=KIDEG; User Id=sa; Password=Thekingof02;";
        SqlConnection cadenaconn = new SqlConnection(Cc);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cadenaconn;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        cadenaconn.Open();
        int resultado = cmd.ExecuteNonQuery();
        cadenaconn.Close();
        return resultado;
    }
    
}