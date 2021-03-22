using System.Collections.Generic;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe
{
	public class ProductCurrencyConvertor
	{
		public List<Product> ProductList { get; set; }

		public ProductCurrencyConvertor(List<Product> productList)
		{
			this.ProductList = productList;
		}

		/// <summary>
		/// Returns a list of consolidated products in some other currency with the given exchange rate.
		/// </summary>
		/// <param name="exchangeRate"></param>
		/// <returns></returns>
		private List<Product> _GetInOtherCurrencies(double exchangeRate)
		{
			var ps = new List<Product>();

			ProductList.ForEach(prod =>
			{
				ps.Add(new Product()
				{
					Id = prod.Id,
					Name = prod.Name,
					Price = prod.Price * exchangeRate,
					Type = prod.Type
				});
			});
			return ps;
		}

		/// <summary>
		/// Returns a list of consolidated products with their prices in US Dollar.
		/// </summary>
		/// <param name="usDollarExchangeRate"></param>
		/// <returns></returns>
		public List<Product> GetInUsDollar(double usDollarExchangeRate)
		{
			return _GetInOtherCurrencies(usDollarExchangeRate);
		}

		/// <summary>
		/// Returns a list of consolidated products with their prices in Euros.
		/// </summary>
		/// <param name="euroExchangeRate"></param>
		/// <returns></returns>
		public List<Product> GetInEuros(double euroExchangeRate)
		{
			return _GetInOtherCurrencies(euroExchangeRate);
		}
	}
}