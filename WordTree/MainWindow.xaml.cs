using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WordTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The parent node which contains all sub-nodes.
        /// </summary>
        private Node firstNode;

        public MainWindow()
        {
            InitializeComponent();
            this.Main();
        }

        /// <summary>
        /// Initialization function.
        /// </summary>
        private void Main() 
        {
            // Create starting node
            this.firstNode = new Node("Tree");
        }

        /// <summary>
        /// Renders the TreeView.
        /// </summary>
        private void Render()
        {
            this.wordTreeView.Items.Clear();
            this.wordTreeView.Items.Add(this.CreateTreeViewItem(firstNode));
        }

        /// <summary>
        /// Creates a TreeViewItem recursively for each item in the node tree.
        /// </summary>
        /// <param name="currentNode">The current node to create an item from</param>
        /// <returns>The TreeViewItem created</returns>
        private TreeViewItem CreateTreeViewItem(Node currentNode)
        {
            TreeViewItem result = new TreeViewItem
            {
                Header = currentNode.Value
            };

            foreach (Node node in currentNode.Children)
            {
                result.Items.Add(this.CreateTreeViewItem(node));
            }

            return result;
        }

        /// <summary>
        /// Adds a word to the word tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addWordButton_Click(object sender, RoutedEventArgs e)
        {
            this.firstNode = Node.AddWord(this.firstNode, this.addWordTextBox.Text);

            // Render
            this.Render();
        }

        /// <summary>
        /// Checks to see if all characters in the text box are alpha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addWordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(this.addWordTextBox.Text, @"^[a-zA-Z]+$"))
            {
                this.addWordButton.IsEnabled = true;
            }
            else
            {
                this.addWordButton.IsEnabled = false;
            }
        }
    }
}
