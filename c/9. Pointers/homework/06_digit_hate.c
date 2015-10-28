#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* digit_hate(char*, size_t, int*);

int main()
{
	char* line;
	size_t size = 0;
	int digits_replaced;

	size_t length = getline(&line, &size, stdin);
	char* result = digit_hate(line, length, &digits_replaced);

	printf("digits replaced: %d\n%s", digits_replaced, result);

	return 0;
}

char* digit_hate(char* str, size_t length, int* digits_replaced)
{
	int i;
	*(digits_replaced) = 0;
	char* output = str;

	for (i = 0; i < length; i++)
	{
		char currentChar = *(str + i);

		if (currentChar > 47 && currentChar < 58)
		{
			*(output + i) = '/';
			*(digits_replaced) += 1;
		}
	}

	return output;
}