namespace Mt.Results.Test;

/// <summary>
/// Набор тестов для <see cref="MtAppDescription"/>.
/// </summary>
[TestFixture]
public sealed class MtAppDescriptionTest
{
    /// <summary>
    /// Положительный тест для <see cref="MtAppDescription()"/>.
    /// </summary>
    /// <param name="version">Версия приложения.</param>
    /// <param name="desc">Описание.</param>
    /// <param name="repository">Ссылка на репозиторий.</param>
    [TestCase("Mt-ApplicationName: v1.2.3", "Описание приложения.", "https://github.com/")]
    public void ConstructorPositiveTest(string version, string desc, string repository)
    {
        // arrange
        var copyright = $"НТЦ Механотроники 1993 – {DateTime.Now:yyyy}.";

        // act
        var result = new MtAppDescription
        {
            Version = version,
            Description = desc,
            Repository = repository,
        };

        // assert
        result.Copyright.Should().Be(copyright);
    }

    /// <summary>
    /// Тест для <see cref="MtAppDescription.ToString()"/>.
    /// </summary>
    /// <param name="version">Версия приложения.</param>
    /// <param name="desc">Описание.</param>
    /// <param name="repository">Ссылка на репозиторий.</param>
    [TestCase("Mt-ApplicationName: v1.2.3", "Описание приложения.", "https://github.com/")]
    public void ToStringTest(string version, string desc, string repository)
    {
        // arrange
        var copyright = $"НТЦ Механотроники 1993 – {DateTime.Now:yyyy}.";
        var toString = $"{version}; {copyright}; {repository}.";

        // act
        var result = new MtAppDescription
        {
            Version = version,
            Description = desc,
            Repository = repository,
        };

        // assert
        result.ToString().Should().Be(toString);
    }
}