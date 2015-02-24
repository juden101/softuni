package geometry;

public class Sphere extends SpaceShape {
	private final double radius;

	public Sphere(Vertex[] vertices, double radius) {
		super(vertices);
		if (radius <= 0) {
			throw new IllegalArgumentException(
					"Width cannot be a negative number.");
		}
		this.radius = radius;
	}

	@Override
	public double getArea() {
		double area = 4 * Math.PI * this.radius * this.radius;
		return area;
	}

	@Override
	public double getVolume() {
		double volume = Math.PI * this.radius * this.radius * this.radius * 4
				/ 3;
		return volume;
	}

}
