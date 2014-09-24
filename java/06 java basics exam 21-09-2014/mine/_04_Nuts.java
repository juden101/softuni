import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class _04_Nuts {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = Integer.parseInt(scan.nextLine());
		TreeMap<String, LinkedHashMap<String, Integer>> nuts = new TreeMap<>();
		
		for (int i = 0; i < n; i++) {
			String[] currentLine = scan.nextLine().split(" ");
			
			String company = currentLine[0];
			String nut = currentLine[1];
			int amount = Integer.parseInt(currentLine[2].substring(0, currentLine[2].length() - 2));
			
			if (!nuts.containsKey(company)) {
				LinkedHashMap<String, Integer> currentNut = new LinkedHashMap<>();
				currentNut.put(nut, amount);
				nuts.put(company, currentNut);
			}
			else {
				LinkedHashMap<String, Integer> currentNut = nuts.get(company);
				if (!currentNut.containsKey(nut)) {
					currentNut.put(nut, amount);
				}
				else {
					int tempAmount = currentNut.get(nut);
					tempAmount += amount;
					currentNut.put(nut, tempAmount);
				}
				nuts.put(company, currentNut);
			}
		}
		
		for (Iterator it = nuts.entrySet().iterator(); it.hasNext();) {
			Map.Entry companies = (Map.Entry) it.next();
			
			String outputLine = companies.getKey() + ": ";

			LinkedHashMap currentNuts = (LinkedHashMap) companies.getValue();
			for (Iterator it2 = currentNuts.entrySet().iterator(); it2.hasNext();) {
				Map.Entry user = (Map.Entry) it2.next();
				
				outputLine += user.getKey() + "-" + user.getValue() + "kg, ";
			}

			outputLine = outputLine.substring(0, outputLine.length() - 2);
			System.out.println(outputLine);
		}
	}

}