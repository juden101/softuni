#include <stdio.h>
#include <string.h>
#include <math.h>

typedef struct Clients
{
   char *name;
   int age;
   double account_balance;
} client;  

void sort_clients(client [], int, int (*)(client, client));
int name_comparator(client, client);
int balance_comparator(client, client);
int age_comparator(client, client);
void swap(client *a, client *b);

int main()
{
	client clients[] = {
	    { .name = "Peter", .age = 29, .account_balance = 693.45 },
	    { .name = "James", .age = 19, .account_balance = 1004.90 },
	    { .name = "Johny", .age = 23, .account_balance = 357.00 },
	    { .name = "Mikee", .age = 41, .account_balance = 43.12 }
	};

	int clientsCount = sizeof(clients) / sizeof(clients[0]), i;

	sort_clients(clients, clientsCount, &name_comparator);
	//sort_clients(clients, clientsCount, &balance_comparator);
	//sort_clients(clients, clientsCount, &age_comparator);

	for (i = 0; i < clientsCount; i++)
	{
		printf("name: %s; age: %d; balance: %f\n", clients[i].name, clients[i].age, clients[i].account_balance);
	}

	return 0;
}

void sort_clients(client array[], int length, int (*compare)(client, client))
{
    int swapped = 1, i;
    
    while (swapped)
    {
        swapped = 0;
        
        for (i = 0; i < length - 1; i++)
        {
            if (compare(array[i], array[i + 1]) > 0)
            {
                swap(&array[i], &array[i + 1]);
                swapped = 1;
            }
        }
    }
}

int name_comparator(client a, client b)
{
	return memcmp(a.name, b.name, strlen(a.name));
}

int balance_comparator(client a, client b)
{
	if (a.account_balance < b.account_balance)
	{
		return -1;
	}

	if (a.account_balance > b.account_balance)
	{
		return  1;
	}

	return 0;
}

int age_comparator(client a, client b)
{
	if (a.age < b.age)
	{
		return -1;
	}

	if (a.age > b.age)
	{
		return  1;
	}

	return 0;
}

void swap(client *a, client *b)
{
	client temp = *a;
    *a = *b;
    *b = temp;
}