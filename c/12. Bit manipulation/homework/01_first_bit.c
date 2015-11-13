#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n;

	scanf("%d", &n);

	printf("first bit = %d\n", get_bit(n, 1));
	printf("third bit = %d\n", get_bit(n, 3));

	return 0;
}