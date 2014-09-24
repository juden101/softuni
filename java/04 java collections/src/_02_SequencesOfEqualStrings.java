import java.util.HashMap;
import java.util.Scanner;

public class _02_SequencesOfEqualStrings {

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
        
        for (HashMap.Entry<String, Integer> entry : sequences.entrySet()) {
        	for (int i = 0; i < entry.getValue(); i++) {
				System.out.print(entry.getKey() + " ");
			}
        	
            System.out.println();
        }
	}

}
