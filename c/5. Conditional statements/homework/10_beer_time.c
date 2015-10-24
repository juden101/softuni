#include <stdio.h>
#include <string.h>

#define TIME_SIZE 9

int main() {
    char time[TIME_SIZE] = "";
    int hour, minutes;
    
    printf("time: ");
    fgets(time, TIME_SIZE, stdin);
    
    if (strlen(time) == 8)
    {
        char hourArr[2] = { time[0], '\0' };
        char minutesArr[3] = { time[2], time[3], '\0' };
        
        hour = atoi(hourArr);
        minutes = atoi(minutesArr);
    }
    else if (strlen(time) == 9)
    {
        char hourArr[3] = { time[0], time[1], '\0' };
        char minutesArr[3] = { time[3], time[4], '\0' };
        
        hour = atoi(hourArr);
        minutes = atoi(minutesArr);
    }
    
    if (hour > 12 || hour < 3)
    {
        printf("%s", "beer time");
    }
    else
    {
        printf("%s", "non-beer time");
    }
    
    return 0;
}