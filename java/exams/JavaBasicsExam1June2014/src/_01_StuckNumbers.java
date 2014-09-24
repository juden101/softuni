import java.util.Scanner;

public class _01_StuckNumbers {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        
        int n = Integer.parseInt(scan.nextLine());
        int[] numbers = new int[n];
        
        for(int i = 0; i < n; i++) {
        	numbers[i] = scan.nextInt();
        }
        
        boolean isCombination = false;
        for (int num1 = 0; num1 < numbers.length; num1++) {
			for (int num2 = 0; num2 < numbers.length; num2++) {
				for (int num3 = 0; num3 < numbers.length; num3++) {
					for (int num4 = 0; num4 < numbers.length; num4++) {
						int a = numbers[num1];
						int b = numbers[num2];
						int c = numbers[num3];
						int d = numbers[num4];
						
						if(a != b && a != c && a != d && b != c && b != d && c != d) {
							String firstCouple = "" + a + b;
							String secondCouple = "" + c + d;
							
							if(firstCouple.equals(secondCouple)) {
								System.out.println(a + "|" + b + "==" + c + "|" + d);
								isCombination = true;
							}
						}
					}
				}
			}
		}

        if(!isCombination) {
        	System.out.println("No");
        }
    }
    
}