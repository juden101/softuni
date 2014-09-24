import java.util.Scanner;

public class _06_CountSpecifiedWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String inputLine = scan.nextLine();
		String[] words = inputLine.split("\\W+");
		String targetWord = scan.nextLine();
		int counter = 0;
		
		for (int i = 0; i < words.length; i++) {
			if(words[i].toLowerCase().equals(targetWord)) {
				counter++;
			}
		}
		
		System.out.println(counter);
	}

}