import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class _07_DaysBetweenTwoDates {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String firstInput = input.nextLine();
        String secondInput = input.nextLine();
        
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy"); 
        
        try {
            Date firstDate = dateFormat.parse(firstInput);
            Date secondDate = dateFormat.parse(secondInput);
            
            System.out.println(daysDiff(firstDate, secondDate));
        } catch (ParseException ex) {
            System.out.println("Error with your input date!");
        }
    }
    
    public static long daysDiff(Date from, Date to) {
        return daysDiff(from.getTime(), to.getTime());
    }

    public static long daysDiff(long from, long to) {
        return Math.round((to - from) / 86400000D);
    }
    
}
