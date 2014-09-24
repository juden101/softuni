import java.util.Scanner;

public class _7_CountOfBitsOne {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        int count = 0;
        char[] binaryN = Integer.toBinaryString(n).toCharArray();
        char lastChar = ' ';

        for (char currentChar: binaryN) {
            if(lastChar == currentChar)
            {
                count++;
            }

            lastChar = currentChar;
        }
        
        System.out.println(count);
    }
    
}
