import java.awt.Polygon;
import java.util.Scanner;

public class _8_PointsInsideTheHouse {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        float x = input.nextFloat();
        float y = input.nextFloat();
        boolean isIn = IsInTriangle(x, y) || IsInRectangles(x, y);
        
        if(isIn) {
            System.out.println("Inside");
        }
        else {
            System.out.println("Outside");
        }
    }
    
    public static boolean IsInTriangle(float x, float y) {
        boolean isIn = false;
        
        double x1 = 12.5f, y1 = 8.5f;
        double x2 = 17.5f, y2 = 3.5f;
        double x3 = 22.5f, y3 = 8.5f;
        
        double abc = Math.abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        double abp = Math.abs(x1 * (y2 - y) + x2 * (y - y1) + x * (y1 - y2));
        double apc = Math.abs(x1 * (y - y3) + x * (y3 - y1) + x3 * (y1 - y));
        double pbc = Math.abs(x * (y2 - y3) + x2 * (y3 - y) + x3 * (y - y2));
        
        if (abp + apc + pbc == abc) {
            isIn = true;
        }
        
        return isIn;
    }
    
    public static boolean IsInRectangles(float x, float y) {
        boolean left = false;
        boolean right = false;
        
        if((x >= 12.5 && x <= 17.5 && y >= 8.5 && y <= 13.5)) {
            left = true;
        }
        
        if((x >= 20.0 && x <= 22.5 && y >= 8.5 && y <= 13.5)) {
            right = true;
        }
        
        return left || right;
    }
}
