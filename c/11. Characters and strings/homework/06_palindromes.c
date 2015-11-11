#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"
#include "str_lib.h"

int str_is_palindrome(const char *);
int containes(char **, char *, int);
void print_array(char **, int);
void bubble_sort(char **, int);
char *to_lower_string(char *, size_t);

int main()
{
	char *input = read_line();

	char **paliandromes = calloc(strlen(input), sizeof(char *));
    if (!paliandromes)
    {
        printf("Cannot allocate enough memory!");
        exit(1);
    }

	char *token = strtok(input, " ,.?!");
    int i = 0;
	while (token)
	{
		if (str_is_palindrome(token))
		{
			int palindrome_length = strlen(token);
            paliandromes[i] = calloc(palindrome_length + 1, sizeof(char));

            if (!paliandromes[i])
            {
                printf("Cannot allocate enough memory!");
                exit(1);
            }

            int isContained = containes(paliandromes, token, i);

            if (!isContained)
            {
                strncat(paliandromes[i], token, palindrome_length);
                paliandromes[i][palindrome_length] = '\0';
                i++;
            }
            else
            {
                free(paliandromes[i]);
            }
		}

	    token = strtok(NULL, " ,.?!");
	}

    bubble_sort(paliandromes, i);
    print_array(paliandromes, i);

	free(input);
	
	i--;
    while (i >= 0)
    {
        free(paliandromes[i]);
        i--;
    }
    
    free(paliandromes);

	return 0;
}

int str_is_palindrome(const char *s)
{
    const char *p = s + strlen(s) - 1;

    while (s < p)
    {
        if (*p-- != *s++)
        {
            return 0;
        }
    }

    return 1;
}

int containes(char **array, char *searched, int length)
{
    int i, isFound = 0;

    for (i = 0; i < length; i++)
    {
        char *substr = strstr(array[i], searched);

        if (substr)
        {
            isFound = 1;
            break;
        }
    }
        
    return isFound;
}

void print_array(char **array, int length)
{
    int i;

    for (i = 0; i < length; i++)
    {
        if (i < length - 1)
        {
            printf("%s, ", array[i]);
        }
        else
        {
            printf("%s", array[i]);
        }
    }

    printf("\n");
}

void bubble_sort(char **array, int length)
{
    int hasSwaped = 1;

    while (hasSwaped)
    {
        hasSwaped = 0;
        int i;

        for (i = 0; i < length - 1; i++)
        {
            size_t currStrLen = strlen(array[i]);
            char *currentStr = to_lower_string(array[i], currStrLen);
            size_t nextStrLen = strlen(array[i + 1]);
            char *nextStr = to_lower_string(array[i + 1], nextStrLen);
            
            if (strcmp(currentStr, nextStr) >= 0)
            {
                char *temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
                hasSwaped = 1;
            }
            
            free(currentStr);
            free(nextStr);
        }
    }
}

char *to_lower_string(char *str, size_t size)
{
    char *result = calloc(size + 1, sizeof(char));

    if (!result)
    {
        printf("No memory to allocate!");
        exit(1);
    }
    
    int i;

    for (i = 0; i < size; i++)
    {
        result[i] = tolower(str[i]);
    }
    
    result[i] = '\0';
    
    return result;
}