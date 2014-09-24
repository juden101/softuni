import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class _11_MostFrequentWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] words = scan.nextLine().toLowerCase().split("\\W+");
		Map<String, Integer> wordsCount = new HashMap<String, Integer>();
		int mostFrequentWordCount = 0;
		
		for (String word : words) {
			Integer count = wordsCount.get(word);

			if (count == null) {
				count = 0; 
			}
			
			wordsCount.put(word, count + 1);
		}
		
		for (String word : wordsCount.keySet()) {
			int count = wordsCount.get(word);
			
			if(count > mostFrequentWordCount) {
				mostFrequentWordCount = count;
			}
		}
		
		for (String word : wordsCount.keySet()) {
			int count = wordsCount.get(word);
			
			if(count == mostFrequentWordCount) {
				System.out.printf("%s -> %d times\n", word, count);
			}
		}
	}

}