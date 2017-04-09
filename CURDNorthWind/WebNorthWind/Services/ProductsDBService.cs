using System;
using System.Collections.Generic;
using System.Linq;
using WebNorthWind.Models;
using WebNorthWind.ViewModels;

namespace WebNorthWind.Services
{
    public class ProductsDBService
    {
        //宣告資料庫實體模型物件
        NORTHWNDEntities db = new NORTHWNDEntities();

        //取得陣列資料方法
        public List<Products> GetDataList()
        {
            //回傳全部資料
            return db.Products.OrderByDescending(x => x.ProductID).ToList();
        }

        #region 新增資料
        //新增資料方法
        public void InsertProducts(Products newData)
        {
            //將資料加入資料庫實體
            db.Products.Add(newData);
            //儲存資料庫變更
            db.SaveChanges();
        }
        #endregion

        #region 查詢一筆資料
        //藉由標號取得單筆資料的方法
        public Products GetDataByProductID(int ProductID)
        {
            //回傳根據標號所取得的資料
            return db.Products.Find(ProductID);
        }
        #endregion

        #region 修改留言
        //修改留言方法
        public void UpdateProducts(Products UpdateData)
        {
            //取得要修改的資料
            Products OldData = db.Products.Find(UpdateData.ProductID);
            //修改資料庫裡的值
            OldData.ProductName = UpdateData.ProductName;
            OldData.SupplierID = UpdateData.SupplierID;
            OldData.CategoryID = UpdateData.CategoryID;
            OldData.QuantityPerUnit = UpdateData.QuantityPerUnit;
            OldData.UnitPrice = UpdateData.UnitPrice;
            OldData.UnitsInStock = UpdateData.UnitsInStock;
            OldData.UnitsOnOrder = UpdateData.UnitsOnOrder;
            OldData.ReorderLevel = UpdateData.ReorderLevel;
            OldData.Discontinued = UpdateData.Discontinued;

            //儲存資料庫變更
            db.SaveChanges();
        }
        #endregion

        #region 刪除資料
        //刪除資料方法
        public void DeleteProducts(int ProductID)
        {
            //根據Id取得要刪除的資料
            Products DeleteData = db.Products.Find(ProductID);
            //從資料庫實體中刪除資料
            db.Products.Remove(DeleteData);
            //儲存資料庫變更
            db.SaveChanges();
        }
        #endregion

        //無搜尋值的搜尋資料方法
        public List<Products> GetAllDataList(ForPaging Paging)
        {
            //宣告要回傳的搜尋資料為資料庫中的Guestbooks資料表
            IQueryable<Products> Data = db.Products;
            //計算所需的總頁數
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Data.Count()) / Paging.ItemNum));
            //重新設定正確的頁數，避免有不正確值傳入
            Paging.SetRightPage();
            //回傳搜尋資料
            return Data.OrderByDescending(p => p.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum).ToList();
        }

        #region 查詢陣列資料
        //根據搜尋來取得資料陣列的方法
        public List<Products> GetDataList(ForPaging Paging,ProductsView searchCondition)
        {
            //宣告要接受全部搜尋資料的物件
            IQueryable<Products> SearchData;

            SearchData = db.Products;

            string productID = "";
            string productName = "";

            if (searchCondition.ProductID != null)
            {
                productID = searchCondition.ProductID.ToString().Trim();
            }

            if (searchCondition.ProductName != null)
            {
                productName = searchCondition.ProductName.Trim();
            }

            if (String.IsNullOrEmpty(productID) == false)
            {
                SearchData = SearchData.Where(p => p.ProductID.ToString().Contains(productID));
            }

            if (String.IsNullOrEmpty(productName) == false)
            {
                SearchData = SearchData.Where(p => p.ProductName.ToString().Contains(productName));
            }

            //計算所需的總頁數
            Paging.MaxPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(SearchData.Count()) / Paging.ItemNum));

            //重新設定正確的頁數，避免有不正確值傳入
            Paging.SetRightPage();

            //先排序再根據分頁來回傳所需部分的資料陣列
            return SearchData.OrderByDescending(p => p.ProductID).Skip((Paging.NowPage - 1) * Paging.ItemNum).Take(Paging.ItemNum).ToList();
        }
        #endregion
    }
}