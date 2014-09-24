import java.util.Scanner;

public class _02_SumNumbers {
    
    public static void main(String[] args) {
        @SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
        
        String[] allCards = scan.nextLine().split(" ");
        String lastCard = "";
        int sum = 0;
        int sequence = 0;
        
        for (int i = 0; i <= allCards.length; i++) {
        	if(i == allCards.length) {
        		if(sequence > 1) {
    				sum += sequence * valueOf(lastCard) * 2;
    			}
    			else {
    				sum += valueOf(lastCard);
    			}
        		
        		break;
        	}
        	
    		String currentCard = allCards[i].substring(0, allCards[i].length() - 1);
        	
        	if(i == 0) {
        		sequence++;
        	}
        	else {
        		if(lastCard.equals(currentCard)) {
        			sequence++;
        		}
        		else {
        			if(sequence > 1) {
        				sum += sequence * valueOf(lastCard) * 2;
        			}
        			else {
        				sum += valueOf(lastCard);
        			}
        			
        			sequence = 1;
        		}
        	}
        	
    		lastCard = currentCard;
		}
        
        System.out.println(sum);
    }
    
    public static int valueOf(String card) {
    	int value = 0;
    	
    	switch (card) {
		case "2":
			value = 2;
			break;
		case "3":
			value = 3;
			break;
		case "4":
			value = 4;
			break;
		case "5":
			value = 5;
			break;
		case "6":
			value = 6;
			break;
		case "7":
			value = 7;
			break;
		case "8":
			value = 8;
			break;
		case "9":
			value = 9;
			break;
		case "10":
			value = 10;
			break;
		case "J":
			value = 12;
			break;
		case "Q":
			value = 13;
			break;
		case "K":
			value = 14;
			break;
		case "A":
			value = 15;
			break;
		default:
			break;
		}
    	
    	return value;
    }
    
}