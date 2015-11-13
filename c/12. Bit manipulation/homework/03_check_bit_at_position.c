#include <stdio.h>
#include <stdlib.h>
#include "bits.h"

int main()
{
	int n, p;

	scanf("%d", &n);
	scanf("%d", &p);

	printf("bit @ p == 1 -> %s\n", get_bit(n, p) ? "true" : "false");

	return 0;
}