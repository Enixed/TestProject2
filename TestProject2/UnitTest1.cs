using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using Xunit;

public class PrimeSquaresTests
{
    // ���� ��� ����������� ������, ��� ���� �������� ������� �����
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

    // ���� ��� ������ � ������ ��������
    [Fact]
    public void FindPrimeSquares_WithEmptyArray_ReturnsEmptyResult()
    {
        // Arrange
        int[] array = { };
        var expectedErrors = new List<string> { "������ ������ ��� null." };

        // Act
        var (primeSquares, count, sum, errors) = Program.FindPrimeSquares(array);

        // Assert
        Assert.Empty(primeSquares);
        Assert.Equal(0, count);
        Assert.Equal(0, sum);
        Assert.Equal(expectedErrors, errors);
    }

    // ���� ��� �������, ��� ��� ��������� ������� �����
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

    // ���� ��� ������� � �������������� �������
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
            "����� -4 �������������, ����������.",
            "����� -16 �������������, ����������."
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

    // ���� ��� �������, ��� ����� �� �������� ���������� ������� �����
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