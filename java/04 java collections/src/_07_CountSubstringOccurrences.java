import java.util.Scanner;

public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String text = scan.nextLine().toLowerCase();
		String targetWord = scan.nextLine();
		int counter = 0;
		int lastIndex = 0;

		while(lastIndex != -1){
			lastIndex = text.indexOf(targetWord, lastIndex);

			if(lastIndex != -1) {
				counter++;
				lastIndex++;
			}
		}
		
		System.out.println(counter);
	}

}