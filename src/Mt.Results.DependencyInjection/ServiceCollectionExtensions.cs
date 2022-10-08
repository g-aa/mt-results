using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Mt.Utilities;

namespace Mt.Results.DependencyInjection
{
    /// <summary>
    /// Методы расширения для <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавить компоненты фабрики создание стандартных ответов действия <see cref="IActionResult"/> для проектов MT.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns>Модифицированная коллекция сервисов.</returns>
        public static IServiceCollection AddMtActionResultFactory(this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));
            services.AddSingleton<IMtResultFactory, DefaultMtResultFactory>();
            return services;
        }
    }
}