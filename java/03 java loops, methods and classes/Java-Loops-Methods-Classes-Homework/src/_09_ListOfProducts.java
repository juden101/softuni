import java.io.File;
import java.util.List;
import java.util.Scanner;
import java.util.ArrayList;
import java.io.IOException;
import java.util.Comparator;
import java.util.Collections;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.io.FileNotFoundException;

public class _09_ListOfProducts {

    public static void main(String[] args) {
        String inputFileName = "src/_09_Input.txt";
        String outputFileName = "src/_09_Output.txt";
        
        try {
            File textFile = new File(inputFileName);
            Scanner scan = new Scanner(textFile);
            
            List<Product> products = new ArrayList<>();
            
            while (scan.hasNext()) {
                String[] currentProduct = scan.nextLine().split(" ");
                String name = currentProduct[0];
                double price = Double.parseDouble(currentProduct[1]);
                
                products.add(new Product(name, price));
            }
            
            Collections.sort(products, Comparator.comparing(p -> p.price));
            
            BufferedWriter writer = null;
            try {
                writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(outputFileName), "utf-8"));
                
                for (Product product : products) {
                    writer.write(product.toString() + "\n");
                }
            } catch (IOException ex) {
                System.out.println("Error");
            } finally {
               try {writer.close();} catch (IOException ex) {System.out.println("Error");}
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Error");
        }
        
    }
    
    public static class Product {

        private String name;
        private double price;
        
        public Product(String n, double p) {
            name = n;
            price = p;
        }
        
        @Override
        public String toString() {
            return price + " " + name;
        }
        
    }
    
}