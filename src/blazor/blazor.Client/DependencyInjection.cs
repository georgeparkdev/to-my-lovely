using blazor.Client.Domain.Services;

namespace blazor.Client;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStageStateService, StageStateService>();
        services.AddScoped<IAuthStageStateService, AuthStageStateService>();
        services.AddScoped<IQuestionsStateService, QuestionsStateService>();
    }
}