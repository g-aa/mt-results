using Mt.Utilities;
using System.Text.Json.Serialization;

namespace Mt.Results;

/// <summary>
/// Формат сообщения.
/// </summary>
[Serializable]
public class MtMessageResult
{
    /// <summary>
    /// Сообщение.
    /// </summary>
    /// <example>Текст сообщения...</example>
    [JsonPropertyName("message")]
    public string Message { get; private set; }

    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtMessageResult"/>.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    public MtMessageResult(string message)
    {
        this.Message = Check.NotEmpty(message, nameof(message));
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"message: {this.Message}";
    }
}