#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void change_diamond(char **arr, int n);

int main() 
{
    int n;
    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    char **diamond = calloc(n, sizeof(char *));
    if (!diamond)
    {
        printf("No memory to allocate!");
        return 1;
    }
    
    int i;
    for (i = 0; i < n; i++)
    {
        diamond[i] = calloc(n + 1, sizeof(char));
        if (!diamond[i])
        {
            printf("No memory to allocate!");
            return 1;
        }
        
        memset(diamond[i], '.', n);
        diamond[i][n] = '\0';
    }
    
    change_diamond(diamond, n);
    
    for (i = 0; i < n; i++)
    {
        printf("%s\n", diamond[i]);
        free(diamond[i]);
    }
    
    free(diamond);
    
    return 0;
}

void change_diamond(char **arr, int n)
{
    int firstAst = n / 2 - 1;
    int secondAst = n / 2 + 1;
    
    int i;
    for (i = 0; i < n; i++)
    {
        if (i == 0 || i == n - 1)
        {
            arr[i][n / 2] = '*';
        }
        else if (i == n / 2)
        {
            arr[i][0] = '*';
            arr[i][n - 1] = '*';
        }
        else if (i < n / 2)
        {
            arr[i][firstAst] = '*';
            firstAst--;
            arr[i][secondAst] = '*';
            secondAst++;
        }
        else
        {
            arr[i][firstAst + 1] = '*';
            firstAst++;
            arr[i][secondAst - 1] = '*';
            secondAst--;
        }
    }
    
}