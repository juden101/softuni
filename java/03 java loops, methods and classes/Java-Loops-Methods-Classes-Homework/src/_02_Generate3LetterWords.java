import java.util.Scanner;

public class _02_Generate3LetterWords {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        char[] letters = input.nextLine().toCharArray();
        
        for (int i = 0; i < letters.length; i++) {
            for (int j = 0; j < letters.length; j++) {
                for (int k = 0; k < letters.length; k++) {
                    printLetters(letters[i], letters[j], letters[k]);
                }
            }
        }
    }
    
    public static void printLetters(char a, char b, char c) {
        System.out.printf("%s%s%s\n", a, b, c);
    }
    
}