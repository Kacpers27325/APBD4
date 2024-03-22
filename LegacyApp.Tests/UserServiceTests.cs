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
    
    
    
}