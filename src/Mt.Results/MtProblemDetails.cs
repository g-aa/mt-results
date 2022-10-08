using Mt.Utilities;
using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;
using System;
using System.Text.Json.Serialization;

namespace Mt.Results
{
    /// <summary>
    /// Формат ответа при срабатывании ошибки или исключения.
    /// </summary>
    [Serializable]
    public sealed class MtProblemDetails
    {
        /// <summary>
        /// Заголовок (код ошибки).
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        [JsonPropertyName("desc")]
        public string Description { get; private set; }

        /// <summary>
        /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
        /// </summary>
        /// <remarks>По умолчанию генерирует ответ Title: MT-0001;  Description: Внутренняя ошибка логики приложения.</remarks>
        public MtProblemDetails()
        {
            var code = ErrorCode.InternalLogicError;
            this.Title = code.Title();
            this.Description = code.Desc();
        }

        /// <summary>
        /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        public MtProblemDetails(ErrorCode code)
        {
            this.Title = code.Title();
            this.Description = code.Desc();
        }

        /// <summary>
        /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="description">Описание.</param>
        public MtProblemDetails(string title, string description)
        {
            this.Title = Check.NotEmpty(title, nameof(title));
            this.Description = Check.NotEmpty(description, nameof(description));
        }

        /// <summary>
        /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        public MtProblemDetails(MtBaseException exception)
        {
            Check.NotNull(exception, nameof(exception));
            this.Title = exception.Title;
            this.Description = exception.Desc;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{this.Title}: {this.Description}";
        }
    }
}