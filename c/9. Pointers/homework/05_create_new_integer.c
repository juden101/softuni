#include <stdio.h>

int new_integer();
int* new_integer_ptr();

int main()
{
	int first = new_integer();
	int second = *(new_integer_ptr());

	printf("%d\n", first);
	printf("%d\n", second);

	// the second declaration is not safe to use
	// because you have to dereference the result
	// that is being returned from the function

	return 0;
}

int new_integer()
{
	int n = 5;

	return n;
}

int* new_integer_ptr()
{
	int n = 5;
	int* nPtr = &n;

	return nPtr;
}