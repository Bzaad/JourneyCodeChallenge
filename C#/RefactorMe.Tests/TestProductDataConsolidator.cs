using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactorMe.Tests
{
	[TestClass]
	public class TestProductDataConsolidator
	{
		[TestMethod]
		public void TestClass1()
		{
			var pdc = ProductDataConsolidator.Get();

			pdc.ForEach(x =>
			{
				Assert.AreNotEqual(x.Id,0);
			});
		}
	}
}
