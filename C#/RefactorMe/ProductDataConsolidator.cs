using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{

	public class ProductDataConsolidator
    {
	    /// <summary>
		/// Returns a list of consolidated products.
		/// </summary>
		/// <returns></returns>
        public List<Product> GetProducts() {
	        
	        var products =
				new LawnmowerRepository().GetAll().Select(l => new Product
			{Id = l.Id, Name = l.Name, Price = l.Price, Type = l.GetType().Name})
		.Concat(new PhoneCaseRepository().GetAll().Select(pc => new Product
			{Id = pc.Id, Name = pc.Name, Price = pc.Price, Type = pc.GetType().Name}))
		.Concat(new TShirtRepository().GetAll().Select(ts => new Product
			{Id = ts.Id, Name = ts.Name, Price = ts.Price, Type = ts.GetType().Name}));

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
		/// <param name="exchangeRate"></param>
		/// <returns></returns>
		public List<Product> GetInUSDollars(double exchangeRate)
        {
	        return _GetInOtherCurrencies(exchangeRate);
        }

		/// <summary>
		/// Returns a list of consolidated products with their prices in Euros.
		/// </summary>
		/// <param name="exchangeRate"></param>
		/// <returns></returns>
		public List<Product> GetInEuros(double exchangeRate)
        {
	        return _GetInOtherCurrencies(exchangeRate);
        }
    }
}
