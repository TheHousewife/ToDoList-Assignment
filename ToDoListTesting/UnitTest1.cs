using ToDoList;
namespace ToDoListTesting
{
    public class ToDoListTests
    {
        private ToDoListLogic _ToDoListLogic;
        public ToDoListTests()
        {
            _ToDoListLogic = new ToDoListLogic();
        }

        [Fact]
        public void AddTask_ShouldAddTaskToList()
        {
            var task = "Test task";
            _ToDoListLogic.AddTask(task);
            var tasks = _ToDoListLogic.GetAllTasks();
            Assert.Contains(task, tasks);
        }

        [Fact]
        public void RemoveTask_ShouldRemoveTaskFromList()
        {
            var task = "Task to remove";
            _ToDoListLogic.AddTask(task);
            _ToDoListLogic.RemoveTask(0);
            var tasks = _ToDoListLogic.GetAllTasks();
            Assert.DoesNotContain(task, tasks);
        }

        [Fact]

        public void RemoveTask_InvalidIndex_ShouldNotThrowException()
        {
            var task = "Valid task";
            _ToDoListLogic.AddTask(task);
            _ToDoListLogic.RemoveTask(10); //Invalid index
            var tasks = _ToDoListLogic.GetAllTasks();
            Assert.Single(tasks); //this task should still exist
        }
    }
}