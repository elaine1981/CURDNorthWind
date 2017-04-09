using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebNorthWind.Models;
using WebNorthWind.Services;

namespace WebNorthWind.ViewModels
{
    public class ProductsView
    {
        [DisplayName("ProductID：")]
        [RegularExpression("[0-9]*",ErrorMessage = "限定為數字")]
        public Nullable<int> ProductID { get; set; }

        [DisplayName("ProductName：")]
        public string ProductName { get; set; }

        public List<Products> DataList { get; set; }

        //分頁內容
        public ForPaging Paging { get; set; }

        public int productsPage = 1;
        public int intPage
        {
            get
            {
                return productsPage;
            }

            set
            {
                productsPage = value;
            }
        }
    }
}