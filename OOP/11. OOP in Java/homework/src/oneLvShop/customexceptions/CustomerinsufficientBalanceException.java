package oneLvShop.customexceptions;

public class CustomerinsufficientBalanceException extends
		ProductManagementException {
	public CustomerinsufficientBalanceException() {
		super("You don`t have enough money to buy this product");
	}
}
