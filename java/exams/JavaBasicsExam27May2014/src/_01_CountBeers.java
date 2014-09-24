import java.util.Scanner;
import java.util.TreeSet;
import java.math.BigDecimal;

public class _01_CountBeers {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        
        int n = Integer.parseInt(scan.nextLine());
        TreeSet<BigDecimal> numbers = new TreeSet<>();
        
        for (int i = 0; i < n; i++) {
			BigDecimal currentNumber = new BigDecimal(scan.nextLine());
			
			numbers.add(currentNumber);
		}

        for (int i = 0; i < 3; i++) {
        	if(!numbers.isEmpty()) {
        		System.out.println(numbers.pollLast());
        	}
		}
    }
    
}