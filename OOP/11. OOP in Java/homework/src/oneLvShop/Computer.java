package oneLvShop;

public class Computer extends ElectronicsProduct {

	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestrictionLevel) {
		super(name, price, quantity, ageRestrictionLevel, 24);
	}

	@Override
	public double getPrice() {
		if (this.getQuantity() > 1000) {
			return this.getPrice() * 0.95;
		}

		return this.getPrice();
	}
}
