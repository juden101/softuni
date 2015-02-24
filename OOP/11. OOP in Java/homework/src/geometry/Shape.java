package geometry;

public abstract class Shape {
	private Vertex[] vertices;

	public Shape(Vertex[] vertices) {
		this.vertices = vertices;
	}

	public Vertex[] getVertex() {
		return this.vertices;
	}
}
