import java.util.Scanner;

public class _03_LongestOddEvenSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine();
		String[] ints = inputLine.split("[ ()]+");
		int[] numbers = new int[ints.length-1];
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(ints[i+1]);
		}
		
		int bestLen = 0;
		int len = 0;
		boolean shouldBeOdd = (numbers[0] % 2 != 0);
		for (int num : numbers) {
			boolean isOdd = num % 2 != 0;
			if (isOdd == shouldBeOdd || num == 0) {
				len++;
			} else {
				shouldBeOdd = isOdd;
				len = 1;
			}
			shouldBeOdd = !shouldBeOdd;
			if (len > bestLen) {
				bestLen = len;
			}
		}
		
		System.out.println(bestLen);
	}

}