using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI
{
    static class ConnectBanco
    {
        // Declarei 4 variaveis declaras passando as informações para conectar ao banco de dados local.

        private const string servidor = "localhost";
        private const string bancoDados = "crudDB";
        private const string usuario = "root";
        private const string senha = "andrew10";

        //declarando a variavei Connect onde irá acontecer a conexão com o banco de dados.
       static public string Connect = $"server={servidor}; user id={usuario}; database={bancoDados}; password={senha}";
    }
}
