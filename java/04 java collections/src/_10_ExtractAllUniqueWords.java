import java.util.Collections;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] allWords = scan.nextLine().toLowerCase().split("\\W+");
		Set<String> uniqueWords = new TreeSet<>();
		Collections.addAll(uniqueWords, allWords);
		
		for (String uniqueWord : uniqueWords) {
			System.out.println(uniqueWord + " ");
		}
	}

}