namespace TasksAPI.Models
{
    public class RequestBody
    {

        private string title;
        private string descricao;
        private string duedate;
        private string priority;


        //metoods get e set para poder pegar a atribuir os valores da task
       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Duedate
        {
            get { return duedate; }
            set { duedate = value; }
        }
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }

    }
}
