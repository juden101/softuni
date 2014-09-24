import java.util.Scanner;

public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String inputLine = scan.nextLine();
		String[] inputNumbers = inputLine.split(" ");
		int[] numbers = new int[inputNumbers.length + 1];
		
		for (int i = 0; i < inputNumbers.length; i++) {
			numbers[i] = Integer.parseInt(inputNumbers[i]);
		}
		
		numbers[numbers.length - 1] = Integer.MIN_VALUE;
		
		int longestSequence = 1;
		int currentSequnce = 1;
		for (int i = 0; i < numbers.length - 1; i++) {
			if (numbers[i] < numbers[i + 1]) {
				currentSequnce++;
				
				System.out.print(numbers[i] + " ");
			} else {
				System.out.println(numbers[i]);
				
				if (longestSequence < currentSequnce) {
					longestSequence = currentSequnce;
				}
				
				currentSequnce = 1;
			}
		}

		for (int i = 0; i < numbers.length - 1; i++) {
			if (numbers[i] < numbers[i + 1]) {
				currentSequnce++;
			} else {
				if (longestSequence == currentSequnce) {
					System.out.print("Longest: ");
					
					for (int j = i - longestSequence + 1; j <= i; j++) {
						System.out.print(numbers[j] + " ");
					}
					
					break;
				}
				
				currentSequnce = 1;
			}
		}

	}

}