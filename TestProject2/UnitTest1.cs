using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using Xunit;

public class PrimeSquaresTests
{
    // “ест дл€ нормального случа€, где есть квадраты простых чисел
    [Fact]
    public void FindPrimeSquares_WithValidInput_ReturnsCorrectResult()
    {
        // Arrange
        int[] array = { 4, 9, 15, 25, 49, 16, 18, 81 };
        var expectedPrimeSquares = new List<(int, int)>
        {
            (0, 4),
            (1, 9),
            (3, 25),
            (4, 49)
        };
        int expectedCount = 4;
        int expectedSum = 87;

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Equal(expectedPrimeSquares, primeSquares);
        Assert.Equal(expectedCount, count);
        Assert.Equal(expectedSum, sum);
        Assert.Empty(errors);
    }

    // “ест дл€ случа€ с пустым массивом
    [Fact]
    public void FindPrimeSquares_WithEmptyArray_ReturnsEmptyResult()
    {
        // Arrange
        int[] array = { };
        var expectedErrors = new List<string> { "ћассив пустой или null." };

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Empty(primeSquares);
        Assert.Equal(0, count);
        Assert.Equal(0, sum);
        Assert.Equal(expectedErrors, errors);
    }

    // “ест дл€ массива, где нет квадратов простых чисел
    [Fact]
    public void FindPrimeSquares_WithNoPrimeSquares_ReturnsZeroResult()
    {
        // Arrange
        int[] array = { 8, 10, 15, 16, 20 };

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Empty(primeSquares);
        Assert.Equal(0, count);
        Assert.Equal(0, sum);
        Assert.Empty(errors);
    }

    // “ест дл€ массива с отрицательными числами
    [Fact]
    public void FindPrimeSquares_WithNegativeNumbers_SkipsNegativeNumbers()
    {
        // Arrange
        int[] array = { -4, 9, -16, 25 };
        var expectedPrimeSquares = new List<(int, int)>
        {
            (1, 9),
            (3, 25)
        };
        var expectedErrors = new List<string>
        {
            "„исло -4 отрицательное, пропускаем.",
            "„исло -16 отрицательное, пропускаем."
        };
        int expectedCount = 2;
        int expectedSum = 34;

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Equal(expectedPrimeSquares, primeSquares);
        Assert.Equal(expectedCount, count);
        Assert.Equal(expectedSum, sum);
        Assert.Equal(expectedErrors, errors);
    }

    // “ест дл€ массива, где числа не €вл€ютс€ квадратами простых чисел
    [Fact]
    public void FindPrimeSquares_WithNonSquareNumbers_ReturnsZero()
    {
        // Arrange
        int[] array = { 6, 12, 50, 18 };

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Empty(primeSquares);
        Assert.Equal(0, count);
        Assert.Equal(0, sum);
        Assert.Empty(errors);
    }
}