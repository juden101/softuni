#include <stdio.h>

int binary_search(int [], int, int);

int main()
{
	int collection[] = { -2, 0, 3, 5, 213, 8582, 239191, 985128 };
	int size = sizeof(collection)/ sizeof(collection[0]);
	int search = 239191;

	// int collection[] = { 0, 1, 2, 3, 4, 5, 6, 6, 7, 8, -2 };
	// int size = sizeof(collection)/ sizeof(collection[0]);
	// int search = -2;

	// int collection[] = { 3, 9, 10, 12, 13, 13, 13, 13 };
	// int size = sizeof(collection)/ sizeof(collection[0]);
	// int search = 13;

	printf("result = %d\n", binary_search(collection, size, search));

	return 0;
}

int binary_search(int arr[], int size, int search)
{
	int left = 0, right = size, middle;

	while (left <= right)
    {
        middle = (left + right) / 2;
        
        if (search < arr[middle])
        {
            right = middle - 1;
        }
        else if (search > arr[middle])
        {
            left = middle + 1;
        }
        else
        {
            return middle;
        }
    }

    return -1;
}