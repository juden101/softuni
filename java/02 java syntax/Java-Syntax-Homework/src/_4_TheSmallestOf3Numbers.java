import java.util.Scanner;

public class _4_TheSmallestOf3Numbers {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        
        float min = Float.MAX_VALUE;
        
        for(int i = 0; i < 3; i++) {
            float currentNumber = input.nextFloat();
            
            if(currentNumber < min) {
                min = currentNumber;
            }
        }
        
        System.out.println(new Float(min).toString().replaceAll("\\.0", ""));
    }
    
}
