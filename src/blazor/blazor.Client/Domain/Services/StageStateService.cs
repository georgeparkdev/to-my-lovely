namespace blazor.Client.Domain.Services;

public interface IStageStateService
{
    void SetNextStage();
    void SetPreviousStage();
    string GetCurrentStage();
    void SetInitialStage();
}

public sealed class StageStateService : IStageStateService
{
    public const string AuthStage = "AuthStage";
    public const string LoveLetterStage = "LoveLetterStage";
    public const string DreamsStage = "DreamsStage";
    public const string BehindTheScenesStage = "BehindTheScenesStage";

    public readonly static List<string> Stages = [
        AuthStage,
        LoveLetterStage,
        DreamsStage,
        BehindTheScenesStage
    ];
    
    public static string InitialStage => AuthStage;
    private string CurrentStage { get; set; } = InitialStage;
    
    
    public void SetNextStage()
    {
        var currentIndex = Stages.IndexOf(CurrentStage);
        var nextIndex = currentIndex + 1;
        CurrentStage = nextIndex >= Stages.Count
            ? Stages[^1]
            : Stages[nextIndex];
    }
    
    public void SetPreviousStage()
    {
        var currentIndex = Stages.IndexOf(CurrentStage);
        var previousIndex = currentIndex - 1;
        CurrentStage = previousIndex < 0
            ? Stages[0]
            : Stages[previousIndex];
    }
    
    public string GetCurrentStage()
    {
        return CurrentStage;
    }
    
    public void SetInitialStage()
    {
        CurrentStage = InitialStage;
    }
}