using Xunit;
using RownanieKwadratowe;

public class UnitTest1
{
     [Theory]
    [InlineData(1.0, -3.0, 2.0, 2.0, 1.0)] // Przykład z dwoma pierwiastkami
    [InlineData(1.0, 2.0, 1.0, -1.0, null)] // Przykład z jednym pierwiastkiem
    [InlineData(1.0, 0.0, 1.0, null, null)] // Przykład bez pierwiastków
    public void TestObliczPierwiastki(double a, double b, double c, double? expected1, double? expected2)
    {
        (double? pierwiastek1, double? pierwiastek2) = Program.ObliczPierwiastki(a, b, c);
        Assert.Equal(expected1, pierwiastek1);
        Assert.Equal(expected2, pierwiastek2);
    }
     [Fact]
    public void TestDzieleniePrzezZero()
    {
        Assert.Throws<ArgumentException>(() => Program.ObliczPierwiastki(0, 1, 1));
    }

     [Fact]
    public void TestDuzeWartosci()
    {
        // Duże wartości współczynników
        var (pierwiastek1, pierwiastek2) = Program.ObliczPierwiastki(1e6, 1e6, 1);

        // Oczekiwane pierwiastki
        double expected1 = -1e-6;    // Pierwszy pierwiastek
        double expected2 = -0.999999; // Drugi pierwiastek

        // Sprawdzanie przybliżonej równości pierwiastków z tolerancją
        Assert.True(pierwiastek1.HasValue && Math.Abs(pierwiastek1.Value - expected1) < 1e-6);
        Assert.True(pierwiastek2.HasValue && Math.Abs(pierwiastek2.Value - expected2) < 1e-6);
    }
    }
