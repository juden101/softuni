package oneLvShop;

public abstract class ElectronicsProduct extends Product {

	private int guaranteePeriod;

	public ElectronicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, int guaranteePeriod) {
		super(name, price, quantity, ageRestriction);

		this.setGuaranteePeriod(guaranteePeriod);
	}

	public int getGuaranteePeriod() {
		return this.guaranteePeriod;
	}

	public void setGuaranteePeriod(int guaranteePeriod) {
		if (guaranteePeriod < 0) {
			throw new IllegalArgumentException(
					"Electronics product's guarantee period cannot be negative.");
		}

		this.guaranteePeriod = guaranteePeriod;
	}

	@Override
	public String toString() {
		return super.toString() + "Guarantee period: " + this.guaranteePeriod;
	}
}
