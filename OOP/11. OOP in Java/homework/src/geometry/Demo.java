package geometry;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Demo {

	public static void main(String[] args) {
		Vertex a = new TwoDimVertex(5, 6);
		Vertex b = new TwoDimVertex(4, 2);
		Vertex c = new TwoDimVertex(-4, 12);
		Vertex d = new ThreeDimVertex(8, -14, 7);
		Vertex[] twoDimVertices = new Vertex[] { a, b, c };
		Vertex[] triDimVertices = new Vertex[] { d };

		try {
			Shape triangle = new Triangle(twoDimVertices);
			Shape rectangle = new Rectangle(twoDimVertices, 5, 7);
			Shape circle = new Circle(twoDimVertices, 2);
			Shape pyramid = new SquarePyramid(triDimVertices, 6, 5);
			Shape cuboid = new Cuboid(triDimVertices, 5, 2, 1);
			Shape sphere = new Sphere(triDimVertices, 10);

			Shape[] shapesArr = new Shape[] { triangle, rectangle, circle,
					pyramid, cuboid, sphere };

			// for (Shape shape : shapesArr) {
			// System.out.println(shape.toString());
			// System.out.println("----------");
			// }

			System.out.println("Filter by volume:");
			List<Shape> shapeByVolume = Arrays.asList(shapesArr).stream()
					.filter(s -> s instanceof VolumeMeasurable)
					.filter(v -> ((VolumeMeasurable) v).getVolume() > 40)
					.collect(Collectors.toList());

			for (Shape shape : shapeByVolume) {
				System.out.println(shape.toString());
				System.out.println("----------");
			}

			System.out.println("Sort by perimeter:");
			Comparator<Shape> byPerimeter = (s1, s2) -> {
				PerimeterMeasurable Shape1 = (PerimeterMeasurable) s1;
				PerimeterMeasurable Shape2 = (PerimeterMeasurable) s2;
				double perimeterShape1 = Shape1.getPerimeter();
				double perimeterShape2 = Shape2.getPerimeter();

				return perimeterShape1 < perimeterShape2 ? -1
						: perimeterShape1 > perimeterShape2 ? 1 : 0;
			};

			List<Shape> shapeByPerimeter = Arrays.asList(shapesArr).stream()
					.filter(s -> s instanceof PerimeterMeasurable)
					.sorted(byPerimeter).collect(Collectors.toList());

			for (Shape shape : shapeByPerimeter) {
				System.out.println(shape.toString());
				System.out.println("----------");
			}

		} catch (IllegalArgumentException e) {
			System.out.println(e.getMessage());
		} catch (NullPointerException e) {
			System.out.println("There is a null element in the array.");
		}

	}
}
