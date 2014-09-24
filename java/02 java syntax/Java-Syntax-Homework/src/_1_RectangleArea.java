import java.util.Scanner;

public class _1_RectangleArea {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int firstSide = input.nextInt();
        int secondSide = input.nextInt();
        int rectanglesArea = firstSide * secondSide;
        
        System.out.println(rectanglesArea);
    }
    
}