using SKU_Generator.BackEnd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
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
using static SKU_Generator.BackEnd.B1RestClient;

namespace SKU_Generator.MVMM.View
{
    /// <summary>
    /// Interaction logic for NewSku.xaml
    /// </summary>
    public partial class NewSku : UserControl
    {
        IList<object> colorList = new List<object>();
        IList<object>sizeList=new List<object>();
        IList<object> size2List = new List<object>();
        IEnumerable<string> sourceDataSource = new string[] { "Blank", "SKU matrix" };
        IEnumerable<string> genderComboSource = new string[] { "M","F","US" }; 
        IEnumerable<string> InventoryNameSource = new string[] { "Yes", "No" }; 
 
        public string connStr =Configuration.ConnectionString;
        public NewSku()
        {
            InitializeComponent();
           
          
            InventoryName.ItemsSource = InventoryNameSource;
            genderCombo.ItemsSource= genderComboSource;
            InventoryItemCombo.ItemsSource= InventoryNameSource;
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
           
            GetVendors();
            getItemGroups();
            getSubCategories();
            getOpCodes();
            getSecondSizes();



        }
        private void GetVendors()
        {
            SkuConstructor.vendors.Clear();
            VendorCombo.ItemsSource = null;
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
     
        private void getOpCodes()
        {
            OperationCodeCombo.Visibility = Visibility.Visible;
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
                        foreach(string i in SkuConstructor.operationCodes)
                        {
                            OperationCodeCombo.Items.Add(i);
                        }
                      
                        OperationCodeCombo.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("No operation code found, contact your administrator");
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
                Size2Box.Items.Clear();

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
                              
                                


                            }
                            foreach (string i in SkuConstructor.secondSizes)
                            {
                                Size2Box.Items.Add(new Projects()
                                {
                                    Code = i
                                });
                            }



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

        private void VendorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VendorCombo.SelectedItem != null)
            {
                SkuConstructor.vendorName = VendorCombo.SelectedItem.ToString();
                if (SkuConstructor.vendorName != "-Select-")
                {
                    vendorSelected();
                }
            }
        }

        private void vendorSelected()
        {
            try
            {
                string query = $"select top 1 Abbr from SkuVendorInfo where CompanyName = '{SkuConstructor.vendorName}'";

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
                                SkuConstructor.vendorAbbr = dr[0].ToString();
                            }

                        }
                    }
                    conn.Close();
                }
                //getVendorTable();

                GetStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetStyles()
        {
            StylesCombo.ItemsSource = null;
            SkuConstructor.styles.Clear();
            


            string query = $"select distinct STYLE from StyleMaster WHERE CompanyName = '{SkuConstructor.vendorName}' order by STYLE";
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
                            SkuConstructor.styles.Add(dr[0].ToString());
                        }


                        StylesCombo.ItemsSource = SkuConstructor.styles;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No Styles found for selected vendor", "Alert");
                    }
                }
                conn.Close();
            }



        }

        private void StylesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxDescr.Text = null;

            try
            {
                SkuConstructor.styleName = StylesCombo.SelectedItem.ToString();


                string query = $"select top 1 StyleName from StyleMaster WHERE ISNULL(StyleName,'')!='' and CompanyName = '{SkuConstructor.vendorName}' and STYLE = '{SkuConstructor.styleName}'";
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
                                TextBoxDescr.Text = dr[0].ToString();
                            }
                        }
                        else
                        {
                            TextBoxDescr.Text = "No Style description found";
                        }
                    }
                    conn.Close();
                }


            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

           refreshColor();
        }
        private async void refreshColor()
        {
            try
            {

                ColorBox.Items.Clear();

                SkuConstructor.colors.Clear();
                SkuConstructor.colorsParam.Clear();
                SkuConstructor.selectedColors.Clear();
                SkuConstructor.selectedColorsParam.Clear();
                //mainCList.Clear();
                //newCList.Clear();




                //  string query = $"select distinct ColorName from StyleMaster WHERE CompanyName = '{SkuConstructor.vendorName}' and STYLE = '{SkuConstructor.styleName}' ORDER BY ColorName";
                string query = $"select distinct ColorName from StyleMaster WHERE CompanyName = 'SANMAR' and STYLE = '054X' ORDER BY ColorName";
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
                                SkuConstructor.colors.Add(dr[0].ToString());
                                
                            }
                            foreach (string i in SkuConstructor.colors)
                            {
                                ColorBox.Items.Add(new Projects()
                                {
                                    Code =i


                                });
                            }



                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No Colors found for selected Style", "Alert");
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SizeBox.Items.Clear();

            //refresh selected colors
            SkuConstructor.selectedColors.Clear();
            SkuConstructor.selectedColorsParam.Clear();
            // Determine if there are any items checked.  
            if (colorList.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                for (int x = 0; x < colorList.Count; x++)
                {
                    string? color = colorList[x].ToString();
                    if (color != null)
                    {
                        SkuConstructor.selectedColors.Add(color);
                        SkuConstructor.selectedColorsParam.Add($"'{color}'");
                    }
                }

                if (LockColors.Content.ToString() == "Lock Colors")
                {
                    LockColors.Content = "Unlock Colors";
                    ColorBox.IsEnabled = false;
                    ColorsSelectAll.IsEnabled = false;
                }
                else
                {
                    LockColors.Content = "Lock Colors";
                    ColorBox.IsEnabled = true;
                    ColorsSelectAll.IsEnabled = true;
                }
                //get new size list for vendor, style, and selected colors
                colorSelected();

            }
        }
        private void colorSelected()
        {
            try
            {
                SkuConstructor.sizes.Clear();
                SkuConstructor.sizesParam.Clear();
                SkuConstructor.selectedSizes.Clear();
                SkuConstructor.selectedSizesParam.Clear();


                string validColors = string.Join(",", SkuConstructor.selectedColorsParam);

                string query = $"select distinct SIZE from StyleMaster where STYLE = '{SkuConstructor.styleName}' and ColorName IN ({validColors}) ";


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
                                SkuConstructor.sizes.Add(dr[0].ToString());                               
                            }
                            foreach (string i in SkuConstructor.sizes)
                            {
                                SizeBox.Items.Add(new Projects()
                                {
                                    Code = i
                                });
                            }



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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Projects test = ColorBox.SelectedItem as Projects;
            string Code = test.Code;
            colorList.Add(Code);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Projects? test = ColorBox.SelectedItem as Projects;
            if (test != null)
            {
                string Code = test.Code;
                colorList.Remove(Code);
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Projects test = SizeBox.SelectedItem as Projects;
            string Code = test.Code;
            sizeList.Add(Code);
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Projects? test = SizeBox.SelectedItem as Projects;
            if (test != null)
            {
                string Code = test.Code;
                sizeList.Remove(Code);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //refresh size list
            SkuConstructor.selectedSizes.Clear();
            SkuConstructor.selectedSizesParam.Clear();
            if (sizeList.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                for (int x = 0; x < sizeList.Count; x++)
                {
                    string? size = sizeList[x].ToString();
                    if (size != null)
                    {
                        SkuConstructor.selectedSizes.Add(size);
                        SkuConstructor.selectedSizesParam.Add($"'{size}'");
                    }
                }

                if (Lock1Size.Content.ToString() == "Lock 1st Sizes")
                {
                    SizeBox.IsEnabled = false;
                    Lock1Size.Content = "Unlock 1st Sizes";
                    SizeSelectAll.IsEnabled = false;
                }
                else
                {
                    SizeBox.IsEnabled = true;
                    Lock1Size.Content = "Lock 1st Sizes";
                    SizeSelectAll.IsEnabled = true;
                   
                }

            }

            // Determine if there are any items checked.  
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            Projects? test = Size2Box.SelectedItem as Projects;
            if (test != null)
            {
                string Code = test.Code;
                size2List.Add(Code);
            }
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            Projects? test = Size2Box.SelectedItem as Projects;
            if (test != null)
            {
                string Code = test.Code;
                size2List.Remove(Code);
            }
        }

        private void Lock2SizeButton_Click(object sender, RoutedEventArgs e)
        {
            SkuConstructor.selectedSecondSizes.Clear();
            SkuConstructor.selectedSecondSizesParam.Clear();
            if (size2List.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                for (int x = 0; x < size2List.Count; x++)
                {
                    string? size = size2List[x].ToString();
                    if (size != null)
                    {
                        SkuConstructor.selectedSecondSizes.Add(size);
                        SkuConstructor.selectedSecondSizesParam.Add($"'{size}'");
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                string status = "";
                AvailCust.Items.Clear();
                SelectedCust.Items.Clear();

                B1RestClient B2 = new B1RestClient();

                string content = B2.Get("/BusinessPartners/?$select=CardCode,CardName&$filter=Valid eq 'tYES'", out status);

                //MessageBox.Show(status);
                if (status != null)
                {
                    if (status == "OK")
                    {

                        var customers = System.Text.Json.JsonSerializer.Deserialize<CustomerBrief>(content);

                        if (customers != null)
                        {
                            // var model = System.Text.Json.JsonSerializer.Deserialize<Value>(jsonHL);

                            foreach (var c in customers.value)
                            {
                                AvailCust.Items.Add(c.CardName.ToString());
                            }


                            //MessageBox.Show(jsonHL.value.ToString());

                        }



                    }
                    else
                    {
                        MessageBox.Show($"Error: {content}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get Customers Error: {ex.Message}");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           SelectedCust.Items.Add(AvailCust.SelectedItem.ToString());
            int i = AvailCust.SelectedIndex;
            AvailCust.Items.RemoveAt(i);

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AvailCust.Items.Add(SelectedCust.SelectedItem.ToString());
            int i = SelectedCust.SelectedIndex;
            SelectedCust.Items.RemoveAt(i);
        }

        private void LockCust_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCust.Items.Count != 0)
            {
                if (LockCust.Content.ToString() == "Lock")
                {
                    AvailCust.IsEnabled = false;
                    SelectedCust.IsEnabled = false;
                    AddCust.Visibility = Visibility.Hidden;
                    RemoveCust.Visibility = Visibility.Hidden;
                    LockCust.Content = "Unlock";
                }
                else
                {
                    AvailCust.IsEnabled = true;
                    SelectedCust.IsEnabled = true;
                    AddCust.Visibility = Visibility.Visible;
                    RemoveCust.Visibility = Visibility.Visible;
                    LockCust.Content = "Lock";
                }
            }
        }

        #region Simulate Skus
        private void SimulateSkus_Click(object sender, RoutedEventArgs e)
        {
            #region Clearing values
            SkuConstructor.margin = null;
            SkuConstructor.isAvailableToAllCust = null;
            SkuConstructor.shippingCost= null;
            SkuConstructor.gender=null;
            SkuConstructor.isInventory= null;
            SkuConstructor.logoCode = null;
            #endregion

            #region Saving values from form
            try
            {
                SkuConstructor.margin = Margin.Text.ToString();
                SkuConstructor.isAvailableToAllCust = InventoryName.SelectedItem.ToString();
                SkuConstructor.shippingCost = ShippingCost.Text.ToString();
                SkuConstructor.gender = genderCombo.SelectedItem.ToString();
                SkuConstructor.isInventory = InventoryItemCombo.SelectedItem.ToString();
                SkuConstructor.logoCode = LogoCode.Text.ToString();
            }
            catch(NullReferenceException ex)
            {
                string msg=ex.Message;
            }
            #endregion

            refreshSkuList();
            SKU? parentWindow = Window.GetWindow(this) as SKU;
            if (parentWindow != null)
            {
               
                parentWindow.SkuSimButton.IsChecked = true;
                parentWindow.SkuSimButton.Command.Execute(parentWindow.SkuSimButton.CommandParameter);


            }




        }
        #endregion

        public void refreshSkuList()
        {
            try
            {
                string validColors, validSizes = null;
                if(SkuConstructor.selectedColorsParam.Count==1)
                {
                    validColors = SkuConstructor.selectedColorsParam[0];
                }
                else
                {
                    validColors = string.Join(",", SkuConstructor.selectedColorsParam);
                }
                if (SkuConstructor.selectedSizesParam.Count == 1)
                {
                    validSizes = SkuConstructor.selectedSizesParam[0];
                }
                else
                {
                    validSizes = string.Join(",", SkuConstructor.selectedSizesParam);
                }

               

                string query = $"select SkuCode,'{TextBoxDescr.Text} {LogoCode.Text}' as ProdName,STYLE,ColorName,SIZE,PIECE_PRICE as 'Supplier Price',cast(cast(PIECE_PRICE as numeric(19,2))*(({Convert.ToDouble(Margin.Text)}/100.00)+1) as numeric(19,2)) as 'Suggested Sell Price',(cast(PIECE_PRICE as numeric(19,2))+{Convert.ToDouble(SkuConstructor.shippingCost)})/(1-({Convert.ToDouble(Margin.Text)}/100)) as 'Sell Price', '-' as 'Suggested Action' from StyleMaster " +
                    $"where CompanyName = '{SkuConstructor.vendorName}' " +
                    $"and STYLE = '{SkuConstructor.styleName}' " +
                    $"and ColorName IN({validColors}) " +
                    $"and SIZE in ({validSizes})";

                var c = new SqlConnection(connStr);
                var dataAdapter = new SqlDataAdapter(query, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                SkuConstructor.ds=new DataSet();
                dataAdapter.Fill(SkuConstructor.ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get sku list error: {ex.Message}");
            }

        }

      
    }
    public class MyItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }=false;
    }
    public class Projects
    {
        public string Code { get; set; }

        public bool tick { get; set; }
    }
    public class CustomerBrief
    {
        public string odatametadata { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public string odataetag { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
    }
}
