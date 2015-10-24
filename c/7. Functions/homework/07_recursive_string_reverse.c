#include <stdio.h>
#include <string.h>

void reverse_string(char arr[], size_t iStart, size_t iLast);

int main() {
    char str[] = { "Recursion" };
    reverse_string(str, 0, strlen(str)-1);
    
    printf("%s", str);

    return 0;
}

void reverse_string(char arr[], size_t iStart, size_t iLast) {
    if (iStart < iLast) {
        char temp = arr[iStart];
        arr[iStart] = arr[iLast];
        arr[iLast] = temp;

        reverse_string(arr, ++iStart, --iLast);  
    }
}