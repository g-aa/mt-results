# <p><img src="iconMt.png" width="64px" height="64px" align="middle"/> Mt Results</p>

Стандартные ответы результатов операций используемые в проектах Mt-Relay.

## Перечень технологий

net8.0, [Mt.Utilities](https://github.com/g-aa/mt-utilities), SonarAnalyzer.CSharp, NUnit.

## [История изменения](CHANGELOG.md)

## Покрытие кода тестами

Перед первым запуском `.test.bat`, для просмотра покрытия кода тестами проверьте наличие `dotnet-reportgenerator-globaltool` выполнив команду:

`dotnet tool list --global`

в перечне пакетов должен присутствовать необходимый пакет:

```
Идентификатор пакета                   Версия      Команды
------------------------------------------------------------------
dotnet-reportgenerator-globaltool      5.1.19      reportgenerator
```

при его отсутствии необходимо выполнить команду:

`dotnet tool install -g dotnet-reportgenerator-globaltool`

## Основной функционал пакета

| Компонент                   | Описание                                              |
|-----------------------------|-------------------------------------------------------|
| Mt.Results.MtAppDescription | Формат ответа об описании приложения.                 |
| Mt.Results.MtMessageResult  | Формат ответа для текстового сообщения.               |
| Mt.Results.MtProblemDetails | Формат ответа при срабатывании ошибки или исключения. |