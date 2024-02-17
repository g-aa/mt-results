using System.Text.Json.Serialization;

namespace Mt.Results;

/// <summary>
/// Формат ответа об описании приложения.
/// </summary>
[Serializable]
public sealed class MtAppDescription
{
    /// <summary>
    /// Инициализация экземпляра класса <see cref="MtAppDescription"/>.
    /// </summary>
    public MtAppDescription()
    {
        Version = string.Empty;
        Description = string.Empty;
        Copyright = $"НТЦ Механотроники 1993 – {DateTime.Now:yyyy}.";
        Repository = string.Empty;
    }

    /// <summary>
    /// Версия приложения (Mt-ApplicationName: vX.X.X.X).
    /// </summary>
    /// <example>Mt-ApplicationName: v0.0.0.0</example>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// Краткое описание приложения.
    /// </summary>
    /// <example>Описание приложения...</example>
    [JsonPropertyName("desc")]
    public string Description { get; set; }

    /// <summary>
    /// Авторские права.
    /// </summary>
    /// <example>НТЦ Механотроники 1993 – 2024.</example>
    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }

    /// <summary>
    /// Ссылка на репозиторий.
    /// </summary>
    /// <example>https://github.com/</example>
    [JsonPropertyName("repository")]
    public string Repository { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Version}; {Copyright}; {Repository}.";
    }
}