import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _01_VideoDurations {
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        List<Integer> durations = new ArrayList<>();
        int totalDuration = 0;
        String currentDuration = input.nextLine();
        
        while(!currentDuration.equals("End")) {
            durations.add(convertDurationToSeconds(currentDuration));
            
            currentDuration = input.nextLine();
        }
        
        for (Integer duration : durations) {
            totalDuration += duration;
        }
        
        System.out.printf("%d:%02d",  totalDuration / 60, totalDuration % 60);
    }
    
    public static int convertDurationToSeconds(String duration) {
        int seconds = 0;
        
        String[] splittedDuration = duration.split(":");
        seconds += Integer.parseInt(splittedDuration[0]) * 60;
        seconds += Integer.parseInt(splittedDuration[1]);
        
        return seconds;
    }
    
}
