package oneLvShop;

public abstract class Product implements Buyable {
	private String name;
	protected double price;
	private int quantity;
	private AgeRestriction ageRestriction;

	public Product(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super();
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}

	public String getName() {
		return name;
	}

	private void setName(String name) {
		if (name.isEmpty() || name == null) {
			throw new IllegalArgumentException("Name cannot be null or empty.");
		}
		this.name = name;
	}

	public double getPrice() {
		return price;
	}

	protected void setPrice(double price) {
		if (price < 0) {
			throw new IllegalArgumentException("Price cannot be negative.");
		}

		this.price = price;
	}

	public int getQuantity() {
		return quantity;
	}

	protected void setQuantity(int quantity) {
		if (quantity < 0) {
			throw new IllegalArgumentException("Quantity cannot be negative.");
		}

		this.quantity = quantity;
	}

	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}

	private void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}

	@Override
	public String toString() {
		return String
				.format("Product name: %s; price %.2f; quantity: %d; age restriction: %s ",
						this.name, this.price, this.quantity,
						this.ageRestriction.toString());
	}

}
