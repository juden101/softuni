import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.Scanner;

public class _9_PaintAHouseAsSVG {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        float currentX, currentY;
        Point[] points = new Point[n];
        
        for (int i = 0; i < n; i++) {
            currentX = input.nextFloat();
            currentY = input.nextFloat();
            boolean isIn = IsInTriangle(currentX, currentY) || IsInRectangles(currentX, currentY);
            
            points[i] = new Point(currentX, currentY, isIn);
        }
        
        BufferedWriter writer = null;
        try {
            writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream("house.html"), "utf-8"));
            writer.write("<!DOCTYPE html>");
            writer.write("<html>");
            writer.write("<body>");
            
            writer.write("<svg width=\"500\" height=\"500\" style=\"display: block; margin: 0 auto;\">");
                
                //Coordinate system x lines
                writer.write("<line x1=\"50\" y1=\"100\" x2=\"450\" y2=\"100\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"50\" y1=\"171\" x2=\"450\" y2=\"171\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"50\" y1=\"242\" x2=\"450\" y2=\"242\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"50\" y1=\"313\" x2=\"450\" y2=\"313\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"50\" y1=\"384\" x2=\"450\" y2=\"384\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"50\" y1=\"455\" x2=\"450\" y2=\"455\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                
                //Coordinate system y lines
                writer.write("<line x1=\"70\" y1=\"50\" x2=\"70\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"141\" y1=\"50\" x2=\"141\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"212\" y1=\"50\" x2=\"212\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"283\" y1=\"50\" x2=\"283\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"354\" y1=\"50\" x2=\"354\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                writer.write("<line x1=\"425\" y1=\"50\" x2=\"425\" y2=\"480\" stroke=\"blue\" stroke-width=\"1\" stroke-dasharray=\"3,3\" />");
                
                //Coordinates of x's
                writer.write("<text x=\"55\" y=\"40\" fill=\"black\" font-size=\"30\">10</text>");
                writer.write("<text x=\"115\" y=\"40\" fill=\"black\" font-size=\"30\">12.5</text>");
                writer.write("<text x=\"195\" y=\"40\" fill=\"black\" font-size=\"30\">15</text>");
                writer.write("<text x=\"260\" y=\"40\" fill=\"black\" font-size=\"30\">17.5</text>");
                writer.write("<text x=\"340\" y=\"40\" fill=\"black\" font-size=\"30\">20</text>");
                writer.write("<text x=\"400\" y=\"40\" fill=\"black\" font-size=\"30\">22.5</text>");
                
                //Coordinates of y's
                writer.write("<text x=\"5\" y=\"110\" fill=\"black\" font-size=\"30\">3.5</text>");
                writer.write("<text x=\"15\" y=\"180\" fill=\"black\" font-size=\"30\">6</text>");
                writer.write("<text x=\"5\" y=\"250\" fill=\"black\" font-size=\"30\">8.5</text>");
                writer.write("<text x=\"7\" y=\"320\" fill=\"black\" font-size=\"30\">11</text>");
                writer.write("<text x=\"0\" y=\"395\" fill=\"black\" font-size=\"30\">13.5</text>");
                writer.write("<text x=\"7\" y=\"465\" fill=\"black\" font-size=\"30\">16</text>");
                
                //House lines
                writer.write("<line x1=\"141\" y1=\"242\" x2=\"283\" y2=\"100\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"283\" y1=\"100\" x2=\"425\" y2=\"242\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"141\" y1=\"242\" x2=\"425\" y2=\"242\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"141\" y1=\"242\" x2=\"141\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"141\" y1=\"384\" x2=\"283\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />"); 
                writer.write("<line x1=\"283\" y1=\"242\" x2=\"283\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"354\" y1=\"242\" x2=\"354\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />");   
                writer.write("<line x1=\"354\" y1=\"384\" x2=\"425\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />");
                writer.write("<line x1=\"425\" y1=\"242\" x2=\"425\" y2=\"384\" stroke=\"darkblue\" stroke-width=\"2\" />");

                //House polygons
                writer.write("<polygon points=\"141,242 283,100 425,242\" style=\"fill:gray;fill-opacity:0.3;\" />");
                writer.write("<polygon points=\"141,242 283,242 283,384 141,384\" style=\"fill:gray;fill-opacity:0.3;\" />");
                writer.write("<polygon points=\"354,242 425,242 425,384 354,384\" style=\"fill:gray;fill-opacity:0.3;\" />");
                
                for(Point currentPoint : points) {
                    float currentPointX = ((currentPoint.x - 10) * 28.5f) + 70;
                    float currentPointY = currentPoint.y * 28.5f;
                    
                    if(currentPoint.isIn) {
                        writer.write("<circle cx=\"" + currentPointX + "\" cy=\"" + currentPointY + "\" r=\"7\" fill=\"black\" stroke=\"black\" stroke-width=\"1\" />");
                    }
                    else {
                        writer.write("<circle cx=\"" + currentPointX + "\" cy=\"" + currentPointY + "\" r=\"7\" fill=\"gray\" stroke=\"black\" stroke-width=\"1\" />");
                    }
                }
                
            writer.write("</svg>");
            
            writer.write("</body>");
            writer.write("</html>");
        } catch (IOException ex) {
            System.out.println("Something with the file gone wrong!");
        } finally {
            try {
                writer.close();
            } catch (IOException ex) {
                System.out.println("Can't close the file!");
            }
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
    
class Point {
    public float x;
    public float y;
    public boolean isIn;
    
    public Point(float X, float Y, boolean IsIn) {
        x = X;
        y = Y;
        isIn = IsIn;
    }
}