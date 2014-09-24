import java.util.Scanner;

public class _6_FormattingNumbers {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int a = input.nextInt();
        float b = input.nextFloat();
        float c = input.nextFloat();
        
        System.out.printf("|%-10s|", Integer.toHexString(a).toUpperCase());
        System.out.printf("%010d|", new Integer(Integer.toBinaryString(a)));
        System.out.printf("%10.2f|", b);
        System.out.printf("%-10.3f|", c);
    }
    
}
