import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_WeirdStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String input = scan.nextLine().replaceAll("[\\\\\\/()|\\s]+", "");
		ArrayList<String> words = new ArrayList<>();
		ArrayList<Integer> sums = new ArrayList<>();
		
		Pattern phonePattern = Pattern.compile("[a-zA-Z]+");
		Matcher matcher = phonePattern.matcher(input);
		while (matcher.find()) {
			String currentWord = matcher.group();
			words.add(currentWord);
		}
		
		for (int i = 0; i < words.size(); i++) {
			int wordSum = 0;
			
			String currentWord = words.get(i).toLowerCase();
			for (char character : currentWord.toCharArray()) {
				wordSum += character - 96;
			}
			
			sums.add(wordSum);
		}

		int maxSum = Integer.MIN_VALUE;
		String firstWord = "";
		String secondWord = "";
		for (int a = 0; a < words.size() - 1; a++) {
			String word1 = words.get(a);
			Integer word1Sum = sums.get(a);
			
			String word2 = words.get(a + 1);
			Integer word2Sum = sums.get(a + 1);
			
			int currentMaxSum = word1Sum + word2Sum;
			
			if(currentMaxSum > maxSum) {
				maxSum = currentMaxSum;
				firstWord = word1;
				secondWord = word2;
			}
		}
		
		System.out.println(firstWord);
		System.out.println(secondWord);
	}

}
