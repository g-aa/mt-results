using System.Text.Json.Serialization;

namespace Mt.Results;

/// <summary>
/// Формат сообщения.
/// </summary>
[Serializable]
public class MtMessageResult
{
    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtMessageResult"/>.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public MtMessageResult(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Сообщение.
    /// </summary>
    /// <example>Текст сообщения...</example>
    [JsonPropertyName("message")]
    public string Message { get; private set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"message: {Message}";
    }
}