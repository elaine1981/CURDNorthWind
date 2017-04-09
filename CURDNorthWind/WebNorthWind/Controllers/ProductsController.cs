using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebNorthWind.Models;
using WebNorthWind.Services;
using WebNorthWind.ViewModels;

namespace WebNorthWind.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDBService productsService = new ProductsDBService();

        // GET: Products
        public ActionResult Index(int Page=1)
        {
            ProductsView Data = new ProductsView();
            Data.Paging = new ForPaging(Page);
            Data.DataList = productsService.GetAllDataList(Data.Paging);

            return View(Data);
        }

        [HttpPost] //設定此Action只接受頁面POST資料傳入
        public ActionResult Index(ProductsView Data)
        {
            Data.Paging = new ForPaging(Data.intPage);
            Data.DataList = productsService.GetDataList(Data.Paging, Data);

            //將頁面資料傳入View中
            return View(Data);
        }

        #region 新增留言
        //新增留言一開始載入頁面
        public ActionResult Create()
        {
            return View();
        }

        //新增留言傳入資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        public ActionResult Add(Products Data)
        {
            //使用Service來新增一筆資料
            productsService.InsertProducts(Data);
            //重新導向頁面至開始頁面
            return RedirectToAction("Index");
        }
        #endregion

        #region 修改留言
        //修改留言頁面要根據傳入編號來決定要修改的資料
        public ActionResult Edit(int ProductID)
        {
            //取得頁面所需資料，藉由Service取得
            Products Data = productsService.GetDataByProductID(ProductID);
            //將資料傳入View中
            return View(Data);
        }

        //修改留言傳入資料時的Action
        [HttpPost] //設定此Action只接受頁面POST資料傳入
        public ActionResult Edit(Products UpdateData)
        {
            productsService.UpdateProducts(UpdateData);

            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除留言
        //刪除頁面要根據傳入編號來刪除資料
        public ActionResult Delete(int ProductID)
        {
            //使用Service來刪除資料
            productsService.DeleteProducts(ProductID);
            //重新導向頁面至開始頁面
            return RedirectToAction("Index");
        }
        #endregion
    }
}