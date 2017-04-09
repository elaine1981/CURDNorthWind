using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebNorthWind.Models
{
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products
    {
        private class ProductsMetadata
        {
            [DisplayName("ProductID：")]
            public int ProductID { get; set; }

            [DisplayName("ProductName：")]
            [Required(ErrorMessage = "請輸入 ProductName")]
            [StringLength(40, ErrorMessage = "ProductName 不可超過40字元")]
            public string ProductName { get; set; }

            [DisplayName("SupplierID：")]
            [Required(ErrorMessage = "請輸入 SupplierID")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            //[Range(1,29, ErrorMessage = "{0} 必須介於{1}到{2}之間")]
            public int SupplierID { get; set; }

            [DisplayName("CategoryID：")]
            [Required(ErrorMessage = "請輸入 CategoryID")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            //[Range(1, 8, ErrorMessage = "{0} 必須介於{1}到{2}之間")]
            public int CategoryID { get; set; }

            [DisplayName("QuantityPerUnit：")]
            [Required(ErrorMessage = "請輸入 QuantityPerUnit")]
            [StringLength(20, ErrorMessage = "QuantityPerUnit 不可超過20字元")]
            public string QuantityPerUnit { get; set; }

            [DisplayName("UnitPrice：")]
            [Required(ErrorMessage = "請輸入 UnitPrice")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            public int UnitPrice { get; set; }

            [DisplayName("UnitsInStock：")]
            [Required(ErrorMessage = "請輸入 UnitsInStock")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            public int UnitsInStock { get; set; }

            [DisplayName("UnitsOnOrder：")]
            [Required(ErrorMessage = "請輸入 UnitsOnOrder")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            public int UnitsOnOrder { get; set; }

            [DisplayName("ReorderLevel：")]
            [Required(ErrorMessage = "請輸入 ReorderLevel")]
            [RegularExpression("[0-9]*", ErrorMessage = "限定為數字")]
            public int ReorderLevel { get; set; }
        }
    }
}