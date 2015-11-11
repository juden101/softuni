#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void selection_sort(char **, int);

int main() 
{
    int n;

    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    getchar();
    size_t index = 0; 
    char **array = calloc(n, sizeof(char *));

    if (!array)
    {
        printf("No memory to allocate!");
        return 1;
    }
    
    while (index < n)
    {
        char *line = NULL;
        size_t lineSize = 0;
        size_t lineLenght = getline(&line, &lineSize, stdin);
        line[lineLenght - 1] = '\0';

        array[index] = calloc(lineLenght + 1, sizeof(char));
        if (!array[index])
        {
            printf("No memory to allocate!");
            return 1;
        }
        
        strcpy(array[index], line);
        
        free(line);
        index++;
    }
    
    selection_sort(array, n);
    
    printf("\n");
    int i;

    for (i = 0; i < index; i++)
    {
        printf("%s\n", array[i]);
        free(array[i]);
    }
    
    free(array);
    
    return 0;
}

void selection_sort(char **array, int length)
{
    int i;
    
    for (i = 0; i < length - 1; i++)
    {
        int j;

        for (j = i + 1; j < length; j++)
        {
            if (strcmp(array[i], array[j]) > 0)
            {
                char *temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}