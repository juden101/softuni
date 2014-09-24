import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _09_CombineListsOfLetters {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] firstLine = scan.nextLine().split(" ");
		ArrayList<String> firstLetters = new ArrayList<>(Arrays.asList(firstLine));
		
		String[] secondLine = scan.nextLine().split(" ");
		ArrayList<String> secondLetters = new ArrayList<>(Arrays.asList(secondLine));

		ArrayList<String> combinedLetters = new ArrayList<>();
		combinedLetters.addAll(firstLetters);
		
		for (String secondLetter : secondLetters) {
			boolean letterExist = false;
			
			for (String firstLetter : firstLetters) {
				if(firstLetter.equals(secondLetter)) {
					letterExist = true;
				}
			}
			
			if(!letterExist) {
				combinedLetters.add(secondLetter);
			}
		}
		
		for (String letter : combinedLetters) {
			System.out.print(letter + " ");
		}
	}

}