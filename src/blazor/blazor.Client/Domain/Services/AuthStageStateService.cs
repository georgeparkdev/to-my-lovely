namespace blazor.Client.Domain.Services;

public interface IAuthStageStateService
{
    string CurrentStage { get; }
    void SetInitialStage();
    void SetErrorStage();
    void SetQuestionsStage();
    void SetTryAgainStage();
}

public sealed class AuthStageStateService : IAuthStageStateService
{
    public const string InitialStage = "InitialStage";
    public const string ErrorStage = "ErrorStage";
    public const string QuestionsStage = "QuestionStage";
    public const string TryAgainStage = "TryAgainStage";
    
    public string CurrentStage { get; private set; } = InitialStage;

    public void SetInitialStage()
    {
        CurrentStage = InitialStage;
    }

    public void SetErrorStage()
    {
        CurrentStage = ErrorStage;
    }

    public void SetQuestionsStage()
    {
        CurrentStage = QuestionsStage;
    }

    public void SetTryAgainStage()
    {
        CurrentStage = TryAgainStage;
    }
}