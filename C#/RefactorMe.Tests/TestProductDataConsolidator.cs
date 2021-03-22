using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;

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
			var productDataConsolidator = new ProductDataConsolidator();
			List<object> allProducts = new List<object>();

			var products = productDataConsolidator.GetProducts(allProducts);
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
			var productDataConsolidator = new ProductDataConsolidator();
			List<object> allProducts = new List<object>();

			var products = productDataConsolidator.GetProducts(allProducts);
			var productsInDollar = new ProductCurrencyConvertor(products).GetInUsDollar(0.76);

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
			var productDataConsolidator = new ProductDataConsolidator();
			List<object> allProducts = new List<object>();

			var products = productDataConsolidator.GetProducts(allProducts);
			var productsInEuros = new ProductCurrencyConvertor(products).GetInUsDollar(0.67);

			productsInEuros.ForEach(pEuro =>
			{
				Assert.IsTrue(products.Exists(p => (p.Price * 0.67).Equals(pEuro.Price)));
			});
		}

		[TestMethod]
		public void ConsolidatorTest()
		{
			var pc = new ProductDataConsolidator();
			var products = new LawnmowerRepository().GetAll();
			pc.GetProducts((List<object>) products.ToList());
		}
	}
}
