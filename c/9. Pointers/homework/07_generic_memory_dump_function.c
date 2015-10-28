#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void mem_dump(void *, size_t, int);

int main()
{
	char *text = "I love to break free";
	mem_dump(text, strlen(text) + 1, 5);

	// int array[] = { 7, 3, 2, 10, -5 };
	// size_t size = sizeof(array) / sizeof(int);
	// mem_dump(array, size * sizeof(int), 4);

	return 0;
}

void mem_dump(void *pointer, size_t size, int length)
{
	int i = 0, index = 0;

	while (i < size)
	{
		char *bytePtr = pointer;

		if(index == 0)
		{
			printf("%p ", bytePtr + i);
		}

		printf("%02hhx ", *(bytePtr + i));

		if (index == length - 1)
		{
			index = -1;
			printf("\n");
		}

		i++;
		index++;
	}

	printf("\n");
}