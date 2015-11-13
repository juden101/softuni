#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n, p;

	scanf("%d", &n);
	scanf("%d", &p);

	printf("result = %d\n", set_bit(n, p, 0));

	return 0;
}