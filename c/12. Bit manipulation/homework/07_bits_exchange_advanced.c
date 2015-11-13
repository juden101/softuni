#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

unsigned int greater_number(unsigned int first, unsigned int second);
unsigned int lesser_number(unsigned int first, unsigned int second);

int main()
{
	unsigned int n;
	int p, q, k;

	scanf("%u", &n);
	scanf("%d", &p);
	scanf("%d", &q);
	scanf("%d", &k);

	if (p < 0 || q < 0 || greater_number(p, q) + k > 32)
    {
        printf("out of range\n");
    }
    else if (lesser_number(p, q) + k - 1 >= greater_number(p, q))
    {
        printf("overlapping\n");
    }
    else
    {
		int i;

		for (i = 0; i < k; i++)
		{
			n = exchange_bits(n, p + i, q + i);
		}

		printf("result = %u\n", n);
	}

	return 0;
}

unsigned int greater_number(unsigned int first, unsigned int second)
{
    return first > second ? first : second;
}

unsigned int lesser_number(unsigned int first, unsigned int second)
{
    return first < second ? first : second;
}