#include <stdio.h>

typedef struct Clients
{
   char *name;
   int age;
   double account_balance;
} client;  

int main()
{
	client clients[] = {
	    { .name = "Peter", .age = 29, .account_balance = 693.45 },
	    { .name = "James", .age = 19, .account_balance = 1004.90 },
	    { .name = "John", .age = 23, .account_balance = 357.00 },
	    { .name = "Mike", .age = 41, .account_balance = 43.12 }
	};
	int clientsCount = 4;

	sort_clients(clients, clientsCount, &name_comparator);
	//sort_clients(clients, clientsCount, &balance_comparator);
	//sort_clients(clients, clientsCount, &age_comparator);

	printf("%d\n", clients[0].age);
}

void sort_clients(void *array[], int length, int (*compare)(void*, void*))
{
	
}

int name_comparator(void *a, void *b, size_t a_size, size_t b_size)
{
	return a > b; // Evaluates to 1 if true
}