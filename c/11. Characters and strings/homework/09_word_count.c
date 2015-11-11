#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

int main()
{
    printf("%d\n", word_count("Hard Rock, Hallelujah!", ' '));
    printf("%d\n", word_count("Hard Rock, Hallelujah!", ','));
    printf("%d\n", word_count("Uncle Sam wants you Man", ' '));
    printf("%d\n", word_count("Beat the beat!", '!'));
	
	return 0;
}