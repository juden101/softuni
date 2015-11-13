#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n;

	scanf("%d", &n);

	n = exchange_bits(n, 3, 24);
	n = exchange_bits(n, 4, 25);
	n = exchange_bits(n, 5, 26);

	printf("result = %d\n", n);

	return 0;
}