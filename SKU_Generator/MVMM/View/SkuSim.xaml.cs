using Newtonsoft.Json;
using SKU_Generator.BackEnd;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SKU_Generator.MVMM.View
{
    /// <summary>
    /// Interaction logic for SkuSim.xaml
    /// </summary>
    public partial class SkuSim : UserControl
    {
        public SkuSim()
        {
            InitializeComponent();
            try
            {
                if (SkuConstructor.ds.Tables[0] != null)
                {
                    FillDataTable();
                }
                
            }
            catch 
            {

            }
           
        }
        private void FillDataTable()
        {
           DataTable dt= SkuConstructor.ds.Tables[0];      
            foreach (DataRow row in dt.Rows)
            {
               string? i= row["SkuCode"].ToString();
               string? q = row["ProdName"].ToString();
               string? w = row["STYLE"].ToString();
               string? e= row["ColorName"].ToString();
               string? r = row["SIZE"].ToString();
               string? t = row["Supplier Price"].ToString();
               string? y = row["Suggested Sell Price"].ToString();
               string? u = row["Suggested Action"].ToString();
                string? o = row["Sell price"].ToString();
                SkuDisplay.Items.Add(new SkuDisplay()
                {
                    Code = i,
                    Prod=q,
                    Style=w,
                    Color=e,
                    Size=r,
                    Supplier=t,
                    Suggested=y,
                    Action=u,
                    SellPrice=o
                });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content;
            if (Validate.Content.ToString() == "Validate")
            {
                List<SkuDisplay> display = new List<SkuDisplay>();
                foreach (SkuDisplay dr in SkuDisplay.Items)
                {
                    SkuDisplay newDisplay = new SkuDisplay();
                    newDisplay.Code = dr.Code;
                    newDisplay.Prod = dr.Prod;
                    newDisplay.Style = dr.Style;
                    newDisplay.Color = dr.Color;
                    newDisplay.Size = dr.Size;
                    newDisplay.Supplier = dr.Supplier;
                    newDisplay.Suggested = dr.Suggested;
                    newDisplay.SellPrice= dr.SellPrice;
                    string skuCode = dr.Code.ToString();
                    string response = null;

                    string uri = $"/Items/?$select=ItemCode,ItemName,Mainsupplier&$filter=ItemCode eq '{skuCode}'";
                    //string uri = $"/Items/?$select=ItemCode,ItemName,Mainsupplier&$filter=ItemCode eq '10001'";
                    B1RestClient.getItemsSku(uri, skuCode, out response);
                    newDisplay.Action = response;
                    display.Add(newDisplay);

                }
                SkuDisplay.Items.Clear();
                foreach (SkuDisplay dr in display)
                {

                    SkuDisplay.Items.Add(dr);
                }
                Validate.Content = "Submit";
            }
            else
            {
                foreach (SkuDisplay dr in SkuDisplay.Items)
                {
                    ItemModel itemModel= new ItemModel();
                    itemModel.ItemCode= dr.Code;
                    itemModel.ItemName = dr.Prod;
                    itemModel.InventoryItem = "Y";
                    var main = JsonConvert.SerializeObject(itemModel);
                   string response = null;
                    B1RestClient.Post("/Items",main,out response,out content);

                }
            }
        }
    }
    public class SkuDisplay
    {
        public string? Code { get; set; }
        public string? Prod { get; set; }
        public string? Style { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Supplier { get; set; }
        public string? Suggested { get; set; }
        public string? Action { get; set; }
        public string? SellPrice { get; set; }


    }
}
