import java.util.LinkedHashMap;
import java.util.Scanner;

public class _12_CardsFrequencies {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] cards = scan.nextLine().split("\\W+");
		LinkedHashMap<String, Integer> cardsCount = new LinkedHashMap<>();
		
		for (int i = 0; i < cards.length; i++) {
            if(!cardsCount.containsKey(cards[i])){
            	cardsCount.put(cards[i], 1);
            }
            else {
            	cardsCount.put(cards[i], cardsCount.get(cards[i]) + 1);
            }
		}
		
		for (String word : cardsCount.keySet()) {
			int count = cardsCount.get(word);
			
			System.out.printf("%s -> %.2f%% \n", word, ((double)count / cards.length) * 100);
		}
	}

}