package geometry;

public abstract class SpaceShape extends Shape implements AreaMeasurable,
		VolumeMeasurable {

	public SpaceShape(Vertex[] vertices) {
		super(vertices);
		// TODO Auto-generated constructor stub
	}

	@Override
	public String toString() {
		return String
				.format("Shape type: %s%nvertex x: %.2f, y: %.2f, z: %.2f;%nvolume: %.2f, area: %.2f",
						this.getClass().getSimpleName(),
						this.getVertex()[0].getX(), this.getVertex()[0].getY(),
						this.getVertex()[0].getZ(), this.getVolume(),
						this.getArea());
	}
}
