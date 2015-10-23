#include <stdio.h>

typedef int bool;
#define true 1
#define false 0

int main() {
    bool isFemale = false;
    printf("%s", isFemale ? "true" : "false");

    return 0;
}