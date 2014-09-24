import java.util.ArrayList;
import java.util.Iterator;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class _04_ActivityTracker {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		int n = Integer.parseInt(scan.nextLine());
		TreeMap<Integer, TreeMap<String, Integer>> months = new TreeMap<>();
		
		for (int i = 0; i < n; i++) {
			String[] currentLine = scan.nextLine().split(" ");
			
			int month = Integer.parseInt(currentLine[0].substring(3, 5));
			String user = currentLine[1];
			int distance = Integer.parseInt(currentLine[2]);
			
			if (!months.containsKey(month)) {
				TreeMap<String, Integer> users = new TreeMap<>();
				users.put(user, distance);
				months.put(month, users);
			}
			else {
				TreeMap<String, Integer> users = months.get(month);
				if (!users.containsKey(user)) {
					users.put(user, distance);
				}
				else {
					int tempDistance = users.get(user);
					tempDistance += distance;
					users.put(user, tempDistance);
				}
				months.put(month, users);
			}
		}
		
		for (Iterator it = months.entrySet().iterator(); it.hasNext();) {
			Map.Entry month = (Map.Entry) it.next();
			
			String outputLine = month.getKey() + ": ";

			TreeMap users = (TreeMap) month.getValue();
			for (Iterator it2 = users.entrySet().iterator(); it2.hasNext();) {
				Map.Entry user = (Map.Entry) it2.next();
				
				outputLine += user.getKey() + "(" + user.getValue() + "), ";
			}

			outputLine = outputLine.substring(0, outputLine.length() - 2);
			System.out.println(outputLine);
		}
	}

}
