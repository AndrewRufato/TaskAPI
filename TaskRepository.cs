using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;


namespace TasksAPI
{
   public class TaskRepository : ITaskRepository
    {

        private readonly string _connectionString;

        public TaskRepository(string connectionString) {
            _connectionString = connectionString;
        }
        private MySqlConnection createConnection(string conectionString){
            return new MySqlConnection(conectionString);   
        }


       
        public void atualizar(Task task)
        {
            using (var connection = createConnection(_connectionString))
            {


                try
                {
                    connection.Open();
                    var query = $"UPDATE task SET title = '{task.Title}', descricao = '{task.Descricao}', duedate = '{task.Duedate}', priority = '{task.Priority}' WHERE id = '{task.Id}'";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    var reader = command.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {

                   Console.WriteLine(ex.Message);
                }
               
              
            }
        }

        public void gravar(Task task)
        {
            using (var connection = createConnection(_connectionString))
            {
                connection.Open();
                var query = $"insert into task (id, title, descricao, duedate, priority) values ('{task.Id}', '{task.Title}', '{task.Descricao}', '{task.Duedate}', '{task.Priority}')";
                Console.WriteLine(query);
                MySqlCommand command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();
                connection.Close();

            }
        }

        public List<Task> listar()
        {
            using (var connection = createConnection(_connectionString)) {
                var query = "select * from task";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                var reader = command.ExecuteReader();
           
                List<Task> list = new List<Task>();
                while (reader.Read())
                {
                  Task item = new Task(reader.GetString("Id"), reader.GetString("title"), reader.GetString("descricao"), reader.GetString("duedate"), reader.GetString("priority"));
                  list.Add(item);
                }
                connection.Close();
                return list;
            }
        }

        public bool remover(string id)
        {
            using (var connection = createConnection(_connectionString))
            {
                
                try
                {
                    connection.Open();
                    var query = $"delete from task where id = '{id}'";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    var reader = command.ExecuteReader();
                    connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    connection.Close();
                    return false;
                    
                }  
            }
        }
    }
}
