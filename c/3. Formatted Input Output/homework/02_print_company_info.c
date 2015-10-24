#include <stdio.h>
#include <string.h>

#define BUFFER_SIZE 100

int main() {
    char companyName[BUFFER_SIZE] = "";
    char companyAddress[BUFFER_SIZE] = "";
    char phoneNumber[BUFFER_SIZE] = "";
    char faxNumber[BUFFER_SIZE] = "";
    char webSite[BUFFER_SIZE] = "";
    char managerFirstName[BUFFER_SIZE] = "";
    char managerLastName[BUFFER_SIZE] = "";
    int managerAge = 0;
    char managerPhone[BUFFER_SIZE] = "";
    
    printf("Company name: ");
    fgets(companyName, BUFFER_SIZE, stdin);
    
    printf("Company address: ");
    fgets(companyAddress, BUFFER_SIZE, stdin);
    
    printf("Phone number: ");
    fgets(phoneNumber, BUFFER_SIZE, stdin);
    
    printf("Fax number: ");
    fgets(faxNumber, BUFFER_SIZE, stdin);
    
    printf("Web site: ");
    fgets(webSite, BUFFER_SIZE, stdin);
    
    printf("Manager first name: ");
    fgets(managerFirstName, BUFFER_SIZE, stdin);
    
    printf("Manager last name: ");
    fgets(managerLastName, BUFFER_SIZE, stdin);
    
    printf("Manager age: ");
    scanf("%d", &managerAge);
    getchar();
    
    printf("Manager phone: ");
    fgets(managerPhone, BUFFER_SIZE, stdin);
    
    printf("\n%s", strlen(companyName) == 1 ? "(no company name)\n" : companyName);
    printf("Address: %s", strlen(companyAddress) == 1 ? "(no address)\n" : companyAddress);
    printf("Tel. %s", strlen(phoneNumber) == 1 ? "(no phone)\n" : phoneNumber);
    printf("Fax: %s", strlen(faxNumber) == 1 ? "(no fax)\n" : faxNumber);
    printf("Web site: %s", strlen(webSite) == 1 ? "(no web site)\n" : webSite);
    printf("Manager: %s %s (age: %d, tel. %s)\n", 
            strlen(managerFirstName) == 1 ? "(no first name)\n" : managerFirstName,
            strlen(managerLastName) == 1 ? "(no last name)\n" : managerLastName,
            managerAge,
            strlen(managerPhone) == 1 ? "(no phone)\n" : managerPhone);

    return 0;
}