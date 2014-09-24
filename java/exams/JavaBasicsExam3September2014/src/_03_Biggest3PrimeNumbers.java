import java.util.Scanner;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_Biggest3PrimeNumbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		String inputLine = scan.nextLine();
		TreeSet<Integer> primeNumbers = new TreeSet<>();
		
		Pattern phonePattern = Pattern.compile("[0-9-]+");
		Matcher matcher = phonePattern.matcher(inputLine);
		while (matcher.find()) {
			int currentNumber = Integer.parseInt(matcher.group());
			
			if(isPrime(currentNumber)) {
				primeNumbers.add(currentNumber);
			}
		}
		
		if(primeNumbers.size() > 2) {
			int primeNumbersSum = 0;
			
			for (int i = 0; i < 3; i++) {
				primeNumbersSum += primeNumbers.pollLast();
			}
			
			System.out.println(primeNumbersSum);
		}
		else {
			System.out.println("No");
		}
	}
	
	public static boolean isPrime(int number) {
        boolean isPrime = true;
       
        if(number == 0) return false; 
        if(number == 1) return false; 
        
        for (int i = 2; i < number; i++) {
                if (number % i == 0) {
                        isPrime = false;
                }
        }
       
        return isPrime;
}

}