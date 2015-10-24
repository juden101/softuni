#include <stdio.h>

int main() {
    char firstName[] = "Ivan";
    char lastName[] = "Zahariev";
    unsigned char age = 19;
    int isMale = 1;
    unsigned long long personalIdNumber = 8306112507;
    unsigned int uniqueEmployeeNumber = 27569999;

    printf("First name: %s\n", firstName);
    printf("Last name: %s\n", lastName);
    printf("Age: %d\n", age);
    printf("Gender: %c\n", isMale ? 'm' : 'f');
    printf("Personal ID: %lld\n", personalIdNumber);
    printf("Unique employee number: %d\n", uniqueEmployeeNumber);
    
    return 0;
}