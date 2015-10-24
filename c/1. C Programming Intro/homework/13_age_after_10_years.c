#include <stdio.h>
#include <time.h>

int main() {
    char data[10];
    int day, month, year, currentYear;
    time_t rawtime;
    struct tm * timeinfo;

    time(&rawtime);
    timeinfo = localtime(&rawtime);
    currentYear = timeinfo->tm_year + 1900;
    
    scanf("%s", data);
    sscanf(data, "%d.%d.%d", &day, &month, &year);
    
    printf("Now: %d\n", currentYear - year);
    printf("After 10 years: %d\n", currentYear - year + 10);
    
    return 0;
}