package oneLvShop.customexceptions;

public class CustomerNoPermissionToBuyException extends
		ProductManagementException {
	public CustomerNoPermissionToBuyException() {
		super("You are too young to buy this product!");
	}
}
