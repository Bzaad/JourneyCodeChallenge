/**
 * A class for for formatting consolidated products.
 */
class Product {
	constructor(id, name, price, type){
		this.id = id;
		this.name = name;
		this.price = price
		this.type = type;
	}

	/**
	 * converts product price using the given currency exchange rate.
	 * @param {exchangeRate} currency exchange rate
	 * @returns {convertedProduct} product with converted price.
	 */
	ConvertCurrency = function (exchangeRate){
		let convertedProduct = new Product(this.id, this.name, (this.price * exchangeRate).toFixed(2), this.type);
		return convertedProduct;
	}
}

/**
 * Product Data Consolidator main method.
 */
function ProductDataConsolidator() { }

/**
 * Returns a list of consolidated products with their price in default currency (New Zealand Dollar)
 * @returns {products} list of consolidated products
 */
ProductDataConsolidator.get = function () {
	let lawnmowers = new LawnmowerRepository().getAll();
	let phoneCases = new PhoneCaseRepository().getAll();
	let tShirts = new TShirtRepository().getAll();

	let products = [];
	
	lawnmowers.forEach(l => products.push(new Product(l.id, l.name, l.price.toFixed(2), "Lawnmower")));
	phoneCases.forEach(p=> products.push(new Product(p.id, p.name, p.price.toFixed(2), "Phone Case")));
	tShirts.forEach(t=> products.push(new Product(t.id, t.name, t.price.toFixed(2), "T-Shirt")));

	return products;
}

// Returns a list of consolidated products with their price converted to US Dollar.
/**
 * @returns {products} list of consolidated products with their currency converted to US Dollar.
 */
ProductDataConsolidator.getInUSDollars = function () {
	let products = ProductDataConsolidator.get().map(p => p.ConvertCurrency(0.76));
	return products
}


// Returns a list of consolidated products with their prices converted to Euros
/**
 * 
 * @returns {products} list of consolidated products with their currency converted to Euro.
 */
ProductDataConsolidator.getInEuros = function () {
	let products = ProductDataConsolidator.get().map(p => p.ConvertCurrency(0.67));
	return products;
}