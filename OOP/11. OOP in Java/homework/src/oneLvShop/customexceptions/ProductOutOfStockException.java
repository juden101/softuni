package oneLvShop.customexceptions;

public class ProductOutOfStockException extends ProductManagementException {
	public ProductOutOfStockException() {
		super("We`re sorry, this product is out of stock.");
	}
}
