#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

char *read_line()
{
    int initialSize = 4;
    char *readline = malloc(initialSize);
    int index = 0;
    char ch = getchar();

    while (ch != '\n')
    {
        if (index == initialSize - 1)
        {
            char *newReadLine = realloc(readline, initialSize * 2);
            
            if (!newReadLine)
            {
                printf("Not enough memory!");
                exit(1);
            }
            
            readline = newReadLine;
            initialSize *= 2;
        }
        
        *(readline + index) = ch;
        index++;
        ch = getchar();
    }
    
    *(readline + index) = '\0';
    
    return readline;
}

char *str_to_lower(char *input)
{
    int i;

    for (i = 0; input[i]; i++)
    {
        input[i] = tolower(input[i]);
    }

    return input;
}

char *str_join(char input, size_t count)
{
	char *result = calloc(count + 1, sizeof(char));
	int i;

	for (i = 0; i < count; i++)
	{
		result[i] = input;
	}

	result[count] = '\0';

	return result;
}

char *str_replace_all(const char *string, const char *substr, const char *replacement)
{
	char *tok = NULL, *newstr = NULL, *oldstr = NULL;

	if (substr == NULL || replacement == NULL) 
	{
		return strdup(string);
	}

	newstr = strdup(string);

	while ((tok = strstr(newstr, substr)))
	{
		oldstr = newstr;
		newstr = malloc(strlen(oldstr) - strlen(substr) + strlen(replacement) + 1);

		if (newstr == NULL)
		{
			free(oldstr);
			return NULL;
		}

		memcpy(newstr, oldstr, tok - oldstr);
		memcpy(newstr + (tok - oldstr), replacement, strlen(replacement));
		memcpy(newstr + (tok - oldstr) + strlen(replacement), tok + strlen(substr), strlen(oldstr) - strlen(substr) - (tok - oldstr));
		memset(newstr + strlen(oldstr) - strlen(substr) + strlen (replacement) , 0, 1);
		free (oldstr);
	}

	return newstr;
}

char *str_concat(char *source, char *dest, size_t size)
{
	size_t dest_length = strlen(dest);
	size_t i;

	for (i = 0; i < size; i++)
	{
		if (source[i] != '\0')
		{
			dest[dest_length + i] = source[i];
		}
		else
		{
			return dest;
		}
	}

    dest[dest_length + i] = '\0';
    
    return dest;
}

int word_count(char *input, char delimiter)
{
    size_t count = 1;
    
    while (*input != '\0')
    {
        if (*input == delimiter)
        {
            count++;
        }
        
        *input++;
    }
    
    return count;
}

size_t str_length(char *str)
{
    size_t length = 0;
    
    while (*str != '\0')
    {
        length++;        
        *str++;
    }
    
    return length;
}

int str_search(char * src, char * substr)
{
    size_t searchedLength = strlen(substr);
    size_t sourceLength = strlen(src);

    if (searchedLength > sourceLength)
    {
        return 0;
    }
    
    int i;
    
    for (i = 0; i < sourceLength; i++)
    {
        int j;
        
        for (j = 0; j < searchedLength; j++)
        {
            if (substr[j] != src[i + j])
            {
                break;
            }
        }
        
        if (j == searchedLength)
        {
            return 1;
        }
    }
    
    return 0;
}

char *str_substr(char *src, int position, int length)
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