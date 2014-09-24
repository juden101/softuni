import java.util.HashSet;
import java.util.Scanner;

public class _01_CognateWords {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        
        String[] words = scan.nextLine().split("[^a-zA-Z]+");
        HashSet<String> cognateWords = new HashSet<>();
        
        for (int a = 0; a < words.length; a++) {
			for (int b = 0; b < words.length; b++) {
				for (int c = 0; c < words.length; c++) {
					String firstWord = words[a];
					String secondWord = words[b];
					String thirdWord = words[c];
				
					if((firstWord + secondWord).equals(thirdWord)) {
						cognateWords.add(firstWord + "|" + secondWord + "=" + thirdWord);
					}
				}
			}
		}
        
        if(cognateWords.isEmpty()) {
        	System.out.println("No");
        }
        else {
        	for (String word : cognateWords) {
				System.out.println(word);
			}
        }
    }
    
}