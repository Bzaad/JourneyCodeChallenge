function ProductDataRenderer() { }

class Table {
	constructor(tableClass, name, headers, products){
		this.tableClass = tableClass;
		this.name = name;
		this.headers = headers;
		this.products = products;
	}

	GetHead = function(){
		return `
			<thead>
				<tr><td colspan=${this.headers.length}>${this.name}</td></tr>
				<tr>${this.headers.map(th => `<td>${th}</td>`).join("")}</tr>
			</thead>
			`;
	}

	GetBody = function() {
		return `
			<tbody>
				${this.products.map(
					p => `
						<tr>
							<td>${p.name}</td>
							<td>${p.price}</td>
							<td>${p.type}</td>
						</tr>
				`).join("")}
			</tbody>
		`;
	}

	GetTable = function(){
		return `
			<table class=${this.tableClass}>
				${this.GetHead()}
				${this.GetBody()}
			</table>
		`;
	}
}

ProductDataRenderer.prototype.render = function () {
	document.getElementById("nzdProducts").innerHTML = 
		new Table("'table table-striped'", "Products (NZD)", ["Name", "Price","Type"], ProductDataConsolidator.get()).GetTable();
	
	document.getElementById("usdProducts").innerHTML = 
		new Table("'table table-striped'", "Products (USD)", ["Name", "Price","Type"], ProductDataConsolidator.getInUSDollars()).GetTable();
	
	document.getElementById("euProducts").innerHTML = 
		new Table("'table table-striped'", "Products (Euro)", ["Name", "Price","Type"], ProductDataConsolidator.getInEuros()).GetTable();
}