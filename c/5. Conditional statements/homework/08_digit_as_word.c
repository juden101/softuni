#include <stdio.h>

int main() {
    char *d, *result;

    printf("d = ");
    scanf("%s", d);

    if (are_equal(d, "0"))
    {
        result = "zero";
    }
    else if (are_equal(d, "1"))
    {
        result = "one";
    }
    else if (are_equal(d, "2"))
    {
        result = "two";
    }
    else if (are_equal(d, "3"))
    {
        result = "three";
    }
    else if (are_equal(d, "4"))
    {
        result = "four";
    }
    else if (are_equal(d, "5"))
    {
        result = "five";
    }
    else if (are_equal(d, "6"))
    {
        result = "six";
    }
    else if (are_equal(d, "7"))
    {
        result = "seven";
    }
    else if (are_equal(d, "8"))
    {
        result = "eight";
    }
    else if (are_equal(d, "9"))
    {
        result = "nine";
    }
    else
    {
        result = "not a digit";
    }
    
    printf("result = %s", result);
    
    return 0;
}

int are_equal(char* s1, char* s2)
{
    return strcmp(s1, s2) == 0;
}