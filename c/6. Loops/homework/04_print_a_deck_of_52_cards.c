#include <stdio.h>
#include <stdlib.h>

int main() {
    int i, j;
    
    for (i = 2; i < 15; i++) {
        for (j = 0; j < 4; j++) {
            if (i < 11) {
                printf("%d", i);
            } else if (i == 11) {
                printf("J");
            } else if (i == 12) {
                printf("Q");
            } else if (i == 13) {
                printf("K");
            } else {
                printf("A");
            }
            
            switch (j)
            {
                case 0:
                    printf("♣ ");
                    break;
                case 1:
                    printf("♦ ");
                    break;
                case 2:
                    printf("♥ ");
                    break;
                case 3:
                    printf("♠\n");
                    break;
                default:
                    break;
            }
        }
    }

    return 0;
}