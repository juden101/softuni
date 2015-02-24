package geometry;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;

	public Rectangle(Vertex[] vertices, final double width, final double height) {
		super(vertices);

		this.setHeight(height);
		this.setWidth(width);
	}

	public double getWidth() {
		return width;
	}

	private void setWidth(double width) {
		if (width <= 0) {
			throw new IllegalArgumentException(
					"Width cannot be a negative number.");
		}

		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	private void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException(
					"Height cannot be a negative number.");
		}

		this.height = height;
	}

	@Override
	public double getPerimeter() {
		double perimeter = (this.width + this.height) * 2;
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = this.width * this.height;
		return area;
	}

	@Override
	public String toString() {
		return String
				.format("Shape type: %s%nvertex x: %.2f, y: %.2f;%nperimeter: %.2f, area: %.2f",
						this.getClass().getSimpleName(),
						this.getVertex()[0].getX(), this.getVertex()[0].getY(),
						this.getPerimeter(), this.getArea());
	}
}
