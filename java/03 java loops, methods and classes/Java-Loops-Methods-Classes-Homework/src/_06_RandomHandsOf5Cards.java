import java.util.Random;
import java.util.Scanner;

public class _06_RandomHandsOf5Cards {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        
        String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] suites = {'♣', '♦', '♥', '♠'};
        
        Random rand = new Random();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < 5; j++) {
                String currentCard = faces[rand.nextInt(faces.length)] + suites[rand.nextInt(suites.length)];
            
                System.out.print(currentCard + " ");
            }
            
            System.out.println();
        }
    }
    
}
