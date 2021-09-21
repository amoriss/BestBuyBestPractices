using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); 
        void CreateProduct(int productID, string name, double price, int categoryID, int stockLevel, bool onSale); //method



    }
}
