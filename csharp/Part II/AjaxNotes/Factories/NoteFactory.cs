using System.Collections.Generic;
using System.Data;
using System.Linq;
using AjaxNotes.Models;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using dbConnection;

namespace AjaxNotes.Factories
{
    public class NoteFactory : IFactory<Note>
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;

        public NoteFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }

        internal IDbConnection Connection
        {
            get { return new MySqlConnection(MySqlConfig.Value.ConnectionString); }
        }

        public List<Note> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = "SELECT * FROM notes";
                dbConnection.Open();
                return dbConnection.Query<Note>(Query).ToList();
            }
        }

        public void Add(Note Item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = "INSERT INTO notes (NoteTitle, NoteContent, CreatedAt, UpdatedAt) VALUES (@NoteTitle, @NoteContent, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(Query, Item);
            }
        }

        public Note GetLatest()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = "SELECT * FROM notes ORDER BY NoteId DESC LIMIT 1";
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Note>(Query);
            }
        }

        public void Update(Note Item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = "UPDATE notes SET NoteContent = @NoteContent WHERE NoteId = @NoteId";
                dbConnection.Open();
                dbConnection.Execute(Query, Item);
            }
        }

        public void Delete(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Query = $"DELETE FROM notes WHERE NoteId = {Id}";
                dbConnection.Open();
                dbConnection.Execute(Query);
            }
        }
    }
}