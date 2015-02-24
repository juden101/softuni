package geometry;

public class Cuboid extends SpaceShape {
	private final double width;
	private final double height;
	private final double depth;

	public Cuboid(Vertex[] vertices, double width, double height, double depth) {
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
		this.height = height;

		if (depth <= 0) {
			throw new IllegalArgumentException(
					"Depth cannot be a negative number.");
		}
		this.depth = depth;
	}

	@Override
	public double getArea() {
		double bottomArea = this.width * this.depth;
		double frontArea = this.width * this.height;
		double sideArea = this.depth * this.height;
		double area = 2 * (bottomArea + frontArea + sideArea);
		return area;
	}

	@Override
	public double getVolume() {
		double volume = this.width * this.height * this.depth;
		return volume;
	}

}
