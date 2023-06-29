# <p><img src="iconMt.png" width="64px" height="64px" align="middle"/> Mt Results</p>

Стандартные ответы результатов операций используемые в проектах Mt Rele.

## Перечень технологий (зависимости):

netstandard2.1, [Mt.Utilities](https://github.com/g-aa/mt-utilities), SonarAnalyzer.CSharp, NUnit.

## [История изменения.](CHANGELOG.md)

## Покрытие кода тестами:

Перед первым запуском ```.test.bat```, для просмотра покрытия кода тестами необходимо выполнить команду:

```dotnet tool list --global```

```
Идентификатор пакета                   Версия      Команды
------------------------------------------------------------------
dotnet-reportgenerator-globaltool      5.1.19      reportgenerator
```


```dotnet tool install -g dotnet-reportgenerator-globaltool```

## Основной функционал пакета:

| Компонент                   | Описание                                              |
|-----------------------------|-------------------------------------------------------|
| Mt.Results.MtAppDescription | Формат ответа об описании приложения.                 |
| Mt.Results.MtMessageResult  | Формат ответа для текстового сообщения.               |
| Mt.Results.MtProblemDetails | Формат ответа при срабатывании ошибки или исключения. |