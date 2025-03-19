using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using MongoDB.Driver;
[ApiController]
[Route("conexion")]
public class Conexion : Controller{
    [HttpGet("sql")]
public IActionResult ListarCarrerasSql(){
   List<CarrerasSQL> lista = new List<CarrerasSQL>();

    SqlConnection conn = new SqlConnection(CadenaConexion.SQL_SERVER);
    SqlCommand cmd = new SqlCommand("select IdCarrera, Carrera  from Carreras");
    cmd.Connection = conn;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.Connection.Open();

    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read()) {
        CarrerasSQL carrera = new CarrerasSQL();
        carrera.IdCarrera = reader.GetInt16("IdCarrera");
        carrera.Carrera = reader.GetString("Carrera");

        lista.Add(carrera);
    }

    reader.Close();
    conn.Close();

    return Ok(lista);
}

   [HttpGet("mongo")]
    public IActionResult ListarSalonesMongoDb(){
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Practica2_Amarildo_Juan");
        var collection = db.GetCollection<SalonMongo>("Salones");

        var lista = collection.Find(FilterDefinition<SalonMongo>.Empty).ToList();

        return Ok(lista);
    }
}