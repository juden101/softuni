package oneLvShop.customexceptions;

public class ProductHasExpiredException extends ProductManagementException {
	public ProductHasExpiredException() {
		super("This product has expired.");
	}
}
