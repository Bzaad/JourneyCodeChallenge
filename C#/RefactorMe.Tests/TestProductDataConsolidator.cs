using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactorMe.Tests
{
	[TestClass]
	public class TestProductDataConsolidator
	{
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test_GetProducts_MustReturnCorrectConsolidatedProducts()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
			products.ForEach(p =>
			{ });
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test_GetInDollars_MustReturnCorrectConsolidatedProductsInUsDollar()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
			var productsInDollar = consolidator.GetInUsDollars(0.76);

			productsInDollar.ForEach(x =>
			{

			});
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test_GetInEuro_MustReturnCorrectConsolidatedProductsInEuro()
		{

		}
	}
}
