using System;

namespace RefactorMe
{
	public class ProductTypeBuilder
	{
		/// <summary>
		/// Returns the string name for the given product.
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public string GetTypeString(object product)
		{
			switch (product.GetType().Name)
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
	}
}