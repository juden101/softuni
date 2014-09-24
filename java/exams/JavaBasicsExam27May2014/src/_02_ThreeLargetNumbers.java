import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

public class _02_ThreeLargetNumbers {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		int n = Integer.parseInt(input.nextLine());
		
		BigDecimal[] nums = new BigDecimal[n];
		
		for (int i = 0; i < nums.length; i++) {
			nums[i] = new BigDecimal(input.nextLine());
		}
		
		Arrays.sort(nums);
		
		for (int i = nums.length - 1, count = 3; i >= 0 && count > 0; i--, count--) {
			System.out.println(nums[i].toPlainString());
		}
	}

}