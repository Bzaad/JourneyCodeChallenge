using System;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
	public class ProductDataConsolidator
    {
	    private string _GetTypeString(object obj)
	    {
		    switch (obj.GetType().Name)
		    {
				case "Lawnmower":
					return "Lawnmower";
				case "PhoneCase":
					return "Phone Case";
				case "TShirt":
					return "T-Shirt";
				default:
					throw new NotSupportedException("The product type is not supported");
		    }
	    }

	    /// <summary>
		/// Returns a list of consolidated products.
		/// </summary>
		/// <returns></returns>
        public List<Product> GetProducts() {
	        
	        var products =
				new LawnmowerRepository().GetAll().Select(l => new Product
			{Id = l.Id, Name = l.Name, Price = l.Price, Type = _GetTypeString(l)})
		.Concat(new PhoneCaseRepository().GetAll().Select(pc => new Product
			{Id = pc.Id, Name = pc.Name, Price = pc.Price, Type = _GetTypeString(pc)}))
		.Concat(new TShirtRepository().GetAll().Select(ts => new Product
			{Id = ts.Id, Name = ts.Name, Price = ts.Price, Type = _GetTypeString(ts)}));

	        return products.ToList();
        }

		/// <summary>
		/// Returns a list of consolidated products in some other currency with the given exchange rate.
		/// </summary>
		/// <param name="exchangeRate"></param>
		/// <returns></returns>
		private List<Product> _GetInOtherCurrencies(double exchangeRate) 
        {
	        var ps = new List<Product>();

	        GetProducts().ForEach(prod =>
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
