namespace Mt.Results.Test;

/// <summary>
/// Набор тестов для <see cref="MtMessageResult"/>.
/// </summary>
[TestFixture]
public sealed class MtMessageResultTest
{
    /// <summary>
    /// Положительный тест для <see cref="MtMessageResult(string)"/>.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase("successfully", "successfully")]
    public void ConstructorPositiveTest(string message, string expected)
    {
        // act
        var result = new MtMessageResult(message);

        // assert
        result.Message.Should().Be(expected);
    }

    /// <summary>
    /// Тест для <see cref="MtMessageResult.ToString()"/>.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase("successfully", "message: successfully")]
    public void ToStringTest(string message, string expected)
    {
        // act
        var result = new MtMessageResult(message);

        // assert
        result.ToString().Should().Be(expected);
    }
}