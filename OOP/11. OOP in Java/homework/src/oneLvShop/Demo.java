package oneLvShop;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;

import oneLvShop.customexceptions.ProductManagementException;

public class Demo {

	public static void main(String[] args) {

		try {
			Customer jon = new Customer("Jon", 24, 100);
			Product meat = new FoodProduct("meat", 9.90, 8,
					AgeRestriction.NONE, "2015-10-14");

			System.out.println("Jon's money: " + jon.getBalance());
			System.out.println("Product meat quantity: " + meat.getQuantity());
			PurchaseManager.ProcessPurchase(jon, meat);
			System.out.println("Jon's money: " + jon.getBalance());
			System.out.println("Product meat quantity: " + meat.getQuantity());

			Customer arya = new Customer("Arya", 14, 100);
			Product wiskey = new FoodProduct("wiskey", 29.90, 10,
					AgeRestriction.ADULT, "2016-11-04");
			PurchaseManager.ProcessPurchase(arya, wiskey);
		} catch (ProductManagementException e) {
			System.out.println(e.getMessage());
		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		} catch (NullPointerException e) {
			System.err.println(e.getMessage());
		}

		List<Product> products = new ArrayList<Product>();

		products.add(new FoodProduct("Beef", 9.90, 80, AgeRestriction.NONE,
				"2015-10-14"));
		products.add(new FoodProduct("Jameson", 29.90, 10,
				AgeRestriction.ADULT, "2016-11-04"));
		products.add(new Computer("HP ProBook", 1890, 50, AgeRestriction.NONE));
		products.add(new Computer("DELL", 789.90, 2, AgeRestriction.NONE));
		products.add(new Appliance("Toaster", 34.90, 10, AgeRestriction.ADULT));

		Product expirableProduct = products
				.stream()
				.filter(p -> p instanceof Expirable)
				.sorted((p1, p2) -> Long.compare(
						((FoodProduct) p1).getDaysUntilExpiry(),
						((FoodProduct) p2).getDaysUntilExpiry())).findFirst()
				.get();
		System.out.println(expirableProduct);

		Stream<Object> ageRestricted = products
				.stream()
				.filter(p -> p.getAgeRestriction() == AgeRestriction.ADULT)
				.sorted((p1, p2) -> Double.compare(((Product) p1).getPrice(),
						((Product) p2).getPrice())).map(pr -> pr.toString());
		ageRestricted.forEachOrdered(product -> System.out.println(product));
	}
}
