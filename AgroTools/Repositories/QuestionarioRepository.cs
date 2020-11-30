using AgroTools.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgroTools.Repositories
{
    public class QuestionarioRepository
    {
        public SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();

        public int Registrar(Questionario questionario)
        {
            string chars = "abcdefghjkmnpqrstuvwxyz0123456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < 12; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }
            questionario.Url = pass;
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Questionarios(Titulo,URL,Descricao,ID_Usuario) values (@titulo,@url,@descricao,@id_user)";
                    cmd.Parameters.AddWithValue("@titulo", questionario.Titulo);
                    cmd.Parameters.AddWithValue("@url", questionario.Url);
                    cmd.Parameters.AddWithValue("@descricao", questionario.Descricao);
                    cmd.Parameters.AddWithValue("@id_user", questionario.ID_Usuario);

                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                connection.Close();
            }
            return buscar(questionario.Url).ID;
        }

        public Questionario buscar(string url)
        {
            Questionario questionario = new Questionario();
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
               
                    var cmd = connection.CreateCommand();             
                
                    cmd.CommandText = "SELECT * FROM Questionarios WHERE URL = @url;";
                    cmd.Parameters.AddWithValue("@url", url);

                using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questionario.ID = Convert.ToInt32(reader.GetString(0));
                            questionario.Titulo = reader.GetString(1);
                            questionario.Url =reader.GetString(2);
                            questionario.Descricao = reader.GetString(3);
                            questionario.ID_Usuario = Convert.ToInt32(reader.GetString(4));

                        return questionario;
                        }
                    }
                connection.Close();
            }
            return null;
        }

        public List<Questionario> ListarQuestionarios(int id)
        {
            List<Questionario> questionarios = new List<Questionario>();

            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Questionarios WHERE ID_Usuario = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Questionario questionario = new Questionario();
                        questionario.ID = Convert.ToInt32(reader.GetString(0));
                        questionario.Titulo = reader.GetString(1);
                        questionario.Url = reader.GetString(2);
                        questionario.Descricao = reader.GetString(3);
                        questionario.ID_Usuario = Convert.ToInt32(reader.GetString(4));

                        questionarios.Add(questionario);
                    }
                }
                connection.Close();
            }
            return questionarios;
        }

        public void NovaPergunta(PerguntaModel pergunta) 
        {
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO Perguntas(Pergunta,DataCricao,TipoResposta,Ordem,ID_Quest) values (@pergunta,@data,@tipo,@ordem,@id_quest)";
                    cmd.Parameters.AddWithValue("@pergunta", pergunta.Pergunta) ;
                    cmd.Parameters.AddWithValue("@data", pergunta.DataCricao);
                    cmd.Parameters.AddWithValue("@tipo", pergunta.TipoResposta);
                    cmd.Parameters.AddWithValue("@ordem", pergunta.Ordem);
                    cmd.Parameters.AddWithValue("@id_quest", pergunta.ID_Questionario);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<PerguntaModel> ListarPerguntas(int ID_Quest)
        {
            List<PerguntaModel> ListaPerguntas = new List<PerguntaModel>();
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Perguntas WHERE ID_Quest = @id_quest;";
                cmd.Parameters.AddWithValue("@id_quest", ID_Quest);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PerguntaModel pergunta = new PerguntaModel();

                        pergunta.ID = Convert.ToInt32(reader.GetString(0));
                        pergunta.Pergunta = reader.GetString(1);
                        pergunta.DataCricao = Convert.ToDateTime(reader.GetString(2));
                        pergunta.TipoResposta = reader.GetString(3);
                        pergunta.Ordem = Convert.ToInt32(reader.GetString(4));
                        pergunta.ID_Questionario = Convert.ToInt32(reader.GetString(5));

                        ListaPerguntas.Add(pergunta);
                    }
                }
                connection.Close();
            }
            return ListaPerguntas;
        }

        public void NovaResposta(Resposta resposta)
        {
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Respostas(ID_Pergunta,Email,ID_Questionario,Resposta) values (@id_pergunta,@email,@id_quest,@resposta)";
                cmd.Parameters.AddWithValue("@id_pergunta", resposta.ID_Pergunta);
                cmd.Parameters.AddWithValue("@email", resposta.Email);
                cmd.Parameters.AddWithValue("@id_quest", resposta.ID_Quest);
                cmd.Parameters.AddWithValue("@resposta", resposta.resposta);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Respondido(Respondido respondido)
        {
            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Respondidos(ID_Questionario,Email) values (@id_quest,@email)";
                cmd.Parameters.AddWithValue("@id_quest", respondido.ID_Quest);
                cmd.Parameters.AddWithValue("@email", respondido.Email);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Respondido> ListarRespondidos(int id)
        {
            List<Respondido> lista = new List<Respondido>();

            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Respondidos WHERE ID_Questionario = @id_quest;";
                cmd.Parameters.AddWithValue("@id_quest", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Respondido respondido = new Respondido();

                        respondido.ID = Convert.ToInt32(reader.GetString(0));
                        respondido.ID_Quest = Convert.ToInt32(reader.GetString(1));
                        respondido.Email = reader.GetString(2);

                        lista.Add(respondido);
                    }
                }
                connection.Close();
            }
            return lista;
        }

        public List<Resposta> ListarRespostas(int id)
        {
            List<Resposta> lista = new List<Resposta>();

            connectionStringBuilder.DataSource = "Database/agrotools.db";
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT * FROM Respostas WHERE ID_Questionario = @id_quest;";
                cmd.Parameters.AddWithValue("@id_quest", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Resposta resposta = new Resposta();

                        resposta.ID = Convert.ToInt32(reader.GetString(0));
                        resposta.ID_Pergunta = Convert.ToInt32(reader.GetString(1));
                        resposta.Email = reader.GetString(2);
                        resposta.ID_Quest = Convert.ToInt32(reader.GetString(3));
                        resposta.resposta = reader.GetString(4);

                        lista.Add(resposta);
                    }
                }
                connection.Close();
            }
            return lista;
        }
    }
}
