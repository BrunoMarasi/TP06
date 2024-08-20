using System.Data.SqlClient;
using Dapper;

namespace TP06.Models;

public class BD
{
    private static string _ConnectionString = "Server=localhost;DataBase=TP06;Trusted_Connection=true;";

    //a//
    public static void AgregarDeportista(Deportistas dep)
    {
        string sql = "INSERT INTO Deportistas(idDeportista,apellido,nombre, fechaNacimiento, foto, idPais, idDeporte)";
        using(SqlConnection conn = new SqlConnection(_ConnectionString)) {
            conn.Execute(sql, new {pidDeportista = dep.idDeportista, papellido = dep.apellido, pnombre = dep.nombre, pfechaNacimiento = dep.fechaNacimiento, pfoto = dep.foto, pidPais = dep.idPais, pidDeporte = dep.idDeporte});
        }
    }

    //b//
    public static void EliminarDeportista(int idDeportista)
    {
        string sql = "DELETE FROM Deportistas WHERE idDeportista = @idDeportista";
        using(SqlConnection conn = new SqlConnection(_ConnectionString)) {
            conn.Execute(sql);
        }
    }

    //c//
    public static Deportes verInfoDeporte(int idDeporte)
    {
        using (SqlConnection conn = new SqlConnection(_ConnectionString))
        {
            string sql = "SELECT * FROM Deportes WHERE idDeporte = @idDeporte";
            return conn.QuerySingleOrDefault<Deportes>(sql, new { idDeporte });
        }
    }
    
    //d//
    public static Paises verInfoPais(int idPais)
    {
        using (SqlConnection conn = new SqlConnection(_ConnectionString))
        {
            string sql = "SELECT * FROM Paises WHERE idPais = @idPais";
            return conn.QuerySingleOrDefault<Paises>(sql, new { idPais });
        }
    }
    
    //e//
    public static Deportistas verInfoDeportistas(int idDeportista)
    {
        using (SqlConnection conn = new SqlConnection(_ConnectionString))
        {
            string sql = "SELECT * FROM Deportistas WHERE idDeportista = @idDeportista";
            return conn.QuerySingleOrDefault<Deportistas>(sql, new { idDeportista });
        }
    }


    //f//
    public static List<Deportes> listarDeportes()
    {
        List<Deportes> listaDeportes = new List<Deportes>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT * FROM Deportes";
            listaDeportes = conn.Query<Deportes>(sql).ToList();
        }
        return listaDeportes;
    }
    public static List<Paises> listarPaises()
    {
        List<Paises> listaPaises = new List<Paises>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT * FROM Paises";
            listaPaises = conn.Query<Paises>(sql).ToList();
        }
        return listaPaises;
    }

    //g//
    public static List<Deportistas> listarDeportistas1(int idDeporte)
    {
        List<Deportistas> listaDeportistas = new List<Deportistas>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT * FROM Deportistas WHERE idDeporte = @idDeporte";
            listaDeportistas = conn.Query<Deportistas>(sql, new { idDeporte }).ToList();
        }
        return listaDeportistas;
    }

    //h//
    public static List<Deportistas> listarDeportistas2(int idPais)
    {
        List<Deportistas> listaDeportistas = new List<Deportistas>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT * FROM Deportistas WHERE idPais = @idPais";
            listaDeportistas = conn.Query<Deportistas>(sql, new { idPais }).ToList();
        }
        return listaDeportistas;
    }
}