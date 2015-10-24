#include <stdio.h>

int main()
{
	int n, i;

	printf("n = ");
	scanf("%d", &n);

	int numbers[n];
	int subsequences[n][n];

	for (i = 0; i < n; i++)
	{
		scanf("%d", &numbers[i]);
	}

	int longestSubsequenceStart = 0;
	int longestSubsequenceSize = 1;

	int currentSubsequenceStart = 0;
	int currentSubsequenceSize = 1;

	printf("%d ", numbers[0]);

	for (i = 1; i < n; i++)
	{
		if (numbers[i] > numbers[i - 1])
		{
			currentSubsequenceSize++;
		}
		else
		{
			printf("\n");

			currentSubsequenceStart = i;
			currentSubsequenceSize = 1;
		}

		printf("%d ", numbers[i]);

		if (currentSubsequenceSize > longestSubsequenceSize)
		{
			longestSubsequenceStart = currentSubsequenceStart;
			longestSubsequenceSize = currentSubsequenceSize;
		}
	}

	if (currentSubsequenceSize > longestSubsequenceSize)
	{
		longestSubsequenceStart = currentSubsequenceStart;
		longestSubsequenceSize = currentSubsequenceSize;
	}

	printf("\nlongest: ");

	for (i = longestSubsequenceStart; i < longestSubsequenceStart + longestSubsequenceSize; i++)
	{
		printf("%d ", numbers[i]);
	}

	printf("\n");

	return 0;
}