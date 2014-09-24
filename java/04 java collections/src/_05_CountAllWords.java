import java.util.Scanner;

public class _05_CountAllWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String inputLine = scan.nextLine();
		String[] words = inputLine.split("\\W+");
		
		System.out.println(words.length);
	}

}