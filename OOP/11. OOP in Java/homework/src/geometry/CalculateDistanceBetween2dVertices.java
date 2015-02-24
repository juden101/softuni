package geometry;

public class CalculateDistanceBetween2dVertices {

	public static double calculate(Vertex a, Vertex b) {
		double distance = Math.sqrt(Math.pow(a.getX() - b.getX(), 2)
				+ Math.pow(a.getY() - b.getY(), 2));
		return distance;
	}
}
