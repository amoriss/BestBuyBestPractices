using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion

            IDbConnection conn = new MySqlConnection(connString);

            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Here are the current list of departments: ");
            var depos = repo.GetAllDepartments();
            Print(depos);
            

            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes" || userResponse.ToLower() == "yes")
            {
                Console.WriteLine("Type a new Department name");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }
           // var departments = repo.GetAllDepartments();
            //foreach(var dept in departments)
           // {
           //     Console.WriteLine(dept.Name);
          //  }


       

            //IDbConnection conn = new MySqlConnection(connString);

            DapperProductRepository ddr = new DapperProductRepository(conn);
            var products = ddr.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID} " +
                    $"Product Name: {product.Name} \n" +
                    $"Product Price: {product.Price} \n" +
                    $"Product Stock Level: {product.StockLevel} \n");
            }
           
        }

        static void Print(IEnumerable<Department> depos)
        {
            foreach (var dept in depos)
            {
                Console.WriteLine($"ID: {dept.DepartmentID}   Name: {dept.Name}");
            }
        }
    }
}
