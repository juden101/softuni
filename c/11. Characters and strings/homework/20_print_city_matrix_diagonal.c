#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    int n;

    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    getchar();
    char **array = calloc(n, sizeof(char *));
    if (!array)
    {
        printf("No memory to allocate!");
        return 1;
    }
    
    int i;
    for (i = 0; i < n; i++)
    {
        char *line = NULL;
        size_t lineSize = 0;
        size_t lineLenght = getline(&line, &lineSize, stdin);
        line[lineLenght - 1] = '\0';
        char *token = strtok(line, " \t");
        int tokenCount = 0;

        while (tokenCount <= i)
        {
            if (tokenCount == i)
            {
                array[i] = calloc(lineLenght + 1, sizeof(char));

                if (!array[i])
                {
                    printf("No memory to allocate!");
                    return 1;
                }
                
                size_t tokenLength = strlen(token);
                strcpy(array[i], token);
                array[i][tokenLength] = '\0';
            }
            
            tokenCount++;
            token = strtok(NULL, " \t");
        }
        
        free(line);
    }
    
    printf("\n");

    for (i = 0; i < n; i++)
    {
        printf("%s\n", array[i]);
        free(array[i]);
    }

    free(array);
    
    return 0;
}