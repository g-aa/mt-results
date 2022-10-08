using Microsoft.AspNetCore.Mvc;
using System;

namespace Mt.Results.DependencyInjection
{
    /// <summary>
    /// Фабрика результатов действия применяемых в проектах MT для ASP.NET Core.
    /// </summary>
    public interface IMtResultFactory
    {
        /// <summary>
        /// Создать типовой результат действия для проектов MT.
        /// </summary>
        /// <param name="content">Данные встраиваемые в тело ответа.</param>
        /// <remarks>В зависимости от типа <paramref name="content"/> генерируются разная реализация для <see cref="IActionResult"/>.</remarks>
        /// <returns>Сконфигурированный результат действия.</returns>
        /// <exception cref="ArgumentNullException">Срабатывает если <paramref name="content"/> равен null.</exception>
        IActionResult CreateResult(object content);
    }
}