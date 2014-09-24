import java.util.HashMap;
import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
        String[] elements = input.nextLine().split(" ");
        HashMap<String, Integer> sequences = new HashMap<String, Integer>(); 
        
        for (String element : elements) {
			if(!sequences.containsKey(element)) {
				sequences.put(element, 0);
			}
			
			sequences.put(element, sequences.get(element) + 1);
		}
        
        int largestSequenceValue = Integer.MIN_VALUE;
        String largestSequenceKey = "";
        for (HashMap.Entry<String, Integer> entry : sequences.entrySet()) {
        	if(entry.getValue() > largestSequenceValue) {
        		largestSequenceValue = entry.getValue();
        		largestSequenceKey = entry.getKey();
        	}
        }

        for (int i = 0; i < largestSequenceValue; i++) {
			System.out.print(largestSequenceKey + " ");
		}
	}

}