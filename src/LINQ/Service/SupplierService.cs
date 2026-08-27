using LINQ.Models;
using LINQ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Service
{
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;

        internal SupplierService(SupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }

        public void Add(int supplierId, Enums.SupplierName supplierName, int productId)
        {
            Supplier supplier = new Supplier()
            {
                SupplierId = supplierId,
                SupplierName = supplierName,
                ProductId = productId,
            };

            this._supplierRepository.Add(supplier);
        }

        public IReadOnlyList<Supplier> GetAll()
        {
            return this._supplierRepository.GetAll();
        }
    }
}
