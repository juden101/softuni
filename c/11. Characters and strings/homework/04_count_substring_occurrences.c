#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"
#include "str_lib.h"

int main()
{
	char *input = str_to_lower(read_line());
	char *search = str_to_lower(read_line());

	int count = 0;
	const char *tmp = input;
	while(tmp = strstr(tmp, search))
	{
	   count++;
	   tmp++;
	}

	printf("result = %d\n", count);

	free(input);
	free(search);

	return 0;
}