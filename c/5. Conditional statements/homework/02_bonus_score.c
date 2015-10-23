#include <stdio.h>

int main() {
    int score = 0;
    
    printf("score = ");
    scanf("%d", &score);
    
    if (score >= 1 && score <= 3)
    {
        score *= 10;
    }
    else if (score >= 4 && score <= 6)
    {
        score *= 100;
    }
    else if (score >= 7 && score <= 9)
    {
        score *= 1000;
    }
    
    if (score)
    {
        printf("result = %d", score);
    }
    else
    {
        printf("%s", "invalid score");
    }

    return 0;
}