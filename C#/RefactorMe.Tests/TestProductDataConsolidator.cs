using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Data.Implementation;

namespace RefactorMe.Tests
{
	[TestClass]
	public class TestProductDataConsolidator
	{
		[TestMethod]
		public void Test_GetProducts_MustReturnCorrectConsolidatedProducts()
		{
			var consolidator = new ProductDataConsolidator();
			var products = consolidator.GetProducts();
		}
	}
}
