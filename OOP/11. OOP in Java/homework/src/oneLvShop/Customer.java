package oneLvShop;

public class Customer {
	private String name;
	private int age;
	private double balance;

	public Customer(String name, int age, double balance) {
		this.setName(name);
		this.setAge(age);
		this.setBalance(balance);
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name == null || name.isEmpty()) {
			throw new IllegalArgumentException(
					"Customer name cannot be null or empty.");
		}
		this.name = name;
	}

	public int getAge() {
		return this.age;
	}

	public void setAge(int age) {
		if (age < 0 || age > 120) {
			throw new IllegalArgumentException(
					"Customer age must be in the interval [0...120].");
		}
		this.age = age;
	}

	public double getBalance() {
		return this.balance;
	}

	public void setBalance(double balance) {
		if (balance < 0) {
			throw new IllegalArgumentException(
					"Customer balance cannot be negative.");
		}
		this.balance = balance;
	}
}
