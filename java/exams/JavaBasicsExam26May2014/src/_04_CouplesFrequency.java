import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _04_CouplesFrequency {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] allNumbers = input.nextLine().split(" ");
        List<Couple> couples = new ArrayList<>();
        double allOccurrences = 0;
        
        for (int i = 0; i < allNumbers.length - 1; i++) {
            int currentA = Integer.parseInt(allNumbers[i]);
            int currentB = Integer.parseInt(allNumbers[i + 1]);
            
            if(couples.isEmpty()) {
                couples.add(new Couple(currentA, currentB));
                allOccurrences++;
                
                continue;
            }
            
            boolean coupleExist = false;
            for (Couple couple : couples) {
                if(couple.isEqualTo(currentA, currentB)) {
                    couple.increaseOccurrence();
                    allOccurrences++;
                    coupleExist = true;
                    
                    break;
                }
            }
            
            if(!coupleExist) {
                couples.add(new Couple(currentA, currentB));
                allOccurrences++;
            }
        }
        
        for (Couple couple : couples) {
            double currentPercantage = couple.getOccurrence() / allOccurrences * 100d;
            
            System.out.printf("%d %d -> %.2f", couple.getA(), couple.getB(), currentPercantage);
            System.out.println("%");
        }
    }
    
    public static class Couple {
        
        private int a;
        private int b;
        private int occurrence = 0;
        
        public Couple(int a, int b) {
            this.a = a;
            this.b = b;
            
            this.increaseOccurrence();
        }
        
        public boolean isEqualTo(int a, int b) {
            if(this.a == a && this.b == b) {
                return true;
            }
            
            return false;
        }
        
        public void increaseOccurrence() {
            this.occurrence++;
        }
        
        public int getA() {
            return this.a;
        }
        
        public int getB() {
            return this.b;
        }
        
        public int getOccurrence() {
            return this.occurrence;
        }
        
    }

}
