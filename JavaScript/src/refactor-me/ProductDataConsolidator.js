
function ProductDataConsolidator() { }


class Product {
	constructor(id, name, price, type){
		this.id = id;
		this.name = name;
		this.price = price
		this.type = type;
	}
}

ProductDataConsolidator.get = function () {
	var lawnmowers = new LawnmowerRepository().getAll();
	var phoneCases = new PhoneCaseRepository().getAll();
	var tShirts = new TShirtRepository().getAll();

	var products = [];
	
	lawnmowers.forEach(l => products.push(new Product(l.id, l.name, l.price.toFixed(2), "Lawnmower")));
	phoneCases.forEach(p=> products.push(new Product(p.id, p.name, p.price.toFixed(2), "PhoneCase")));
	tShirts.forEach(t=> products.push(new Product(t.id, t.name, t.price.toFixed(2), "T-Shirt")));

	console.log(typeof(phoneCases));
	/*for (var i = 0; i < l.length; i++) {
		products.push({
			id: l[i].id,
			name: l[i].name,
			price: l[i].price.toFixed(2),
			type: "Lawnmower"
		});
	}

	for (var i = 0; i < p.length; i++) {
		products.push({
			id: p[i].id,
			name: p[i].name,
			price: p[i].price.toFixed(2),
			type: "Phone Case"
		});
	}

	for (var i = 0; i < t.length; i++) {
		products.push({
			id: t[i].id,
			name: t[i].name,
			price: t[i].price.toFixed(2),
			type: "T-Shirt"
		});
	}*/

	return products;
}

ProductDataConsolidator.getInUSDollars = function () {
	var l = new LawnmowerRepository().getAll();
	var p = new PhoneCaseRepository().getAll();
	var t = new TShirtRepository().getAll();

	var products = [];

	for (var i = 0; i < l.length; i++) {
		products.push({
			id: l[i].id,
			name: l[i].name,
			price: (l[i].price * 0.76).toFixed(2),
			type: "Lawnmower"
		});
	}

	for (var i = 0; i < p.length; i++) {
		products.push({
			id: p[i].id,
			name: p[i].name,
			price: (p[i].price * 0.76).toFixed(2),
			type: "Phone Case"
		});
	}

	for (var i = 0; i < t.length; i++) {
		products.push({
			id: t[i].id,
			name: t[i].name,
			price: (t[i].price * 0.76).toFixed(2),
			type: "T-Shirt"
		});
	}

	return products;
}

ProductDataConsolidator.getInEuros = function () {
	var l = new LawnmowerRepository().getAll();
	var p = new PhoneCaseRepository().getAll();
	var t = new TShirtRepository().getAll();

	var products = [];

	for (var i = 0; i < l.length; i++) {
		products.push({
			id: l[i].id,
			name: l[i].name,
			price: (l[i].price * 0.67).toFixed(2),
			type: "Lawnmower"
		});
	}

	for (var i = 0; i < p.length; i++) {
		products.push({
			id: p[i].id,
			name: p[i].name,
			price: (p[i].price * 0.67).toFixed(2),
			type: "Phone Case"
		});
	}

	for (var i = 0; i < t.length; i++) {
		products.push({
			id: t[i].id,
			name: t[i].name,
			price: (t[i].price * 0.67).toFixed(2),
			type: "T-Shirt"
		});
	}

	return products;
}