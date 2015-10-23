#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* get_number(int number);

int main() {
    int number;
    
    printf("number = ");
    scanf("%d", &number);
    
    if(number >= 0 && number <= 19)
    {
        printf("%s", get_number(number));
    }
    else if(number > 19 && number < 100)
    {
        if (number % 10 == 0)
        {
            printf("%s", get_number(number));
        }
        else
        {
            printf("%s %s", get_number((number / 10) * 10), get_number(number % 10));
        }
    }
    else if (number > 99 && number < 1000)
    {
        if (number % 100 == 0)
        {
            printf("%s %s", get_number(number / 100), get_number(100));
        }
        else
        {
            printf("%s %s and %s %s", 
                get_number(number / 100),
                get_number(100),
                get_number(((number / 10) % 10) * 10),
                get_number(number % 10));
        }
    }
    else
    {
        printf("enter valid number");
    }

    return 0;
}

char* get_number(int number)
{
    char *word;

    switch (number)
    {
        case 0:
            word = "zero";

            break;
        case 1:
            word = "one";

            break;
        case 2:
            word = "two";

            break;
        case 3:
            word = "three";

            break;
        case 4:
            word = "four";

            break;
        case 5:
            word = "five";

            break;
        case 6:
            word = "six";

            break;
        case 7:
            word = "seven";

            break;
        case 8:
            word = "eight";

            break;
        case 9:
            word = "nine";

            break;
        case 10:
            word = "ten";

            break;
        case 11:
            word = "eleven";

            break;
        case 12:
            word = "twelve";

            break;
        case 13:
            word = "thirteen";

            break;
        case 14:
            word = "fourteen";

            break;
        case 15:
            word = "fifteen";

            break;
        case 16:
            word = "sixteen";

            break;
        case 17:
            word = "seventeen";

            break;
        case 18:
            word = "eighteen";

            break;
        case 19:
            word = "nineteen";

            break;
        case 20:
            word = "twenty";

            break;
        case 30:
            word = "thirty";

            break;
        case 40:
            word = "fourty";

            break;
        case 50:
            word = "fifty";

            break;
        case 60:
            word = "sixty";

            break;
        case 70:
            word = "seventy";

            break;
        case 80:
            word = "eighty";

            break;
        case 90:
            word = "ninety";

            break;
        case 100:
            word = "hundred";

            break;
        default:
            break;
    }

    return word;
}