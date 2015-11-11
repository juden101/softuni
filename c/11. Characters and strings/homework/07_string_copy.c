#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *str_cpy(char *source, char *dest, size_t size);

int main()
{
	char buffer[15];

	memset(buffer, '\0', sizeof(buffer));
	str_cpy("SoftUni", buffer, 7);
	printf("%s\n", buffer);

	memset(buffer, '\0', sizeof(buffer));
	str_cpy("SoftUni", buffer, 3);
	printf("%s\n", buffer);

	memset(buffer, '\0', sizeof(buffer));
	str_cpy("C is cool", buffer, 0);
	printf("%s\n", buffer);

	memset(buffer, '\0', sizeof(buffer));
	char* result = str_cpy("SoftUni", buffer, 7);
	printf("%s\n", buffer);
	
	return 0;
}

char *str_cpy(char *source, char *dest, size_t size)
{
	size_t i;

	for (i = 0; i < size; i++)
	{
		if (source[i] == '\0')
		{
			dest[i] = '\0';
			break;
		}
		else
		{
			dest[i] = source[i];
		}
	}

	return dest;
}