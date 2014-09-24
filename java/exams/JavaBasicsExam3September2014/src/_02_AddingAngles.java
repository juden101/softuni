import java.util.Scanner;

public class _02_AddingAngles {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = scan.nextInt();
		int[] angles = new int[n];
		
		for (int i = 0; i < n; i++) {
			angles[i] = scan.nextInt();
		}
		
		boolean isFullCircle = false;
		for (int a = 0; a < n; a++) {
			for (int b = a + 1; b < n; b++) {
				for (int c = b + 1; c < n; c++) {
					int firstAngle = angles[a];
					int secondAngle = angles[b];
					int thirdAngle = angles[c];
					int anglesSum = firstAngle + secondAngle + thirdAngle;
					
					if(anglesSum % 360 == 0) {
						System.out.printf("%d + %d + %d = %d degrees\n", firstAngle, secondAngle, thirdAngle, anglesSum);
						isFullCircle = true;
					}
				}
			}
		}
		
		if(!isFullCircle) {
			System.out.println("No");
		}
	}

}
