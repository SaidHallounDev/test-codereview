using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using test_codereview.Dto;

namespace test_codereview.Infrastructure.Persistence
{
    public class DatabaseContext
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseContext()
        {

            /*
             * El siguiente codigo no esta optimizado, no implementa el using, y ademas no se como se crea el
             * archivo .db llamado cotizaciones.db, que es ahi adentro donde se crea la tabla Cotizaciones2
             * Ademas cada vez que se instnacia se esta revisando si existe la tabla Cotizaciones2 e inserta
             * un registro.
             * En terminos generales tengo que ver como lo implemente en ConfigmanagerApi, o ver algun video de mila
             */

            _dbConnection = new SqliteConnection("Data Source=cotizaciones.db");
            _dbConnection.Open();

            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Cotizaciones2 (
                Currency TEXT NOT NULL,
                Buy TEXT NOT NULL,
                Sell TEXT NOT NULL
            )";

            _dbConnection.Execute(createTableQuery);

            var nuevaCotizacion = new
            {
                Buy = "73,19",
                Sell = "73,22",
                Currency = "Real"
            };

            _dbConnection.Execute("INSERT INTO Cotizaciones2 (Currency, Buy, Sell) VALUES (@Currency, @Buy, @Sell)", nuevaCotizacion);
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
    }
}

