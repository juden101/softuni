package oneLvShop;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class FoodProduct extends Product implements Expirable {
	private Date expirationDate;
	private boolean hasExpired;
	private long daysUntilExpiry;

	public FoodProduct(String name, double price, int quantity,
			AgeRestriction ageRestrictionLevel, String expirationDate) {
		super(name, price, quantity, ageRestrictionLevel);

		SimpleDateFormat simpleFormat = (SimpleDateFormat) DateFormat
				.getDateInstance();
		simpleFormat.applyPattern("yyyy-MM-dd");

		try {
			this.expirationDate = simpleFormat.parse(expirationDate);
		} catch (ParseException e) {
			throw new IllegalArgumentException("not a valid date");
		}

		checkIfExpired();
	}

	@Override
	public double getPrice() {
		if (this.daysUntilExpiry < 15) {
			return this.price * 0.7;
		}

		return this.price;
	}

	@Override
	public String toString() {
		return super.toString() + "Expiration date: "
				+ this.expirationDate.toString();
	}

	private void checkIfExpired() {
		Date now = new Date();
		long diff = this.expirationDate.getTime() - now.getTime();

		long days = TimeUnit.DAYS.convert(diff, TimeUnit.MILLISECONDS);

		if (days < 1) {
			this.hasExpired = true;
		} else {
			this.hasExpired = false;
		}

		this.daysUntilExpiry = days;
	}

	public Date getExpirationDate() {
		return this.expirationDate;
	}

	public boolean isExpired() {
		return this.hasExpired;
	}

	public void setHasExpired(boolean hasExpired) {
		this.hasExpired = hasExpired;
	}

	public long getDaysUntilExpiry() {
		return this.daysUntilExpiry;
	}

	public void setDaysUntilExpiry(long daysUntilExpiry) {
		this.daysUntilExpiry = daysUntilExpiry;
	}
}
