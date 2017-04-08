using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebNorthWind.Services;
using WebNorthWind.ViewModels;

namespace WebNorthWind.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDBService productsService = new ProductsDBService();

        // GET: Products
        public ActionResult Index()
        {
            ProductsView Data = new ProductsView();

            Data.DataList = productsService.GetDataList();

            return View(Data);
        }
    }
}