import java.io.*;
import java.util.Arrays;

public class SortArrayOfStrings {

    public static void main(String[] args) {
        InputStreamReader istream = new InputStreamReader(System.in);
        BufferedReader bufRead = new BufferedReader(istream);

        try {
            System.out.print("n = ");
            int n = Integer.parseInt(bufRead.readLine());
            String[] cities = new String[n];

            for(int i = 0; i < n; i++) {
                String currentCity = bufRead.readLine();
                cities[i] = currentCity;
            }

            Arrays.sort(cities);

            for(int i = 0; i < n; i++) {
                String currentCity = cities[i];
                System.out.println(currentCity);
            }
        } catch (Exception err) {
            System.out.println("Please enter corrent number!");
        }
    }

}
