using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;

namespace DojoLeague
{
    public class DataFactory
    {
        private IOptions<MySqlOptions> _connStr;

        public DataFactory(IOptions<MySqlOptions> connStr)
        {
            _connStr = connStr;
        }

        //cs object that is used throughout app as the connection to a specific relational DB
        public IDbConnection Connection
        {
            get
            {
                //when the Connection property is used, it will return a MySqlConnection object configured with the connection string from appsettings.json, passed in thru MySqlOptions by dependency injection
                return new MySqlConnection(_connStr.Value.DefaultConnection);
            }
        }

        //retrieve query using dapper method which returns an IEnum object from DB, which is then cast to a list.
        public List<Ninja> GetNinjas()
        {
            using (IDbConnection connect = Connection)
            {
                var queryString = "SELECT * FROM ninjas";
                var result = Connection.Query<Ninja>(queryString).ToList();
                return result;
            }
        }


        public void AddNinja(Ninja ninja)
        {
            using (IDbConnection connect = Connection)
            {
                var queryString =
                    "INSERT INTO ninjas(name, level, dojo_id, description, createdat, updatedat) VALUES(@name, @level, @dojo_id, @description, now(), now())";
                var result = Connection.Execute(queryString, ninja);
            }
        }

        public List<Dojo> GetDojos()
        {
            using (Connection)
            {
                var queryString = "SELECT * FROM dojos";
                var result = Connection.Query<Dojo>(queryString).ToList();
                return result;
            }
        }

        public void AddDojo(Dojo dojo)
        {
            using (Connection)
            {
                var queryString =
                    "INSERT INTO dojos(name, location, description) VALUES(@name, @location, @description)";
                var result = Connection.Execute(queryString, dojo);

            }
        }

        public IEnumerable<Ninja> GetNinjaById(int id)
        {
            using (Connection)
            {
                var queryString = $"SELECT * FROM ninjas join dojos on ninjas.dojo_id Where dojos.id=ninjas.dojo_id and ninjas.id={id}";
                var result = Connection.Query<Ninja, Dojo, Ninja>(queryString, (ninja, dojo) =>
                {
                    ninja.dojo = dojo;
                    return ninja;
                });
                return result;

            }


        }
        //map to a model with a prop containing a list of other objects. Uses 2 queries and splits
        public Dojo GetDojoById(int id)
        {
            using (Connection)
            {
                var queryString = @"SELECT * FROM dojos WHERE id=@Id; SELECT * FROM ninjas WHERE dojo_id=@Id";
                using (var multi = Connection.QueryMultiple(queryString, new { Id = id }))
                {
                    //takes first row and maps to dojo, and takes the remaining rows and maps to the dojo.Ninjas field
                    var dojo = multi.Read<Dojo>().SingleOrDefault();
                    dojo.Ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }

            }
        }

        public void UpdateNinjaDojo(int id)
        {
            using (Connection)
            {
                var queryString = "UPDATE ninja SET dojo_id=@id";
                Connection.Execute(queryString, new { id });
            }
        }
    }
}