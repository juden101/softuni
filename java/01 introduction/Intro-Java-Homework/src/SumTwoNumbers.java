import java.io.*;
import java.util.Arrays;

public class SumTwoNumbers {

    public static void main(String[] args) {
        InputStreamReader istream = new InputStreamReader(System.in);
        BufferedReader bufRead = new BufferedReader(istream);

        try {
            System.out.print("a = ");
            int a = Integer.parseInt(bufRead.readLine());

            System.out.print("b = ");
            int b = Integer.parseInt(bufRead.readLine());

            int result = a + b;
            System.out.print("result = " + result);
        } catch (Exception err) {
            System.out.println("Please enter corrent number!");
        }
    }

}
