using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI
{
    internal class TaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService() {

            taskRepository = new TaskRepository(ConnectBanco.Connect);    
        
        }

        public List<Task> listar() {

            return taskRepository.listar();
        }
        public void gravar(string title, string descricao, string duedate, string priority) {
            Guid id = Guid.NewGuid();
            Task task = new Task(id.ToString(), title, descricao, duedate, priority); 


            taskRepository.gravar(task);
        }
        public void atualizar(string id, string title, string descricao, string duedate, string priority) {
            Task task = new Task(id,title, descricao, duedate, priority);
            taskRepository.atualizar(task);
         
        }
        public bool remover(string id) {

            return taskRepository.remover(id);
        }

    }
}
