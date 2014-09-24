import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;

public class _02_MagicSum {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int D = Integer.parseInt(scan.nextLine());
		ArrayList<Integer> allNumbers = new ArrayList<>();
		boolean found = false;
		int maxSum = Integer.MIN_VALUE;
		int firstNumber = 0, secondNumber = 0, thirdNumber = 0;
		
		while(true) {
			String currentLine = scan.nextLine();
			
			if(!currentLine.equals("End")) {
				int currentNumber = Integer.parseInt(currentLine);
				allNumbers.add(currentNumber);
			}
			else {
				break;
			}
		}
		
		for (int i = 0; i < allNumbers.size() - 2; i++) {
			for (int j = i + 1; j < allNumbers.size() - 1; j++) {
				for (int k = j + 1; k < allNumbers.size(); k++) {
					int a = allNumbers.get(i);
					int b = allNumbers.get(j);
					int c = allNumbers.get(k);
					int sum = a + b + c;
					
					if (sum % D == 0) {
						if(sum > maxSum) {
							maxSum = sum;
							firstNumber = a;
							secondNumber = b;
							thirdNumber = c;
							found = true;
						}
					}
				}
			}
		}
		
		if(found) {
			System.out.printf("(%d + %d + %d) %% %d = 0", firstNumber, secondNumber, thirdNumber, D);
		}
		else {
			System.out.println("No");
		}
	}

}