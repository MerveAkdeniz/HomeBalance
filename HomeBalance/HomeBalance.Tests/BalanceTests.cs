using Xunit;

namespace HomeBalance.Tests;

public class BalanceTests
{
    [Fact]
    public void Should_Split_Expense_Equally()
    {
        // Arrange
        var totalExpense = 300m;
        var userCount = 3;

        // Act
        var perPerson = totalExpense / userCount;

        // Assert
        Assert.Equal(100m, perPerson);
    }

    [Fact]
    public void Should_Calculate_Who_Owes_Who()
    {
        // Arrange
        var expenses = new Dictionary<string, decimal>
        {
            { "A", 300m },
            { "B", 0m },
            { "C", 0m }
        };

        var total = expenses.Values.Sum();
        var perPerson = total / expenses.Count;

        // Act
        var balances = expenses.ToDictionary(
            x => x.Key,
            x => x.Value - perPerson
        );

        // Assert
        Assert.Equal(200m, balances["A"]);
        Assert.Equal(-100m, balances["B"]);
        Assert.Equal(-100m, balances["C"]);
    }

    [Fact]
    public void Should_Return_Zero_Balance_When_No_Expenses()
    {
        // Arrange
        var expenses = new Dictionary<string, decimal>
        {
            { "A", 0m },
            { "B", 0m },
            { "C", 0m }
        };

        var total = expenses.Values.Sum();
        var perPerson = total / expenses.Count;

        // Act
        var balances = expenses.ToDictionary(
            x => x.Key,
            x => x.Value - perPerson
        );

        // Assert
        Assert.All(balances.Values, balance => Assert.Equal(0m, balance));
    }

    [Fact]
    public void Should_Handle_Single_Member()
    {
        // Arrange
        var expenses = new Dictionary<string, decimal>
        {
            { "A", 500m }
        };

        var total = expenses.Values.Sum();
        var perPerson = total / expenses.Count;

        // Act
        var balance = expenses["A"] - perPerson;

        // Assert
        Assert.Equal(0m, balance);
    }

    [Fact]
    public void Should_Handle_Decimal_Split_Correctly()
    {
        // Arrange
        var total = 100m;
        var userCount = 3;

        // Act
        var perPerson = total / userCount;

        // Assert
        Assert.Equal(33.33m, perPerson, 2);
    }
}