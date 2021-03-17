using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactorMe.Tests
{
	[TestClass]
	public class TestProductDataConsolidator
	{
		/// <summary>
		/// Tests if products of different types exists in consolidated product list.
		/// </summary>
		[TestMethod]
		public void Test_GetProducts_MustReturnCorrectConsolidatedProducts()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
			Assert.IsTrue(products.Exists(p => p.Type.Equals("Lawnmower")));
			Assert.IsTrue(products.Exists(p => p.Type.Equals("T-Shirt")));
			Assert.IsTrue(products.Exists(p => p.Type.Equals("Phone Case")));
		}

		/// <summary>
		/// Tests if the method is returning the correct consolidated product list in US Dollar.
		/// </summary>
		[TestMethod]
		public void Test_GetInDollars_MustReturnCorrectConsolidatedProductsInUsDollar()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
			var productsInDollar = consolidator.GetInUsDollar(0.76);

			productsInDollar.ForEach(pUsd =>
			{
				Assert.IsTrue(products.Exists(p => (p.Price * 0.76).Equals(pUsd.Price))); 
			});
		}

		/// <summary>
		/// Tests if the method is returning the correct consolidated product list in Euro.
		/// </summary>
		[TestMethod]
		public void Test_GetInEuro_MustReturnCorrectConsolidatedProductsInEuro()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
			var productsInEuros = consolidator.GetInEuros(0.67);

			productsInEuros.ForEach(pEuro =>
			{
				Assert.IsTrue(products.Exists(p => (p.Price * 0.67).Equals(pEuro.Price)));
			});
		}
	}
}
