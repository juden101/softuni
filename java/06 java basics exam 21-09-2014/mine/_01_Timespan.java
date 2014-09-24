import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

public class _01_Timespan {

	public static void main(String[] args) throws ParseException {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String startTime = scan.nextLine();
		String endTime = scan.nextLine();
		
		int totalStartTime = 0;
		int totalEndTime = 0;
		
		DateFormat df = new SimpleDateFormat("HH:mm:ss");
		Date firstTime =  df.parse(startTime);  
		Date secondTime =  df.parse(endTime);  
		
		long diff = firstTime.getTime() - secondTime.getTime();
        long diffSeconds = diff / 1000 % 60;
        long diffMinutes = diff / (60 * 1000) % 60;
        long diffHours = diff / (60 * 60 * 1000);

		
	    System.out.printf("%d:%02d:%02d", diffHours, diffMinutes, diffSeconds);
	}

}