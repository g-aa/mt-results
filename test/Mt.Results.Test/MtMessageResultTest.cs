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
        Assert.That(result.Message, Is.EqualTo(expected));
    }

    /// <summary>
    /// Отрицательный тест для <see cref="MtMessageResult(string)"/>.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(null, typeof(ArgumentNullException))]
    [TestCase("", typeof(ArgumentException))]
    [TestCase(" ", typeof(ArgumentException))]
    [TestCase("\t", typeof(ArgumentException))]
    public void ConstructorNegativeTest(string message, Type expected)
    {
        // act
        var ex = Assert.Catch(() => new MtMessageResult(message));

        // assert
        Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
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
        Assert.That(result.ToString(), Is.EqualTo(expected));
    }
}