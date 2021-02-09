using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new NhProductDal());
            productManager.Save();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            //Business code
            _productDal.Save();
        }
    }
}
