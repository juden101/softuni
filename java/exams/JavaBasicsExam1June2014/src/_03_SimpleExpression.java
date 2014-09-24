import java.math.BigDecimal;
import java.util.Scanner;

public class _03_SimpleExpression {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        
        String expression = scan.nextLine().replaceAll(" ", "");
		String[] numbers = expression.split("[^0-9.]+");
		String[] operators = expression.split("[0-9.]+");
		
		BigDecimal sum = new BigDecimal(numbers[0]);
		
		for (int i = 1; i < operators.length; i++) {
			BigDecimal number = new BigDecimal(numbers[i]);
			
			if (operators[i].equals("+")) {
				sum = sum.add(number);
			} else if (operators[i].equals("-")) {
				sum = sum.subtract(number);
			}
		}
		
		System.out.println(sum.toPlainString());
    }
    
}