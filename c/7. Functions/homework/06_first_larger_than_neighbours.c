#include <stdio.h>

int largest_neighbour(int* sequence, int size);

int main(void) {
    int sequenceOne[] = { 1, 3, 4, 5, 1, 0, 5 };
    int sequenceTwo[] = { 1, 2, 3, 4, 5, 6, 6 };
    int sequenceThree[] = { 1, 1, 1 };
    
    printf("%d\n", largest_neighbour(sequenceOne, 6));
    printf("%d\n", largest_neighbour(sequenceTwo, 6));
    printf("%d\n", largest_neighbour(sequenceThree, 2));

    return 0;
}

int largest_neighbour(int* sequence, int size) {
    int best = -1, bestIndex = -1, i;
    
    for (i = 1; i < size; i++) {
        if (sequence[i] > sequence[i - 1] && sequence[i] > sequence[i + 1]) {
            if (sequence[i] >= best) {
                bestIndex = i;
            }
        }
    }
    
    return bestIndex;
}