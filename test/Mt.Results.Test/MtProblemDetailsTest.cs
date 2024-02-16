using Mt.Utilities.Exceptions;

namespace Mt.Results.Test;

/// <summary>
/// Набор тестов для <see cref="MtProblemDetails"/>.
/// </summary>
[TestFixture]
public sealed class MtProblemDetailsTest
{
    /// <summary>
    /// Положительный тест для <see cref="MtProblemDetails()"/>.
    /// </summary>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase("MT-E0001: Внутренняя ошибка логики приложения.")]
    public void ConstructorPositiveTest(string expected)
    {
        // act
        var details = new MtProblemDetails();

        // assert
        details.ToString().Should().Be(expected);
    }

    /// <summary>
    /// Положительный тест для <see cref="MtProblemDetails(ErrorCode)"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(ErrorCode.InternalLogicError, "MT-E0001: Внутренняя ошибка логики приложения.")]
    [TestCase(ErrorCode.EntityAlreadyExists, "MT-E0012: Сущность уже содержится в последовательности.")]
    public void ConstructorPositiveTest(ErrorCode code, string expected)
    {
        // act
        var details = new MtProblemDetails(code);

        // assert
        details.ToString().Should().Be(expected);
    }

    /// <summary>
    /// Положительный тест для <see cref="MtProblemDetails(MtBaseException)"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Сообщение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(ErrorCode.EntityAlreadyExists, "", "MT-E0012: Сущность уже содержится в последовательности.")]
    [TestCase(ErrorCode.InternalLogicError, " ", "MT-E0001: Внутренняя ошибка логики приложения.")]
    [TestCase(ErrorCode.EntityValidation, "\t", "MT-E0010: Ошибка валидации параметров сущности.")]
    [TestCase(ErrorCode.InvalidOperation, "Сработала ошибка.", "MT-E0002: Сработала ошибка.")]
    public void ConstructorPositiveTest(ErrorCode code, string message, string expected)
    {
        // arrange
        var exception = new MtException(code, message);

        // act
        var details = new MtProblemDetails(exception);

        // assert
        details.ToString().Should().Be(expected);
        details.Title.Should().Be(exception.Title);
        details.Description.Should().Be(exception.Desc);
    }

    /// <summary>
    /// Положительный тест для <see cref="MtProblemDetails(string, string)"/>.
    /// </summary>
    /// <param name="title">Заголовок.</param>
    /// <param name="description">Описание.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase("title", "description", "title: description")]
    public void ConstructorPositiveTest(string title, string description, string expected)
    {
        // act
        var details = new MtProblemDetails(title, description);

        // assert
        details.ToString().Should().Be(expected);
    }
}