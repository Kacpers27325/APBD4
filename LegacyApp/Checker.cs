using System;

namespace LegacyApp;

public class Checker
{
    public bool IsNameEmpty(string fistname, string lastname)
    {
        string firstName=fistname;

        string lastName=lastname;
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool DoesEmailContainAtandDot(string email)
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int GetAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age;
    }

    public bool AgeCheck(int age)
    {
        if (age < 21)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void DefineCreditiLimit(User user, Client client)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (client.Type == "ImportantClient")
        {
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
        }
        else
        {
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        } 
    }

    public bool HasEnoughCreditLimit(User user)
    {
        if (user.HasCreditLimit && user.CreditLimit < 500)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    
    
    
    
}