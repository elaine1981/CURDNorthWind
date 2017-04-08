using System.Collections.Generic;
using System.Linq;
using WebNorthWind.Models;

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
            return db.Products.ToList();
        }
    }
}