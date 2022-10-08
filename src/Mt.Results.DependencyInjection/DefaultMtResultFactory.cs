using Microsoft.AspNetCore.Mvc;
using Mt.Utilities;
using Mt.Utilities.Exceptions;
using Mt.Utilities.Extensions;
using System;

namespace Mt.Results.DependencyInjection
{
    /// <summary>
    /// Базовая фабрика результатов действия применяемых в MT для ASP.Net.
    /// </summary>
    internal sealed class DefaultMtResultFactory : IMtResultFactory
    {
        /// <summary>
        /// Передавать детализацию об исключениях. 
        /// </summary>
        private readonly bool passDetails;

        /// <summary>
        /// Инициализация экземпляра класса <see cref="DefaultMtResultFactory"/>.
        /// </summary>
        public DefaultMtResultFactory()
        {
            this.passDetails = false;
        }
        
        /// <inheritdoc />
        public IActionResult CreateResult(object content)
        {
            switch (Check.NotNull(content, nameof(content)))
            {
                case ErrorCode code:
                    return this.ErrorCodeResult(code);
                    
                case MtException exception:
                    return this.MtExceptionResult(exception);
                    
                case MtBaseException exception:
                    return this.MtBaseExceptionResult(exception);

                case Exception exception:
                    return this.ExceptionResult(exception);

                case string message:
                    return this.OkMessageResult(message);

                default:
                    return this.OkResult(content);
            }
        }
        
        /// <summary>
        /// Получить результат действия для кода ошибки <see cref="ErrorCode"/>.
        /// </summary>
        /// <param name="code">Код ошибки.</param>
        /// <returns>ObjectResult.</returns>
        private IActionResult ErrorCodeResult(ErrorCode code = ErrorCode.InternalServerError)
        {
            var details = new MtProblemDetails(code);
            return new ObjectResult(details)
            {
                StatusCode = code.HttpStatusCode(),
            };
        }

        /// <summary>
        /// Получить результат действия для базового исключения MT <see cref="MtBaseException"/>.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <remarks>HTTP status code: 400.</remarks>
        /// <returns>ObjectResult.</returns>
        private IActionResult MtBaseExceptionResult(MtBaseException exception)
        {
            var details = new MtProblemDetails(exception);
            return new ObjectResult(details)
            {
                StatusCode = 400,
            };
        }

        /// <summary>
        /// Получить результат действия для исключения MT <see cref="MtException"/>. 
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <returns>ObjectResult.</returns>
        private IActionResult MtExceptionResult(MtException exception)
        {
            var details = new MtProblemDetails(exception);
            return new ObjectResult(details)
            {
                StatusCode = exception.Code.HttpStatusCode(),
            };
        }

        /// <summary>
        /// Получить результат действия для исключения <see cref="Exception"/>. 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private IActionResult ExceptionResult(Exception exception)
        {
            var code = ErrorCode.InternalServerError;
            var details = new MtProblemDetails(code.Title(), this.passDetails ? exception.Message : code.Desc());
            return new ObjectResult(details)
            {
                StatusCode = code.HttpStatusCode(),
            };
        }

        /// <summary>
        /// Получить результат действия для сообщения <see cref="MtMessageResult"/>.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <returns>ObjectResult.</returns>
        private IActionResult OkMessageResult(string message)
        {
            var result = new MtMessageResult(message);
            return new ObjectResult(result)
            {
                StatusCode = 200,
            };
        }

        /// <summary>
        /// Получить результат действия для положительного результата общего вида.
        /// </summary>
        /// <param name="obj">Объект данных.</param>
        /// <returns>ObjectResult.</returns>
        private IActionResult OkResult(object obj)
        {
            return new ObjectResult(obj)
            {
                StatusCode = 200,
            };
        }
    }
}