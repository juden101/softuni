#include <stdio.h>
#include <string.h>

int main() {
    char* card;

    printf("card = ");
    scanf("%s", card);
    
    if (are_equal(card, "2") ||
        are_equal(card, "3") ||
        are_equal(card, "4") ||
        are_equal(card, "5") ||
        are_equal(card, "6") ||
        are_equal(card, "7") ||
        are_equal(card, "8") ||
        are_equal(card, "9") ||
        are_equal(card, "10") ||
        are_equal(card, "J") ||
        are_equal(card, "Q") ||
        are_equal(card, "K") ||
        are_equal(card, "A"))
    {
        printf("%s", "yes");
    }
    else
    {
        printf("%s", "no");
    }
    
    return 0;
}

int are_equal(char* s1, char* s2)
{
    return strcmp(s1, s2) == 0;
}