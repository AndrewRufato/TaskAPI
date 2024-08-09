using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI
{
    // criando a classe task para poder efetuar as operações CRUD
    public class Task
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Descricao { get; set; }
        public string Duedate { get; set; }
        public string Priority { get; set; }

        // Construtor sem parâmetros
        public Task() { }

        // Construtor com parâmetros
        public Task(string id, string title, string descricao, string duedate, string priority)
        {
            Id = id;
            Title = title;
            Descricao = descricao;
            Duedate = duedate;
            Priority = priority;
        }
    }
}
