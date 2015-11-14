#include <stdio.h>
#include <math.h>

int main()
{
    float dart, dartX, dartY;
    float headRadius, headX, headY;
    float ax, ay, bx, by;
    int shots, points = 0;
    int baiMileHealth = 100;

    scanf ("%f %f %f", &dartX, &dartY, &dart);
    scanf ("%f %f %f", &headX, &headY, &headRadius);
    scanf ("%f %f %f %f", &ax, &ay, &bx, &by);
    scanf ("%d", &shots);
    
    int i;

    int hits = 0;
    int total = 0;

    for(i = 0; i < shots; i++)
    {
        float x, y;
        scanf("%f %f", &x, &y);

        int isInCircle = (((pow(x - headX, 2) + (pow(y - headY, 2))) <= headRadius * headRadius));
        int isInRectangular = (x <= bx && x >= ax) && (y >= by && y <= ay);
        int isInBigCircle = (((pow(x - dartX, 2) + (pow(y - dartY, 2))) <= dart * dart));

        if (isInCircle)
        {
            baiMileHealth -= 25;
        }

        if (isInRectangular)
        {
            baiMileHealth -= 30;
        }

        if (isInBigCircle && !isInCircle && !isInRectangular)
        {
            points += 50;
            hits++;
        }
        else if (isInBigCircle && (isInCircle || isInRectangular))
        {
            points += 25;
            hits++;
        }

        total++;

        if (baiMileHealth <= 0)
        {
            break;
        }
    }

    if (baiMileHealth < 0)
    {
        baiMileHealth = 0;
    }

    printf("Points: %d\n", points);
    printf("Hit ratio: %d%%\n", (int)((1.0 * hits / total) * 100));
    printf("Bay Mile: %d\n" ,baiMileHealth);
    
    return 0;
}