#include <stdio.h>
#include <ctype.h>
#include <stddef.h>

#define COUNT 1024

int main() {
    int i, n, splitCount, oddProduct = 1, evenProduct = 1;
    char *line[COUNT], *words[COUNT];
    scanf("%[^\n]", line);

    splitCount = split_str_by_space(line, words, COUNT);
    
    for(i = 0; i < splitCount; i++) {
        n = parse_int(words[i]);
        
        if(i % 2 == 0)
        {
            oddProduct *= n;
        }
        else
        {
            evenProduct *= n;
        }
    }
    
    if(oddProduct == evenProduct)
    {
        printf("yes\nproduct = %d", oddProduct);
    }
    else
    {
        printf("no\nodd_product = %d\neven_product = %d", oddProduct, evenProduct);
    }

    return 0;
}

int parse_int(char *str) {
    return (int)strtol(str, (char **)NULL, 10);
}

split_str_by_space(char *line, char *words[], int maxwords)
{
    char *p = line;
    int nwords = 0;

    while(1) {
	while(isspace(*p)) {
            p++;
        }
        
	if(*p == '\0') {
            return nwords;
        }
        
	words[nwords++] = p;

	while(!isspace(*p) && *p != '\0') {
            p++;
        }

	if(*p == '\0') {
            return nwords;
        }
        
	*p++ = '\0';

	if(nwords >= maxwords) {
            return nwords;
        }
    }
}