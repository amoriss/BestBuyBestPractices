using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection; 
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection; 

        }
        public void CreateProduct(int newProductID, string newName, double newPrice, int newCategoryID, int newStockLevel, bool newOnSale)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID, OnSale, StockLevel) VALUES " +
                "(@newProductID, @newName, @newPrice, @newCategoryID, @newStockLevel, @newOnSale);",
                new { newProductID = newProductID, newName = newName , newPrice = newPrice, newCategoryID = newCategoryID, newStockLevel = newStockLevel, newOnSale = newOnSale});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS; ");
        }
    }
}
