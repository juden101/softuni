#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

int validate_phone_number(char *phoneNumber)
{
    size_t length = strlen(phoneNumber);
    if (phoneNumber[0] != '+')
    {
        return 0;
    }
    
    int foundDash = 0;
    size_t i;
    for (i = 1; i < length; i++)
    {
        if (!isdigit(phoneNumber[i]))
        {
            if (phoneNumber[i] == '-' && foundDash == 0)
            {
                foundDash = 1;
            }
            else 
            {
                return 0;
            }
        }
    }
    
    return 1;
}

int main() 
{
    // +359-238592
    char phoneNumber[] = "+359-238-592";
    int isValid = validate_phone_number(phoneNumber);
    printf("Valid phone? %s", isValid ? "yes" : "no");
    
    char name[] = "pesho";
    name[0] = toupper(name[0]);
    printf("%s", name);
    
    return (EXIT_SUCCESS);
}

