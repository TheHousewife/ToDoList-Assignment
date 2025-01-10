namespace ToDoList
{

    //<summary>
    // Handles logic for adding, removing and showing todo items
    //</summary>
    public class ToDoListLogic
    {
        private List<string> tasks = new List<string>();

        public void AddTask(string task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
            }

        }

        public List<string> GetAllTasks()
        {
            return tasks;
        }
    }
}
