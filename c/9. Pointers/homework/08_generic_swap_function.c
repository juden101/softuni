#include <stdio.h>

void swap(void *, void *, size_t);

int main()
{
	char letter = 'B', symbol = '+';
	swap(&letter, &symbol, sizeof(char));
	printf("%c %c\n", letter, symbol);

	int a = 10, b = 6;
	swap(&a, &b, sizeof(int));
	printf("%d %d\n", a, b);

	double d = 3.14, f = 1.23567;
	swap(&d, &f, sizeof(double));
	printf("%.2f %.2f\n", d, f);

	return 0;
}

void swap(void *a, void *b, size_t size)
{
	char *aPtr = a;
	char *bPtr = b;

  	while(size--)
  	{
  		*(aPtr + size) ^= *(bPtr + size);
  		*(bPtr + size) ^= *(aPtr + size);
  		*(aPtr + size) ^= *(bPtr + size);
  	}
}