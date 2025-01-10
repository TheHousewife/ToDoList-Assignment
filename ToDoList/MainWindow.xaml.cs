using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ToDoListLogic _ToDoListLogic;
        public MainWindow()
        {
            InitializeComponent();
            _ToDoListLogic = new ToDoListLogic();
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;

            if (!string.IsNullOrEmpty(task))
            {
                _ToDoListLogic.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }


        }
        //adds the task and clears the textbox

        private void UpdateTaskList()
        {
            TasksListBox.Items.Clear();
            foreach (var task in _ToDoListLogic.GetAllTasks())
            {
                TasksListBox.Items.Add(task);
            }
        }
        //Updates the list of tasks by clearing out the old list and updating it with the new items

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedIndex >= 0)
            {
                _ToDoListLogic.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();

            }
        }
        //removes the task at the selected index and then updates the list

    }
}