using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKU_Generator.BackEnd
{
    public class SkuConstructor
    {
        public static List<string> styles = new();
        public static List<string> vendors = new();

        public static List<string> colors = new();
        public static List<string> colorsParam = new();

        public static List<string> selectedColors = new();
        public static List<string> selectedColorsParam = new();

        public static List<string> sizes = new();
        public static List<string> sizesParam = new();

        public static List<string> selectedSizes = new();
        public static List<string> selectedSizesParam = new();

        public static List<string> secondSizes = new();
        public static List<string> secondSizesParam = new();

        public static List<string> selectedSecondSizes = new();
        public static List<string> selectedSecondSizesParam = new();

        public static List<string> logoCodes = new();
        public static List<string> selectedLogoCodes = new();

        public static List<string> operationCodes = new();
        public static List<string> selectedOperationCodes = new();

        public static List<string> category = new();

        public static List<string> subCategory = new();


        public static List<string> skus = new();
        public static List<string> customers = new();

        public static string? vendorName = null;
        public static string? styleName = null;

        public static string? vendorAbbr = null;
        public static string? revCode = null;


        public static string? serverURL = null;
        public static string? username = null;
        public static string? password = null;
        public static string? Company = null;



        public static string? jsonString = null;
    }
}
