using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomer();
            productDirector.GeneratedProduct(builder);

            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class ProductDirector
    {
        public void GeneratedProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }

    class NewCustomer : ProductBuilder //New Customer %10 Discount...
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * 0.90m;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Tea";
            model.UnitPrice = 25.56m;
        }
    }
    class OldCustomer : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Tea";
            model.UnitPrice = 25.56m;
        }
    }

    
}
