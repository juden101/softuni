#include <stdio.h>

int main() {
    int type;

    printf("1 --> int\n2 --> double\n3 --> string\n");
    printf("Please choose a type: ");
    scanf("%d", &type);

    switch (type)
    {
        case 1:
            printf("Please enter an int: ");
        
            int intN;
            scanf("%d", &intN);
        
            printf("result: %d", ++intN);
            break;
        case 2:
            printf("Please enter a double: ");
        
            double doubleN;
            scanf("%lf", &doubleN);

            printf("result: %.1lf", ++doubleN);
            break;
        case 3:
            printf("Please enter a string: ");
        
            char *stringN;
            scanf("%s", stringN);

            printf("result: %s*", stringN);
            break;
        default:
            break;
    }
    
    return 0;
}