using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product _product, int _quantity)
        {
            CartLine productsInCart = lineCollection.Where(i => i.Product.ProductID == _product.ProductID)
                                            .FirstOrDefault();

            if (productsInCart == null)
            {
                CartLine newProduct = new CartLine();
                newProduct.Product = _product;
                newProduct.Quantity = _quantity;

                lineCollection.Add(newProduct);
            }
            else
            {
                productsInCart.Quantity += _quantity;
            }
        }

        public void RemoveAllItemsOfAProduct(Product _product)
        {
            this.lineCollection.RemoveAll(i => i.Product.ProductID == _product.ProductID);
        }

        public decimal ComputeTotalPrice()
        {
            decimal totalPrice = this.lineCollection.Sum(i => i.Product.Price * i.Quantity);
            return totalPrice;
        }

        public void ClearCart()
        {
            this.lineCollection.Clear();
        }

        public IEnumerable<CartLine> getCartLines
        {
            get { return this.lineCollection; }
        }
    }
}
