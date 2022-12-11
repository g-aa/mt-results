using Mt.Utilities.Exceptions;
using NUnit.Framework;
using System;

namespace Mt.Results.Test
{
    /// <summary>
    /// Набор тестов для <see cref="MtProblemDetails"/>.
    /// </summary>
    [TestFixture]
    public sealed class MtProblemDetailsTests
    {
        /// <summary>
        /// Положительные тесты для конструктора <see cref="MtProblemDetails"/>. 
        /// </summary>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("MT-E0001: Внутренняя ошибка логики приложения.")]
        public void ConstructorPositiveTest(string expected)
        {
            var details = new MtProblemDetails();
            Assert.That(details.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для конструктора <see cref="MtProblemDetails"/>. 
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.InternalLogicError, "MT-E0001: Внутренняя ошибка логики приложения.")]
        [TestCase(ErrorCode.EntityAlreadyExists, "MT-E0012: Сущность уже содержится в последовательности.")]
        public void ConstructorPositiveTest(ErrorCode code, string expected)
        {
            var details = new MtProblemDetails(code);
            Assert.That(details.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Положительные тесты для конструктора <see cref="MtProblemDetails"/>. 
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(ErrorCode.EntityAlreadyExists, "", "MT-E0012: Сущность уже содержится в последовательности.")]
        [TestCase(ErrorCode.InternalLogicError, " ", "MT-E0001: Внутренняя ошибка логики приложения.")]
        [TestCase(ErrorCode.EntityValidation, "\t", "MT-E0010: Ошибка валидации параметров сущности.")]
        [TestCase(ErrorCode.InvalidOperation, "Сработала ошибка.", "MT-E0002: Сработала ошибка.")]
        public void ConstructorPositiveTest(ErrorCode code, string message, string expected)
        {
            var exception = new MtException(code, message);
            var details = new MtProblemDetails(exception);
            Assert.Multiple(() =>
            {
                Assert.That(details.ToString(), Is.EqualTo(expected));
                Assert.That(details.Title, Is.EqualTo(exception.Title));
                Assert.That(details.Description, Is.EqualTo(exception.Desc));
            });
        }

        /// <summary>
        /// Отрицательные тесты для конструктора <see cref="MtProblemDetails"/>. 
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="description">Описание.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("title", "description", "title: description")]
        public void ConstructorPositiveTest(string title, string description, string expected)
        {
            var details = new MtProblemDetails(title, description);
            Assert.That(details.ToString(), Is.EqualTo(expected));
        }

        /// <summary>
        /// Отрицательные тесты для конструктора <see cref="MtProblemDetails"/>. 
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="description">Описание.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, null, typeof(ArgumentNullException))]
        [TestCase("title", null, typeof(ArgumentNullException))]
        [TestCase(null, "description", typeof(ArgumentNullException))]
        public void ConstructorNegativeTest(string title, string description, Type expected)
        {
            var ex = Assert.Catch(() => new MtProblemDetails(title, description));
            Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
        }

        /// <summary>
        /// Отрицательные тесты для конструктора <see cref="MtProblemDetails"/>.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        public void ConstructorNegativeTest(MtException exception, Type expected)
        {
            var ex = Assert.Catch(() => new MtProblemDetails(exception));
            Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
        }
    }
}