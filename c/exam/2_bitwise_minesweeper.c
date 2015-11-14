#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <assert.h>

#define BIT_COUNT 32

int get_bit(unsigned int n, unsigned int pos);
int set_bit(unsigned int n, unsigned int pos, unsigned int bit_val);
char *read_line();

int main()
{
	unsigned int n;

	scanf("%u", &n);

	unsigned int matrix[n];
	int i;

	for (i = 0; i < n; i++)
	{
		scanf("%u", &matrix[i]);
	}

	int oldX = 0;
	int oldY = 0;

	int x = 0;
	int y = 0;

	char *command = read_line();

    while (strcmp(command, "end") != 0)
    {
    	if (strcmp(command, "left") == 0)
    	{
			if (x + 1 > 31)
			{
				x = -1;
			}

			x++;

			if (get_bit(matrix[y], x) == 1)
			{
				printf("GAME OVER. Stepped a mine at %u %u\n", y, x);
				break;
			}
			else
			{
				matrix[oldY] = set_bit(matrix[oldY], oldX, 0);
				matrix[y] = set_bit(matrix[y], x, 1);

				oldX = x;
				oldY = y;
			}
    	}
    	else if (strcmp(command, "right") == 0)
    	{
			if (x - 1 < 0)
			{
				x = 32;
			}

			x--;

			if (get_bit(matrix[y], x) == 1)
			{
				printf("GAME OVER. Stepped a mine at %u %u\n", y, x);
				break;
			}
			else
			{
				matrix[oldY] = set_bit(matrix[oldY], oldX, 0);
				matrix[y] = set_bit(matrix[y], x, 1);

				oldX = x;
				oldY = y;
			}
    	}
    	else if (strcmp(command, "up") == 0)
    	{
			if (y - 1 < 0)
			{
				y = n;
			}

			y--;

			if (get_bit(matrix[y], x) == 1)
			{
				printf("GAME OVER. Stepped a mine at %u %u\n", y, x);
				break;
			}
			else
			{
				matrix[oldY] = set_bit(matrix[oldY], oldX, 0);
				matrix[y] = set_bit(matrix[y], x, 1);

				oldX = x;
				oldY = y;
			}
    	}
    	else if (strcmp(command, "down") == 0)
    	{
			if (y + 1 > n - 1)
			{
				y = -1;
			}

			y++;

			if (get_bit(matrix[y], x) == 1)
			{
				printf("GAME OVER. Stepped a mine at %u %u\n", y, x);
				break;
			}
			else
			{
				matrix[oldY] = set_bit(matrix[oldY], oldX, 0);
				matrix[y] = set_bit(matrix[y], x, 1);

				oldX = x;
				oldY = y;
			}
    	}

    	command = read_line();
    }

	int j;
	for (j = 0; j < n; j++)
	{
		printf("%u\n", matrix[j]);
	}

	return 0;
}

int get_bit(unsigned int n, unsigned int pos)
{
	assert(pos >= 0 && pos < 32);
	unsigned int mask = 1 << pos;

	return (n & mask) != 0; 
}

int set_bit(unsigned int n, unsigned int pos, unsigned int bit_val)
{
	assert(pos >= 0 && pos < 32);
	assert(bit_val == 0 || bit_val == 1);

	unsigned int mask = 1 << pos;

	if (bit_val)
	{
		n = n | mask;
	}
	else
	{
		mask = ~mask;
		n = n & mask;
	}

	return n;
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