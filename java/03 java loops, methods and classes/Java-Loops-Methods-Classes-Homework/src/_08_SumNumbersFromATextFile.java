import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class _08_SumNumbersFromATextFile {

    public static void main(String[] args) {
        String fileName = "src/SumNumbersFromATextFileInput.txt";
        int sum = 0;
        
        try {
            File textFile = new File(fileName);
            Scanner scan = new Scanner(textFile);
            
            while (scan.hasNext()) {
                sum += scan.nextInt();
            }

            System.out.println(sum);
        } catch (FileNotFoundException ex) {
            System.out.println("Error");
        }
        
    }
    
}
