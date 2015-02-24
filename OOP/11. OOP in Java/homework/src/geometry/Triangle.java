package geometry;

public class Triangle extends PlaneShape {
	private double aX;
	private double aY;
	private double bX;
	private double bY;
	private double cX;
	private double cY;

	public Triangle(Vertex[] vertices) {
		super(vertices);
		if (vertices.length < 3) {
			throw new IllegalArgumentException(
					"You have to pass an array of 3 vertices.");
		}

		this.aX = this.getVertex()[0].getX();
		this.aY = this.getVertex()[0].getY();
		this.bX = this.getVertex()[1].getX();
		this.bY = this.getVertex()[1].getY();
		this.cX = this.getVertex()[2].getX();
		this.cY = this.getVertex()[2].getY();

		if ((aX == bX && aY == bY) || (aX == cX && aY == cY)
				|| (bX == cX && bY == cY)) {
			throw new IllegalArgumentException(
					"The vertices you've entered cannot form a rectangle.");
		}
	}

	@Override
	public double getPerimeter() {
		double sideA = CalculateDistanceBetween2dVertices.calculate(
				this.getVertex()[0], this.getVertex()[1]);
		double sideB = CalculateDistanceBetween2dVertices.calculate(
				this.getVertex()[1], this.getVertex()[2]);
		double sideC = CalculateDistanceBetween2dVertices.calculate(
				this.getVertex()[2], this.getVertex()[0]);
		double perimeter = sideA + sideB + sideC;
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = Math.abs((this.aX * (this.bY - this.cY) + this.bX
				* (this.cY - this.aY) + this.cX * (this.aY - this.bY)) / 2);
		return area;
	}

	@Override
	public String toString() {
		return String
				.format("Shape type: %s%nvertexA x: %.2f, y: %.2f;%nvertexB x: %.2f, y: %.2f;%nvertexC x: %.2f, y: %.2f;%nperimeter: %.2f, area: %.2f",
						this.getClass().getSimpleName(), this.aX, this.aY,
						this.bX, this.bY, this.cX, this.cY,
						this.getPerimeter(), this.getArea());
	}
}
