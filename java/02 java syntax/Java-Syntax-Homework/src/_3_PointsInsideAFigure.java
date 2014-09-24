import java.util.Scanner;

public class _3_PointsInsideAFigure {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        float x = input.nextFloat();
        float y = input.nextFloat();
        
        if(IsIn(x, y)) {
            System.out.println("Inside");
        }
        else {
            System.out.println("Outside");
        }
    }
    
    public static boolean IsIn(float x, float y) {
        boolean top = false;
        boolean left = false;
        boolean right = false;
        
        if((x >= 12.5 && x <= 22.5 && y >= 6 && y <= 8.5))
        {
            top = true;
        }
        
        if((x >= 12.5 && x <= 17.5 && y >= 8.5 && y <= 13.5)) {
            left = true;
        }
        
        if((x >= 20.0 && x <= 22.5 && y >= 8.5 && y <= 13.5)) {
            right = true;
        }
        
        return top || left || right;
    }
    
}