#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *read_line();
char *str_replace_all(const char *, const char *, const char *);
char *str_concat(const char *, const char *);

int main()
{
	char *input = read_line();
    char *result = (char *) calloc(64, sizeof(char));

    while (strcmp(input, "over") != 0)
    {
        char *command = strtok(input, "-");

        if (strcmp(command, "concat") == 0)
        {
            char *value = strtok(NULL, "-");

            size_t concatSize = strlen(value);

            char* concat = str_concat(result, value);
            free(result);
            result = concat;
        }
        else if (strcmp(command, "insert") == 0)
        {
            char *value = strtok(NULL, "-");
            int insert_pos = atoi(strtok(NULL, "-"));

            int product_length = strlen(result) + strlen(value) + 1;
            char* product = (char*)malloc(product_length);
            strncpy(product, result, insert_pos);
            product[insert_pos] = '\0';
            strcat(product, value);
            strcat(product, result + insert_pos);

            free(result);
            result = product;
        }
        else if (strcmp(command, "replace") == 0)
        {
            char *occurrence = strtok(NULL, "-");
            char *replacement = strtok(NULL, "-");

            char* replaced = str_replace_all(result, occurrence, replacement);
            
            free(result);
            result = replaced;
        }

        free(input);
        input = read_line();
    }

    printf("%s\n", result);
    
    free(result);
    free(input);

	return 0;
}

char *read_line()
{
    int initialSize = 4;
    char *readline = (char *) malloc(initialSize);
    int index = 0;
    char ch = getchar();

    while (ch != '\n')
    {
        if (index == initialSize - 1)
        {
            char *newReadLine = (char *) realloc(readline, initialSize * 2);
            
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
char *str_replace_all(char const * const original, char const * const pattern, char const * const replacement)
{
    size_t const replen = strlen(replacement);
    size_t const patlen = strlen(pattern);
    size_t const orilen = strlen(original);
    size_t patcnt = 0;

    const char *oriptr;
    const char *patloc;

    for (oriptr = original; patloc = strstr(oriptr, pattern); oriptr = patloc + patlen)
    {
        patcnt++;
    }

    size_t const retlen = orilen + patcnt * (replen - patlen);
    char * const result = (char *) malloc( sizeof(char) * (retlen + 1) );

    if (result != NULL)
    {
        char *retptr = result;

        for (oriptr = original; patloc = strstr(oriptr, pattern); oriptr = patloc + patlen)
        {
            size_t const skplen = patloc - oriptr;
            strncpy(retptr, oriptr, skplen);
            retptr += skplen;
            strncpy(retptr, replacement, replen);
            retptr += replen;
        }

        strcpy(retptr, oriptr);
    }

    return result;
}

char *str_concat(const char *first, const char *second)
{
    const size_t first_len = strlen(first), new_len = strlen(second);
    const size_t second_len = first_len + new_len + 1;

    char *result = (char *) malloc(second_len);

    memcpy(result, first, first_len);
    memcpy(result + first_len, second, new_len + 1);

    return result;
}