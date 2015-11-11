#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *substr(char * src, int position, int length);

int main() 
{
    char *line = NULL;
    size_t lineSize = 0;
    size_t lineLength = getline(&line, &lineSize, stdin);
    line[lineLength - 1] = '\0';
    double sum = 0;
    char *token = strtok(line, " \t");
    while (token)
    {
        size_t tokenLength = strlen(token);
        char firstLetter = token[0];
        char lastLetter = token[tokenLength - 1];
        char *number = substr(token, 1, tokenLength - 2);
        int num = atoi(number);
        if (firstLetter >= 'A' && firstLetter <= 'Z')
        {
            sum += (double)num / (firstLetter - 64);
        }
        else if (firstLetter >= 'a' && firstLetter <= 'z')
        {
            sum += (double)num * (firstLetter - 96);
        }
        
        if (lastLetter >= 'A' && lastLetter <= 'Z')
        {
            sum -= lastLetter - 64;
        }
        else if (lastLetter >= 'a' && lastLetter <= 'z')
        {
            sum += lastLetter - 96;
        }
        token = strtok(NULL, " \t");
        
        free(number);
    }
    
    printf("%.2lf", sum + 0.0005); //hardcore fix for rounding.
    
    free(line);
    
    return 0;
}

char *substr(char * src, int position, int length)
{
    size_t sourceLength = strlen(src);
    if (position >= sourceLength)
    {
        char *substring = malloc(1);
        substring[0] = '\0';
        return substring;
    }
    else if (position < 0)
    {
        printf("Invalid starting position!");
        exit(1);
    }
    
    char *substring = calloc(length + 1, sizeof(char));
    if (!substring)
    {
        printf("No memory to allocate!");
        exit(1);
    }
    
    int i;
    for (i = 0; i < length; i++)
    {
        substring[i] = src[position + i];
    }
    
    substring[i] = '\0';
    
    return substring;
}