using System;

namespace LegacyApp;

public class UserService
{
    private Checker checker = new Checker();

    public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        var clientRepository = new ClientRepository();
        var client = clientRepository.GetById(clientId);
        
        var user = new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
        
        int age = checker.GetAge(dateOfBirth);
        
        if (checker.IsNameEmpty(firstName, lastName) && checker.DoesEmailContainAtandDot(email) 
                                                     && checker.AgeCheck(age) && checker.HasEnoughCreditLimit(user))
        {
            checker.DefineCreditiLimit(user, client);
            UserDataAccess.AddUser(user);
            return true;
        }
        return false;
    }
}