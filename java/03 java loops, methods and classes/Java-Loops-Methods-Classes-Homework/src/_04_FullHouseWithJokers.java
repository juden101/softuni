public class _04_FullHouseWithJokers {

    public static void main(String[] args) {
        String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A",};
        char[] suites = {'♣', '♦', '♥', '♠'};
        int counter = 0;
        
        String[] results = new String[5];
        
        for (int i = 0; i < faces.length; i++) {
            for (int j = 0; j < faces.length; j++) {
                if (i == j) {
                    continue;
                }
                
                for (int j2 = 0; j2 < suites.length; j2++) {
                    for (int k = j2 + 1; k < suites.length; k++) {
                        for (int k2 = k + 1; k2 < suites.length; k2++) {
                            for (int l = 0; l < suites.length; l++) {
                                for (int l2 = l + 1; l2 < suites.length; l2++) {
                                    for (int m = 0; m <= Math.pow(2, 5) - 1; m++) {
                                        int num = m;
                                        
                                        for (int m2 = 0; m2 < 5; m2++) {
                                            if (num % 2 == 1) {
                                                results[m2] = "*";
                                                num /= 2;
                                            }
                                        }
                                        
                                        System.out.printf("(%s %s %s %s %s)\n", results[4], results[3], results[2], results[1], results[0]);
                                        
                                        results[4] = faces[i] + suites[j2];
                                        results[3] = faces[i] + suites[k];
                                        results[2] = faces[i] + suites[k2];
                                        results[1] = faces[j] + suites[l];
                                        results[0] = faces[j] + suites[l2];
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        
        System.out.println(counter);
    }

}
