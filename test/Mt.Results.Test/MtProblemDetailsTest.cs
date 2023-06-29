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
        Assert.That(details.ToString(), Is.EqualTo(expected));
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
        Assert.That(details.ToString(), Is.EqualTo(expected));
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
        Assert.Multiple(() =>
        {
            Assert.That(details.ToString(), Is.EqualTo(expected));
            Assert.That(details.Title, Is.EqualTo(exception.Title));
            Assert.That(details.Description, Is.EqualTo(exception.Desc));
        });
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
        Assert.That(details.ToString(), Is.EqualTo(expected));
    }

    /// <summary>
    /// Отрицательный тест для <see cref="MtProblemDetails(string, string)"/>.
    /// </summary>
    /// <param name="title">Заголовок.</param>
    /// <param name="description">Описание.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(null, null, typeof(ArgumentNullException))]
    [TestCase("title", null, typeof(ArgumentNullException))]
    [TestCase(null, "description", typeof(ArgumentNullException))]
    public void ConstructorNegativeTest(string title, string description, Type expected)
    {
        // act
        var ex = Assert.Catch(() => new MtProblemDetails(title, description));

        // assert
        Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
    }

    /// <summary>
    /// Отрицательный тест для конструктора <see cref="MtProblemDetails(MtBaseException)"/>.
    /// </summary>
    /// <param name="exception">Исключение.</param>
    /// <param name="expected">Ожидаемый результат.</param>
    [TestCase(null, typeof(ArgumentNullException))]
    public void ConstructorNegativeTest(MtException exception, Type expected)
    {
        // act
        var ex = Assert.Catch(() => new MtProblemDetails(exception));

        // assert
        Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
    }
}