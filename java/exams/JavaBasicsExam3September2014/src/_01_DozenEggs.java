import java.util.Scanner;


public class _01_DozenEggs {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);

		int totalEggs = 0;
		
		for (int i = 0; i < 7; i++) {
			String[] currentInput = scan.nextLine().split(" ");

			int count = Integer.parseInt(currentInput[0]);
			String measure = currentInput[1];
			
			if(measure.equals("eggs")) {
				totalEggs += count;
			}
			else {
				totalEggs += 12 * count;
			}
		}

		int dozens = totalEggs / 12;
		int eggs = totalEggs % 12;

		System.out.printf("%d dozens + %d eggs", dozens, eggs);
	}

}
