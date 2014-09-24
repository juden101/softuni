import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _08_ExtractEmails {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String text = scan.nextLine().toLowerCase();
	    Matcher emailMatcher = Pattern.compile("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-]+").matcher(text);
	    
	    while (emailMatcher.find()) {
	        System.out.println(emailMatcher.group());
	    }
	}

}