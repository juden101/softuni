import java.util.Scanner;
import java.util.TreeMap;

public class _03_ExamScore {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        TreeMap<Integer, TreeMap<String, Double>> scores = new TreeMap<>();
        
        scan.nextLine();
        scan.nextLine();
        scan.nextLine();
        
        while(true) {
        	String[] input = scan.nextLine().split("\\s*\\|\\s*");
			if (input.length < 4) {
				// The footer line is reached
				break;
			}
			
			String student = input[1];
        	int score = Integer.parseInt(input[2]);
        	double grade = Double.parseDouble(input[3]);

        	if (!scores.containsKey(score)) {
        		scores.put(score, new TreeMap<>());
			}
        	scores.get(score).put(student, grade);		
        }

        for (Integer score : scores.keySet()) { 
			System.out.print(score + " -> "); // Loop by key and print it
			System.out.print(scores.get(score).keySet()); // print keys of inner map (names)
			double sum = 0;
			// Loop through the values of the inner map and calculate the average
			for (double grade : scores.get(score).values()) { 
				sum += grade;
			}
			double avg = sum / scores.get(score).values().size();
			System.out.printf("; avg=%.2f\n", avg);
		}
    }
    
}