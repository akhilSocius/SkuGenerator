using SKU_Generator.BackEnd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
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
        private ObservableCollection<MyItem> myItems2= new ObservableCollection<MyItem>();
        IEnumerable<string> sourceDataSource = new string[] { "JA Uniforms", "External Vendor" };
        public string connStr =Configuration.ConnectionString;
        public NewSku()
        {
            InitializeComponent();
            myListBox.ItemsSource = myItems;
            myListBox1.ItemsSource = myItems;
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new MyItem { Name = "New Item", IsChecked = false };

            // Add the item to the collection
            myItems.Add(newItem);

            // Refresh the ListBox to display the new item
            myListBox.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SourceCombo.Visibility= Visibility.Visible;
            SourceCombo.ItemsSource = sourceDataSource;




        }

        private void SourceCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VendorCombo.Visibility= Visibility.Visible;
            CategoryCombo.Visibility= Visibility.Visible;
            subCategoriesCombo.Visibility= Visibility.Visible;
            LogoCodeCombo.Visibility= Visibility.Visible;
            GetVendors();
            getItemGroups();
            getSubCategories();
            getLogoCodes();
            getOpCodes();
            getSecondSizes();



        }
        private void GetVendors()
        {
            SkuConstructor.vendors.Clear();
            VendorCombo.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand("select distinct CompanyName,Abbr,id from SkuVendorInfo Order By id", conn))
                {
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SkuConstructor.vendors.Add(dr[0].ToString());
                        }


                        VendorCombo.ItemsSource = SkuConstructor.vendors;
                        VendorCombo.SelectedIndex = 0;


                    }
                    else
                    {
                        MessageBox.Show("No Vendors Found");
                    }
                }
                conn.Close();
            }
        }
        private void getItemGroups()
        {
            CategoryCombo.ItemsSource = null;
            string query = $"select value from SKU_Categories";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(query, conn))
                {
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SkuConstructor.category.Add(dr[0].ToString());

                        }


                        CategoryCombo.ItemsSource = SkuConstructor.category;
                    }
                    else
                    {
                        MessageBox.Show("No Categories found, contact your administrator", "Alert");
                    }
                }
                conn.Close();
            }
        }
        private void getSubCategories()
        {
            subCategoriesCombo.ItemsSource = null;

            string query = $"select value from SKU_Categories_Sub";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(query, conn))
                {
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SkuConstructor.subCategory.Add(dr[0].ToString());

                        }

                        subCategoriesCombo.ItemsSource = SkuConstructor.subCategory;

                    }
                    else
                    {
                        MessageBox.Show("No Sub Categories found, contact your administrator");
                    }
                }
                conn.Close();
            }
        }
        private void getLogoCodes()
        {
            LogoCodeCombo.ItemsSource = null;
            SkuConstructor.logoCodes.Clear();
            SkuConstructor.selectedLogoCodes.Clear();

            string query = $"select value from SKU_LogoCodes";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(query, conn))
                {
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SkuConstructor.logoCodes.Add(dr[0].ToString());
                            SkuConstructor.selectedLogoCodes.Add(dr[0].ToString());

                        }

                        LogoCodeCombo.ItemsSource = SkuConstructor.logoCodes;
                        LogoCodeCombo.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("No Sub Categories found, contact your administrator");
                    }
                }
                conn.Close();
            }
        }
        private void getOpCodes()
        {
            subCategoriesCombo.ItemsSource = null;
            SkuConstructor.operationCodes.Clear();
            SkuConstructor.selectedOperationCodes.Clear();

            string query = $"select value from SKU_OperationCodes";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand com = new SqlCommand(query, conn))
                {
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SkuConstructor.operationCodes.Add(dr[0].ToString());
                            SkuConstructor.selectedOperationCodes.Add(dr[0].ToString());
                        }

                        OperationCodeCombo.ItemsSource = SkuConstructor.operationCodes;
                        OperationCodeCombo.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("No Sub Categories found, contact your administrator");
                    }
                }
                conn.Close();
            }
        }
        private void getSecondSizes()
        {
            try
            {
                //checkedListBoxSecondSizes.Items.Clear();

                SkuConstructor.secondSizes.Clear();
                SkuConstructor.secondSizesParam.Clear();
                SkuConstructor.selectedSecondSizes.Clear();
                SkuConstructor.selectedSecondSizesParam.Clear();


                string validColors = string.Join(",", SkuConstructor.selectedColorsParam);

                string query = $"select value from SKU_SecondSizeMap";


                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    MyItem myItem = new MyItem();
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        SqlDataReader dr = com.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                SkuConstructor.secondSizes.Add(dr[0].ToString());
                                myItem.Name = dr[0].ToString();
                                


                            }
                            myItems2.Add(myItem);
                            myListBox2.ItemsSource= myItems2;



                        }
                        else
                        {
                            MessageBox.Show("No Sizes found for selected Vendor, Style, and Color(s)", "Alert");
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
    public class MyItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }=false;
    }
}
