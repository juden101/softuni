import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _10_OrderOfProducts {

    public static void main(String[] args) {
        String productsFileName = "src/_10_Products.txt";
        String orderFileName = "src/_10_Order.txt";
        String outputFileName = "src/_10_Output.txt";
        
        try {
            File textFile = new File(productsFileName);
            Scanner scan = new Scanner(textFile);
            
            List<Product> products = new ArrayList<>();
            
            while (scan.hasNext()) {
                String[] currentProduct = scan.nextLine().split(" ");
                String name = currentProduct[0];
                double price = Double.parseDouble(currentProduct[1]);
                
                products.add(new Product(name, price));
            }
            
            try {
                File secondTextFile = new File(orderFileName);
                Scanner secondScan = new Scanner(secondTextFile);

                while (secondScan.hasNext()) {
                    String[] currentProduct = secondScan.nextLine().split(" ");
                    double quantity = Double.parseDouble(currentProduct[0]);
                    String name = currentProduct[1];

                    for (Product product : products) {
                        if(product.getName().equals(name)) {
                            product.addQuantity(quantity);
                        }
                    }
                }
            } catch (FileNotFoundException ex) {
                System.out.println("Error");
            }
            
            double totalPrice = 0;
            for (Product product : products) {
                totalPrice += product.getTotalPrice();
            }
            
            DecimalFormat df = new DecimalFormat("0.0");
            
            BufferedWriter writer = null;
            try {
                writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(outputFileName), "utf-8"));
                writer.write(df.format(totalPrice));
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
        private double totalPrice = 0;
        
        public Product(String n, double p) {
            name = n;
            price = p;
        }

        public String getName() {
            return name;
        }

        public double getTotalPrice() {
            return totalPrice;
        }
        
        public void addQuantity(double quantity) {
            totalPrice += price * quantity;
        }
        
        @Override
        public String toString() {
            return price + " " + totalPrice;
        }
        
    }
    
}