import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _03_Largest3Rectangles {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int maxTotalArea = 0;
        List<Rectangular> rectangulars = new ArrayList<>();
        String allAreas = input.nextLine().replaceAll("\\s+", "");

        Matcher matcher = Pattern.compile("\\[\\d+x\\d+\\]").matcher(allAreas);
        while (matcher.find()) {
            String[] currentMatch = matcher.group().replaceAll("[\\[\\]]", "").split("x");
            
            int currentA = Integer.parseInt(currentMatch[0]);
            int currentB = Integer.parseInt(currentMatch[1]);
            
            rectangulars.add(new Rectangular(currentA, currentB));
        }
        
        for (int i = 0; i < rectangulars.size() - 2; i++) {
            int currentTotalArea = rectangulars.get(i).getArea() + rectangulars.get(i + 1).getArea() + rectangulars.get(i + 2).getArea();
            
            if(currentTotalArea > maxTotalArea) {
                maxTotalArea = currentTotalArea;
            }
        }
        
        System.out.println(maxTotalArea);
    }

    public static class Rectangular {
        int a, b;
        
        public Rectangular(int a, int b) {
            this.a = a;
            this.b = b;
        }
        
        public int getArea() {
            return this.a * this.b;
        }
        
    }

}
