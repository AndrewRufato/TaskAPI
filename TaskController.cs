using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;

namespace TasksAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        public TaskController() {
            _taskService = new TaskService();
        }



        [HttpGet]
        public ActionResult<List<Task>> GetTasks()
        {
           
            var tasks = _taskService.listar();
            return Ok(tasks);
        }



        [HttpDelete("{id}")]
        public ActionResult<List<Task>> RemoveTasks(string id)
        {

            var boole = _taskService.remover(id);

            if (boole == true)
            {

                return Ok("Ação de remover realizada com sucesso");
            }
            else { 
            
                return StatusCode(500);

            }
            
        }




        [HttpPut]
        public ActionResult<List<Task>> UpdateTasks([FromBody] Task task)
        {
     

            _taskService.atualizar(task.Id, task.Title, task.Descricao, task.Duedate, task.Priority);
           
            return Ok();
        }



        [HttpPost]
        public ActionResult CreateTasks([FromBody] RequestBody requestbody)
        {
            _taskService.gravar(requestbody.Title, requestbody.Descricao, requestbody.Duedate, requestbody.Priority);
            return Ok();
        }
    }

}
