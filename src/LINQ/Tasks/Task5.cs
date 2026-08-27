using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Enums;
using LINQ.Models;
using LINQ.Models.DTOs;
using LINQ.Tasks;

namespace LINQ.Tasks
{
    public class QueryBuilder
    {
        private List<Product> _products;
        private List<Supplier> _suppliers;
        private IEnumerable<Product> _productQuery;
        private IEnumerable<Supplier> _supplierQuery;
        private IEnumerable<ProductSupplierInfoDTO> _productSupplierQuery;

        internal QueryBuilder()
        {
            this._products = new List<Product>();
            this._suppliers = new List<Supplier>();
            this._productQuery = new List<Product>();
            this._supplierQuery = new List<Supplier>();
            this._productSupplierQuery = new List<ProductSupplierInfoDTO>();
        }

        public QueryBuilder Filter(Func<Product, bool> predicate)
        {
            _productQuery = _productQuery.Where(predicate);
            return this;
        }

        public QueryBuilder SortBy<TKey>(Func<Product, TKey> predicate)
        {
            _productQuery = _productQuery.OrderBy(predicate);
            return this;
        }

        public QueryBuilder Join(Func<Product, Supplier, bool> predicate)
        {
            _productSupplierQuery = from product in _productQuery
                                    join supplier in _suppliers
                                    on product.Id equals supplier.ProductId
                                    select new ProductSupplierInfoDTO
                                    {
                                        ProductId = product.Id,
                                        ProductName = product.Name,
                                        SupplierId = supplier.SupplierId,
                                        SupplierName = supplier.SupplierName,
                                    };
            return this;
        }

        public List<ProductSupplierInfoDTO> Execute()
        {
            return _productSupplierQuery.ToList();
        }
    }
}