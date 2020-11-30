using AgroTools.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.Repositories
{  
    public class UsuarioRepository
    {
        public const string PATH = "Database/agrotools.db";
        public SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();
        public UsuarioRepository()
        {
            if (!File.Exists(PATH))
            {
                connectionStringBuilder.DataSource = "Database/agrotools.db";
                using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();

                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuarios(ID INTEGER PRIMARY KEY,Nome VARCHAR(255),Email VARCHAR(255),Senha VARCHAR(255))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Questionarios(ID INTEGER PRIMARY KEY,Titulo VARCHAR(255),URL VARCHAR(255),Descricao TEXT, ID_Usuario INTEGER)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Perguntas(ID INTEGER PRIMARY KEY,Pergunta TEXT,DataCricao Datetime,TipoResposta TEXT,Ordem INTEGER,ID_Quest INTEGER)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Respostas(ID INTEGER PRIMARY KEY,ID_Pergunta INTEGER,Email VARCHAR(255),ID_Questionario INTEGER,Resposta TEXT)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Respondidos(ID INTEGER PRIMARY KEY,ID_Questionario INTEGER, Email VARCHAR(255))";
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                }
            }

       
        public void Cadastro(Usuario usuario)
        {
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO Usuarios(Email,Senha,Nome) values (@email,@senha,@nome)";
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                connection.Close();
            }
        }

        public Usuario Login(string email)
        {
            Usuario usuario = new Usuario();
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT Email,Senha,Nome,ID FROM Usuarios WHERE Email = @email;";
                selectCmd.Parameters.AddWithValue("@email", email);

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario.Email = reader.GetString(0);
                        usuario.Senha = reader.GetString(1);
                        usuario.Nome = reader.GetString(2);
                        usuario.ID = Convert.ToInt32(reader.GetString(3));

                        return usuario;
                    }
                }
                connection.Close();
            }
            return null;
        }
    }
}
