package geometry;

public class SquarePyramid extends SpaceShape {
	private final double width;
	private final double height;
	private double basePerimeter;
	private double baseArea;

	public SquarePyramid(Vertex[] vertices, double width, double height) {
		super(vertices);
		if (width <= 0) {
			throw new IllegalArgumentException(
					"Width cannot be a negative number.");
		}
		this.width = width;

		if (height <= 0) {
			throw new IllegalArgumentException(
					"Height cannot be a negative number.");
		}
		this.height = width;

		this.basePerimeter = 4 * width;
		this.baseArea = width * width;
	}

	@Override
	public double getArea() {
		double slantLength = Math.sqrt(height * height + (width / 2)
				* (width / 2));
		double area = this.baseArea + this.basePerimeter * slantLength / 2;
		return area;
	}

	@Override
	public double getVolume() {
		double volume = this.baseArea * height / 3;
		return volume;
	}
}
