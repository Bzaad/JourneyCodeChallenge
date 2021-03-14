function ProductDataRenderer() { }

/**
 * A class for structuring the table template.
 */
class Table {

	constructor(tableClass, name, headers, products){
		this.tableClass = tableClass;
		this.name = name;
		this.headers = headers;
		this.products = products;
	}

	/**
	 * Returns the populated header template based on the table name and column headers.
	 * @returns {headerTemplate} populated header template.
	 */
	GetHead = function(){
		let headerTemplate = 
			`<thead>
				<tr><td colspan=${this.headers.length}>${this.name}</td></tr>
				<tr>${this.headers.map(th => `<td>${th}</td>`).join("")}</tr>
			</thead>`;

		return headerTemplate;
	}

	/**
	 * returns the populated body template base od the list of products.
	 * @returns {bodyTemplate} populated body template
	 */
	GetBody = function() {
		let bodyTemplate = 
			`<tbody>
				${this.products.map(
					p => `
						<tr>
							<td>${p.name}</td>
							<td>${p.price}</td>
							<td>${p.type}</td>
						</tr>
				`).join("")}
			</tbody>`;

			return bodyTemplate;
	}

	/**
	 * Returns a populated table template by combining header and body templates.
	 * @returns {tableTemplate} populated table template
	 */
	GetTable = function(){
		let tableTemplate = 
		`<table class=${this.tableClass}>
				${this.GetHead()}
				${this.GetBody()}
			</table>
		`;
		
		return tableTemplate;
	}
}

/**
 * Adds the table template to the DOM.
 */
ProductDataRenderer.prototype.render = function () {
	document.getElementById("nzdProducts").innerHTML = 
		new Table("'table table-striped'", "Products (NZD)", ["Name", "Price","Type"], ProductDataConsolidator.get()).GetTable();
	
	document.getElementById("usdProducts").innerHTML = 
		new Table("'table table-striped'", "Products (USD)", ["Name", "Price","Type"], ProductDataConsolidator.getInUSDollars()).GetTable();
	
	document.getElementById("euProducts").innerHTML = 
		new Table("'table table-striped'", "Products (Euro)", ["Name", "Price","Type"], ProductDataConsolidator.getInEuros()).GetTable();
}