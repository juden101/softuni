using System;
using System.Collections.Generic;
using System.Text;

class Customer : ICloneable, IComparable<Customer>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public string PermanentAddress { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public List<Payment> Payment { get; set; }
    public CustomerType Type { get; set; }

    public Customer(string firstName, string middleName, string lastName, int id, string permanentAddress, string mobilePhone, string email, List<Payment> payment, CustomerType type)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.ID = id;
        this.PermanentAddress = permanentAddress;
        this.MobilePhone = mobilePhone;
        this.Email = email;
        this.Payment = payment;
        this.Type = type;
    }
    
    public override bool Equals(object obj)
    {
        Customer customer = obj as Customer;

        if (customer == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstName, customer.FirstName))
        {
            return false;
        }

        if (!Object.Equals(this.MiddleName, customer.MiddleName))
        {
            return false;
        }

        if (!Object.Equals(this.LastName, customer.LastName))
        {
            return false;
        }

        if (this.ID != customer.ID)
        {
            return false;
        }

        if (!Object.Equals(this.PermanentAddress, customer.PermanentAddress))
        {
            return false;
        }

        if (!Object.Equals(this.Email, customer.Email))
        {
            return false;
        }

        if (!Object.Equals(this.Type, customer.Type))
        {
            return false;
        }

        return true;
    }
    
    public static bool operator ==(Customer student1, Customer student2)
    {
        return Customer.Equals(student1, student2);
    }

    public static bool operator !=(Customer student1, Customer student2)
    {
        return !(Customer.Equals(student1, student2));
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode() ^ ID.GetHashCode();
    }

    public override string ToString()
    {
        string customerFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;

        return String.Format(
            "Customer(Name: {0}, ID: {1}, Permanent address: {2}, Mobile phone: {3}, Email: {4}, Payment: {5}, Type: {6})",
            customerFullName, this.ID, this.PermanentAddress, this.MobilePhone, this.Email, String.Join(", ", this.Payment), this.Type);
    }

    public object Clone()
    {
        Customer deepCopyCustomer = new Customer(
            FirstName = this.FirstName,
            MiddleName = this.MiddleName,
            LastName = this.LastName,
            ID = this.ID,
            PermanentAddress = this.PermanentAddress,
            MobilePhone = this.MobilePhone,
            Email = this.Email,
            Payment = this.Payment,
            Type = this.Type);

        return deepCopyCustomer;
    }

    public int CompareTo(Customer secondCustomer)
    {
        string firstCustomerName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
        string secondCustomerName = secondCustomer.FirstName + " " + secondCustomer.MiddleName + " " + secondCustomer.LastName;

        int result = string.Compare(firstCustomerName, secondCustomerName);

        if (result == 0)
        {
            return this.ID - secondCustomer.ID;
        }

        return result;
    }
}