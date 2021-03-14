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
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Test_GetInDollars_MustReturnCorrectConsolidatedProductsInUsDollar()
		{

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
