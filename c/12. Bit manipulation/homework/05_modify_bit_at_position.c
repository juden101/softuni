#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n, p, v;

	scanf("%d", &n);
	scanf("%d", &p);
	scanf("%d", &v);

	printf("result = %d\n", set_bit(n, p, v));

	return 0;
}