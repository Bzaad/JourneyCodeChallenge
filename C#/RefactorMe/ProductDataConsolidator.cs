using System;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
	public interface IProduct
	{
		int ID { get; set; }
		string Name { get; set; }
		double Price { get; set; }
		string Type { get; set; }
	}

	public class ProductDataConsolidator
    {
		public ProductTypeBuilder ProductTypeBuilder { get; set; } = new ProductTypeBuilder();

		private List<Product> ConsolidatedProducts { get; set; } = new List<Product>();

		/*private void _AddConsolidatedProduct(Guid id, string name, double price, string type)
		{
			this.ConsolidatedProducts.Add(new Product {Id = id, Name = name, Price = price, Type = type});
		}*/

		private void _AddConsolidatedProduct(IProduct product, string type)
		{
			Console.WriteLine(product.ToString());
		}

		/// <summary>
		/// Returns a list of consolidated products.
		/// </summary>
		/// <param name="unconsolidatedProducts"></param>
		/// <returns></returns>
		public List<Product> GetProducts(List<object> unconsolidatedProducts)
		{
			unconsolidatedProducts.ForEach(p =>
			{
				var type = ProductTypeBuilder.GetTypeString(p);
				p = (IProduct) p;

				switch (type)
				{
					case "Lawnmower":
						var l = (IProduct) p;
						this._AddConsolidatedProduct(l, type);
						break;
					case "T-Shirt":
						var ts = (IProduct) p;
						this._AddConsolidatedProduct(ts, type);
						break;
					case "Phone Case":
						this._AddConsolidatedProduct((IProduct) p, type);
						break;
					default:
						throw new NotSupportedException("The product type is not supported");
				}
			});
			return this.ConsolidatedProducts;
			/*
		    return new LawnmowerRepository().GetAll().Select(l => new Product
			    {Id = l.Id, Name = l.Name, Price = l.Price, Type = ProductTypeBuilder.GetTypeString(l)})
		    .Concat(new PhoneCaseRepository().GetAll().Select(pc => new Product
				{Id = pc.Id, Name = pc.Name, Price = pc.Price, Type = ProductTypeBuilder.GetTypeString(pc)})
			.Concat(new TShirtRepository().GetAll().Select(ts => new Product
				{Id = ts.Id, Name = ts.Name, Price = ts.Price, Type = ProductTypeBuilder.GetTypeString(ts)}))).ToList();*/
		}
    }
}