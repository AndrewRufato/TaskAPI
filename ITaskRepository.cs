using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI

{
	public interface ITaskRepository
	{
        void gravar(Task task);
        void atualizar(Task task);
        bool remover(string id);
        List<Task> listar();
    }
}
