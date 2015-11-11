#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"
#include "str_lib.h"

int main()
{
	char *filter = read_line();
	char *input = read_line();
	char *token = strtok(filter, ", ");

	while (token != NULL)
	{
		char *replacement = str_join('*', strlen(token));
		char *replaced = str_replace_all(input, token, replacement);

		free(replacement);

		input = replaced;
	    token = strtok(NULL, ", ");
	}

	printf("%s\n", input);

	free(filter);
	free(input);

	return 0;
}