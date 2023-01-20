using SKU_Generator.BackEnd;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SKU_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<string> companyList=new string[] { "SOCIUSUS_09122022" };
        public MainWindow()
        {
            InitializeComponent();
            CompanyFill();
        }
        private void CompanyFill()
        {
            CompanyCombo.Items.Clear();
            
            CompanyCombo.ItemsSource = companyList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyCombo.SelectedItem != null)
            {
                if (!String.IsNullOrEmpty(UserName.Text.ToString().Trim()))
                {
                    if (!String.IsNullOrEmpty(Password.Password.ToString().Trim()))

                    {
                        using (B1RestClient b1 = new())
                        {
                            try
                            {
                                b1.Config(CompanyCombo.SelectedItem.ToString(), UserName.Text.ToString(), Password.Password.ToString(),Configuration.ServiceLayerUrl);
                               string loginChk= b1.Login();


                                SkuConstructor.serverURL = Configuration.ServiceLayerUrl;
                                SkuConstructor.Company = CompanyCombo.SelectedItem.ToString();
                                SkuConstructor.username = UserName.Text.ToString();
                                SkuConstructor.password = Password.Password.ToString();
                                if (loginChk != null)
                                {
                                    SKU sKU = new SKU();
                                    sKU.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Authentication Error");

                                }
                               


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Authentication Error");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Must inpupt a password");
                    }
                }
                else
                {
                    MessageBox.Show("Must inpupt a user name");
                }
            }
            else
            {
                MessageBox.Show("Must Choose a company");
            }
        }
    }
}
