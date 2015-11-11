#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

int main()
{
    printf("%d\n", str_search("SoftUni", "Soft"));
    printf("%d\n", str_search("Hard Rock", "Rock"));
    printf("%d\n", str_search("Ananas", "nasa"));
    printf("%d\n", str_search("Coolness", "cool"));
	
	return 0;
}