using NUnit.Framework;
using System;

namespace Mt.Results.Test
{
    /// <summary>
    /// Набор тестов для <see cref="MtMessageResult"/>.
    /// </summary>
    [TestFixture]
    public sealed class MtMessageResultTests
    {
        /// <summary>
        /// Положительные тесты для конструктора <see cref="MtMessageResult"/>. 
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("successfully", "successfully")]
        public void ConstructorPositiveTest(string message, string expected)
        {
            var result = new MtMessageResult(message);
            Assert.That(result.Message, Is.EqualTo(expected));
        }

        /// <summary>
        /// Отрицательные тесты для конструктора <see cref="MtMessageResult"/>. 
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase(" ", typeof(ArgumentException))]
        [TestCase("\t", typeof(ArgumentException))]
        public void ConstructorNegativeTest(string message, Type expected)
        {
            var ex = Assert.Catch(() => new MtMessageResult(message));
            Assert.That(ex.GetType().Name, Is.EqualTo(expected.Name));
        }

        /// <summary>
        /// Тесты для метода ToString <see cref="MtMessageResult"/>. 
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="expected">Ожидаемый результат.</param>
        [Test]
        [TestCase("successfully", "message: successfully")]
        public void ToStringTest(string message, string expected)
        {
            var result = new MtMessageResult(message);
            Assert.That(result.ToString(), Is.EqualTo(expected));
        }
    }
}