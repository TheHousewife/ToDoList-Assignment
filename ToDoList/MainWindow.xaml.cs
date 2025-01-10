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
            TaskTextBox.Text = "Enter a task...";
        }

        private const string PlaceholderText = "Enter a task...";

        private void TaskTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskTextBox.Text == PlaceholderText)
            {
                TaskTextBox.Text = string.Empty;
                TaskTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void TaskTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTextBox.Text))
            {
                TaskTextBox.Text = PlaceholderText;
                TaskTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;

            if (!string.IsNullOrEmpty(task))
            {
                _ToDoListLogic.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
                TaskTextBox.Text = "Enter a task...";
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