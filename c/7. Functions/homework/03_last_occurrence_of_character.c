#include <stdio.h>
#include <string.h>

int last_occurrence(char *str, char ch);

int main() {
    int result;
    char str[1024], ch;
    
    printf ("str = ");
    gets(str);
    
    printf("ch = ");
    scanf("%c", &ch);
    
    result = last_occurrence(str, ch);
    printf("position = %d", result);
    
    return 0;
}

int last_occurrence(char *str, char ch) {
    int position = -1, i, strLength = strlen(str);
    
    for (i = 0; i < strLength; i++) {
        if (str[i] == ch) {
            position = i;
        }
    }
    
    return position;
}