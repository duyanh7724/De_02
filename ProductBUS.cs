using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductBUS
    {
        private ProductDAL productDAL;

        public ProductBUS()
        {
            productDAL = new ProductDAL();
        }

        
        
        public void AddOrUpdateProduct(Sanpham product)
        {
            var existingProduct = productDAL.GetAllProducts().FirstOrDefault(p => p.MaSP == product.MaSP);
            if (existingProduct != null)
            {
                productDAL.UpdateProduct(product);
            }
            else
            {
                productDAL.AddProduct(product);
            }
        }
        public List<Sanpham> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        public List<LoaiSP> GetAllCategories()
        {
            return productDAL.GetAllCategories();
        }
        
        public string GetCategoryIdByName(string name)
        {
            var category = productDAL.GetCategoryByName(name);
            return category?.MaLoai;
        }

        public void DeleteProduct(string maSP)
        {
            productDAL.DeleteProduct(maSP);
        }

        public List<Sanpham> GetProductsByName(string tenSP)
        {
            return productDAL.GetProductsByName(tenSP);
        }        

    }
}
