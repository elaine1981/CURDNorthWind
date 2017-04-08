using System.Collections.Generic;
using System.ComponentModel;
using WebNorthWind.Models;

namespace WebNorthWind.ViewModels
{
    public class ProductsView
    {
        //搜尋欄位
        [DisplayName("搜尋：")]
        public string Search { get; set; }

        public List<Products> DataList { get; set; }
    }
}