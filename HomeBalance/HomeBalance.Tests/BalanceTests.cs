using Xunit;

namespace HomeBalance.Tests;

public class BalanceTests
{
    [Fact]
    public void Should_Split_Expense_Equally()
    {
        // Arrange
        var totalExpense = 300;
        var userCount = 3;

        // Act
        var perPerson = totalExpense / userCount;

        // Assert
        Assert.Equal(100, perPerson);
    }
    [Fact]
    public void Should_Calculate_Who_Owes_Who()
    {
        // Arrange
        var users = new[] { "A", "B", "C" };

        var expenses = new Dictionary<string, int>
    {
        { "A", 300 }, // A hepsini ödedi
        { "B", 0 },
        { "C", 0 }
    };

        var total = expenses.Values.Sum();
        var perPerson = total / users.Length;

        // Act
        var balances = expenses.ToDictionary(
            x => x.Key,
            x => x.Value - perPerson
        );

        // Assert
        Assert.Equal(200, balances["A"]);   // A alacaklı
        Assert.Equal(-100, balances["B"]);  // B borçlu
        Assert.Equal(-100, balances["C"]);  // C borçlu
    }
}