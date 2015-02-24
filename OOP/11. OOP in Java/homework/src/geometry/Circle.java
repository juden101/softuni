package geometry;

public class Circle extends PlaneShape {
	private final double radius;

	public Circle(Vertex[] vertices, double radius) {
		super(vertices);
		if (radius <= 0) {
			throw new IllegalArgumentException(
					"Radius cannot be a negative number.");
		}

		this.radius = radius;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2 * Math.PI * this.radius;
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = Math.PI * this.radius * radius;
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
