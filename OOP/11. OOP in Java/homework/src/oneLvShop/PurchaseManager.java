package oneLvShop;

import oneLvShop.customexceptions.CustomerNoPermissionToBuyException;
import oneLvShop.customexceptions.CustomerinsufficientBalanceException;
import oneLvShop.customexceptions.ProductHasExpiredException;
import oneLvShop.customexceptions.ProductManagementException;
import oneLvShop.customexceptions.ProductOutOfStockException;

public final class PurchaseManager {

	public static void ProcessPurchase(Customer customer, Product product)
			throws ProductManagementException {
		if (product instanceof FoodProduct) {
			if (((FoodProduct) product).isExpired()) {
				throw new ProductHasExpiredException();
			}
		}

		if (product.getQuantity() < 1) {
			throw new ProductOutOfStockException();
		}

		if (customer.getBalance() < product.getPrice()) {
			throw new CustomerinsufficientBalanceException();
		}

		if (product.getAgeRestriction() == AgeRestriction.ADULT
				&& customer.getAge() < 18) {
			throw new CustomerNoPermissionToBuyException();
		}

		customer.setBalance(customer.getBalance() - product.getPrice());
		product.setQuantity(product.getQuantity() - 1);
	}
}
