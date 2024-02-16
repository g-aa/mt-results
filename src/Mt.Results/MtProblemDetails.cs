using System.Text.Json.Serialization;

using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;

namespace Mt.Results;

/// <summary>
/// Формат ответа при срабатывании ошибки или исключения.
/// </summary>
[Serializable]
public sealed class MtProblemDetails
{
    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
    /// </summary>
    /// <remarks>По умолчанию генерирует ответ Title: MT-0001;  Description: Внутренняя ошибка логики приложения.</remarks>
    public MtProblemDetails()
    {
        var code = ErrorCode.InternalLogicError;
        Title = code.Title();
        Description = code.Desc();
    }

    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    public MtProblemDetails(ErrorCode code)
    {
        Title = code.Title();
        Description = code.Desc();
    }

    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
    /// </summary>
    /// <param name="title">Заголовок.</param>
    /// <param name="description">Описание.</param>
    public MtProblemDetails(string title, string description)
    {
        Title = title;
        Description = description;
    }

    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtProblemDetails"/>.
    /// </summary>
    /// <param name="exception">Исключение.</param>
    public MtProblemDetails(MtBaseException exception)
    {
        Title = exception.Title;
        Description = exception.Desc;
    }

    /// <summary>
    /// Заголовок (код ошибки).
    /// </summary>
    /// <example>MT-XXXX</example>
    [JsonPropertyName("title")]
    public string Title { get; private set; }

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    /// <example>Краткое описание ошибки...</example>
    [JsonPropertyName("desc")]
    public string Description { get; private set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Title}: {Description}";
    }
}