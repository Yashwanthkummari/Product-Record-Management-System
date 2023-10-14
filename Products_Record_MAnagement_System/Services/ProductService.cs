using Microsoft.Data.SqlClient;
using Products_Record_MAnagement_System.Context;
using Products_Record_MAnagement_System.Entity;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Products_Record_MAnagement_System.Services
{
    public class ProductService
    {
        private readonly ProductContext _context; //private readonly will Just Allow to read the data only to the user on the UI
        public ProductService(ProductContext productContext)
        {
            this._context = productContext;  //this is the Constructor dependency
        }

        //IEnumerable is used to convert the data  as a list ,ProcductEntity is the Entity name
        public IEnumerable<ProductEntity> GetAll()
        //Get All method retrieves all products from the database 
        {
            try
            {
                // getdata is a variable which stores all the data from the products table
                var getdata = _context.Products.FromSqlRaw("Sp_GetAllProducts").ToList();

                return getdata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddUpdateProduct(string code, string name, string description, DateTime expiryDate, string category, string image, string status,
                                       DateTime creationdate) // AddUpdateProduct is a  method  used to add or update a product in the database
        {
            try
            {
                string sql = "sp_UpsertProduct  @Code, @Name, @Description, @ExpiryDate, @Category, @Image, @Status, @creationdate";
                //sp_UpsertProduct is a storedprodecre which is used  while performing the above AddUpdateproduct
                _context.Database.ExecuteSqlRaw(sql, //ExecuteSqlRaw is used to execute the query 
                    new SqlParameter("@Code", code), //new SqlParameter is used to create a  SqlParameter object which is passed as a parameter to a SQL query when working with a database using Entity Framework.
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Description", description),
                    new SqlParameter("@ExpiryDate", expiryDate),
                    new SqlParameter("@Category", category),
                    new SqlParameter("@Image", image),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@creationdate", creationdate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public void UpdateProductWithStoredProcedure(int productId, string code, string name, string description, DateTime expiryDate, string category, string image, string status, DateTime creationdate)
        {
            string sql = "EXEC Sp_Updateproduct @ProductId, @Code, @Name, @Description, @ExpiryDate, @Category, @Image, @Status, @CreationDate";
            _context.Database.ExecuteSqlRaw(sql,
            new SqlParameter("@ProductId", productId),
             new SqlParameter("@Code", code),
            new SqlParameter("@Name", name),
            new SqlParameter("@Description", description),
                new SqlParameter("@ExpiryDate", expiryDate),
                new SqlParameter("@Category", category),
                new SqlParameter("@Image", image),
                new SqlParameter("@Status", status),
                new SqlParameter("@creationdate", creationdate)
            );
        }*/

        public void DeleteProduct(int productId)
        {

        }

    }
}
