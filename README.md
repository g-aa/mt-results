# <p><img src="iconMt.png" width="64px" height="64px" align="middle"/> Mt Results</p>

Стандартные ответы результатов операций используемые в проектах Mt Rele.

## Перечень технологий (зависимости):

netstandard2.1, [Mt.Utilities](https://github.com/g-aa/mt-utilities), SonarAnalyzer.CSharp, NUnit.

## [История изменения.](CHANGELOG.md)

## Основной функционал пакета:

| Компонент                                       | Описание                                                            |
|-------------------------------------------------|---------------------------------------------------------------------|
| Mt.Results.MtProblemDetails                     | Формат ответа при срабатывании ошибки или исключения.               |
| Mt.Results.MtMessageResult                      | Формат ответа для текстового сообщения.                             |
| Mt.Results.DependencyInjection.IMtResultFactory | Фабрика со созданию типовых ответов на запросы.                     |