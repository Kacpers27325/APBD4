namespace LegacyApp.Tests;

public class UserServiceTests
{

    [Fact]
    public void AddUserFalseWhenFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(null, "K", "aaa@aaa.com",DateTime.Parse("1992-02-03"),10);

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUserFalseWhenLastNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("Mariusz", null, "aaa@aaa.com",DateTime.Parse("1992-02-03"),10);

        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenCustomerDontExist()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        Action result = () => userService.AddUser("Mietek", "K", "aaa@aaa.com",DateTime.Parse("1992-02-03"),10);
        

        //Assert
        Assert.Throws<ArgumentException>(result);
    }
    
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(null, "K", "aaaacom",DateTime.Parse("1992-02-03"),10);

        //Assert
        Assert.False(result);
    }
    
    
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result =  userService.AddUser("Mietek", "K", "aaa@aaa.com",DateTime.Parse("2022-02-03"),10);
        

        //Assert
        Assert.False(result);
    }
    
    
    // AddUser_ReturnsTrueWhenVeryImportantClient
    // AddUser_ReturnsTrueWhenImportantClient
    // AddUser_ReturnsTrueWhenNormalClient
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit
    // AddUser_ThrowsExceptionWhenUserDoesNotExist
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser
    
    
    
    
    
    
    
}