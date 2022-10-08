using System.Text.Json.Serialization;

namespace Mt.Results
{
    /// <summary>
    /// Формат сообщения.
    /// </summary>
    public class MtMessageResult
    {
        /// <summary>
        /// Сообщение.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; private set; }

        /// <summary>
        /// Инициализация экземпляра класса <see cref="MtMessageResult"/>.
        /// </summary>
        /// <param name="message"></param>
        public MtMessageResult(string message)
        {
            this.Message = string.IsNullOrWhiteSpace(message) ? "successfully" : message;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"message: {this.Message}";
        }
    }
}