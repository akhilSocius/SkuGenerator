using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SKU_Generator.MVMM.View
{
    /// <summary>
    /// Interaction logic for NewSku.xaml
    /// </summary>
    public partial class NewSku : UserControl
    {
        private ObservableCollection<MyItem> myItems = new ObservableCollection<MyItem>();
        public NewSku()
        {
            InitializeComponent();
            myListBox.ItemsSource = myItems;
            myListBox1.ItemsSource = myItems;
            myListBox2.ItemsSource = myItems;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new MyItem { Name = "New Item", IsChecked = false };

            // Add the item to the collection
            myItems.Add(newItem);

            // Refresh the ListBox to display the new item
            myListBox.Items.Refresh();
        }
    }
    public class MyItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
