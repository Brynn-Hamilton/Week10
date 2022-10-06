using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace GroceryCrud.Models
{
    // Functionality to access our data.
    // This is the "data access layer"
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=grocerystore;Uid=root;Pwd=ReasonsILoveYou;");

        // CRUD operations for our Category table

        // Read all

        public static List<Category> GetAllCategories()
        {
            // Throughout our app, any time we need to get a list of all categories, we just call
            // DAL.GetAllCategories();
            return DB.GetAll<Category>().ToList();
        }

        // Read one

        public static Category GetOneCategory(string id)
        {
            return DB.Get<Category>(id);
        }

        // Create one (insert)

        public static Category InsertCategory(Category category)
        {
            DB.Insert<Category>(category);
            return category;
        }

        // Delete one
        public static void DeleteCategory(string id)
        {
            Category cat = new Category();
            cat.id = id;
            // or
            // Category cat = new Category() {id = id};
            DB.Delete<Category>(cat);
        }

        // Update one (Users prefer the term "edit")
        public static void UpdateCategory(Category cat)
        {
            DB.Update<Category>(cat);
        }

        // CRUD operations for our Product table

        // Read all
        public static List<Product> GetAllProducts()
        {
            return DB.GetAll<Product>().ToList();
        }
        // Read one
        public static Product GetOneProduct(int id)
        {
            return DB.Get<Product>(id);
        }
        // Create one (insert)
        public static Product InsertProduct(Product product)
        {
            DB.Insert<Product>(product);
            return product;
        }
        // Delete one
        public static void DeleteProduct(int id)
        {
            Product product = new Product();
            product.id = id;
            DB.Delete<Product>(product);
        }
        // Update one (Users prefer the term "edit")
        public static void UpdateProduct(Product product)
        {
            DB.Update<Product>(product);
        }
    }
}
