package geometry;

public abstract class Vertex {
	private final double x;
	private final double y;
	private final double z;

	public Vertex(final double x, final double y, final double z) {
		super();
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public double getX() {
		return x;
	}

	public double getY() {
		return y;
	}

	public double getZ() {
		return z;
	}
}
