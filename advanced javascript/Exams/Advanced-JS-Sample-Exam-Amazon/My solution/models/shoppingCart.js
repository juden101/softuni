var models = models || {};

(function (scope) {
	function ShoppingCart() {
		this._items = [];
	}
	
	ShoppingCart.prototype.addItem = function addItem(item) {
		this._items.push(item);
	}
	
	ShoppingCart.prototype.getTotalPrice = function getTotalPrice() {
		var totalPrice = 0;

		this.items.forEach(function (item) {
		 	totalPrice += item.price;
		});

		return totalPrice;
	}
	
	scope.getShoppingCart = function getShoppingCart() {
		return new ShoppingCart();
	}
	
	scope._ShoppingCart = ShoppingCart;
}(models));