var models = models || {};

(function (scope) {
	function Category(name) {
		this.name = name;
		this._categories = [];
		this._items = [];
	}

	Category.prototype.addCategory = function addCategory(categoryName) {
		this._categories.push(categoryName);
	}

	Category.prototype.getCategories = function getCategories() {
		return this._categories;
	}

	Category.prototype.addItem = function addCategory(itemName) {
		this._items.push(itemName);
	}

	Category.prototype.getItems = function getItems() {
		return this._items;
	}
	
	scope.getCategory = function getCategory(categoryName) {
		return new Category(categoryName);
	}
}(models));