import java.text.DecimalFormat;
import java.util.Scanner;

public class _05_AngleUnitConverter {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        
        int n = input.nextInt();
        String[] convertedUnits = new String[n];
        
        for (int i = 0; i < n; i++) {
            double currentUnit = input.nextDouble();
            String currentMeasure = input.nextLine().trim();
            String output = "";
            DecimalFormat unitFormat = new DecimalFormat("#.######");
            
            if(currentMeasure.equals("deg")) {
                output = unitFormat.format(convertDegreesToRadians(currentUnit)) + " rad";
            }
            else if(currentMeasure.equals("rad")) {
                output = unitFormat.format(convertRadiansToDegrees(currentUnit)) + " deg";
            }
            
            convertedUnits[i] = output;
        }
        
        for (String convertedUnit : convertedUnits) {
            System.out.println(convertedUnit);
        }
    }
    
    public static double convertDegreesToRadians(double unit) {
        return (unit * Math.PI) / 180;
    }
    
    public static double convertRadiansToDegrees(double unit) {
        return (unit * 180) / Math.PI;
    }
    
}