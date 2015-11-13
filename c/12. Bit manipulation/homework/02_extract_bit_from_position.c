#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n, p;

	scanf("%d", &n);
	scanf("%d", &p);

	printf("bit @ p = %d\n", get_bit(n, p));

	return 0;
}