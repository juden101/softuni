import java.util.Scanner;

public class _01_SymmetricNumbersInRange {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int start = input.nextInt();
        int end = input.nextInt();

        for(int i = start; i <= end; i++) {
            if(isNumberSymmetric(i)) {
                System.out.println(i);
            }
        }
    }
    
    public static boolean isNumberSymmetric(int number) {
        if(numberBetween(number, 0, 9)) {
            return true;
        }
        else if(numberBetween(number, 10, 99) && number % 10 == (number / 10) % 10) {
            return true;
        }
        else if(numberBetween(number, 100, 999) && number % 10 == (number / 100) % 10) {
            return true;
        }
        
        return false;
    }
    
    public static boolean numberBetween(int number, int start, int end) {
        if(number >= start && number <= end) {
            return true;
        }
        
        return false;
    }
    
}
