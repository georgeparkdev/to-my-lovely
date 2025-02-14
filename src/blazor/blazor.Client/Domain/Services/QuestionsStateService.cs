using Ardalis.SmartEnum;

namespace blazor.Client.Domain.Services;

public interface IQuestionsStateService
{
    Question GetCurrentQuestion();
    bool CheckAnswer(string answer);
    void NextQuestion();
    
    bool IsLastQuestion();
    
    public sealed class Question(string name, int value) : SmartEnum<Question>(name, value)
    {
        public string QuestionText { get; init; } = null!;
        public string[] PossibleAnswers { get; init; } = null!;
        public string CorrectAnswer { get; init; } = null!;
        
        public readonly static Question MyFavoriteColor = new(nameof(MyFavoriteColor), 1)
        {
            QuestionText = "Какой мой любимый цвет?",
            PossibleAnswers = ["Красный", "Зеленый", "Синий", "Желтый", "Черный"],
            CorrectAnswer = "Желтый"
        };
        
        public readonly static Question YourFavoriteColor = new(nameof(YourFavoriteColor), 2)
        {
            QuestionText = "Какой твой любимый цвет?",
            PossibleAnswers = ["Красный", "Зеленый", "Синий", "Желтый", "Черный"],
            CorrectAnswer = "Черный"
        };
        
        public readonly static Question WhenWeStartedDating = new(nameof(WhenWeStartedDating), 3)
        {
            QuestionText = "Когда мы начали встречаться?",
            PossibleAnswers = [],
            CorrectAnswer = "12.11.2023"
        };
        
        public readonly static Question WhereWeStartedDating = new(nameof(WhereWeStartedDating), 4)
        {
            QuestionText = "Где мы начали встречаться (город)?",
            PossibleAnswers = [],
            CorrectAnswer = "Аджман"
        };
        
        public readonly static Question MyFavoriteAnimal = new(nameof(MyFavoriteAnimal), 5)
        {
            QuestionText = "Какое мое любимое животное?",
            PossibleAnswers = ["Кошка", "Собака", "Бабочка", "Попугай", "Хомяк", "Кролик", "Слон"],
            CorrectAnswer = "Слон"
        };
        
        public readonly static Question YourFavoriteAnimal = new(nameof(YourFavoriteAnimal), 6)
        {
            QuestionText = "Какое твое любимое животное?",
            PossibleAnswers = ["Кошка", "Собака", "Бабочка", "Попугай", "Хомяк", "Кролик", "Слон"],
            CorrectAnswer = "Бабочка"
        };
    }
}

public sealed class QuestionsStateService : IQuestionsStateService
{
    private readonly List<IQuestionsStateService.Question> _questions = [
        IQuestionsStateService.Question.MyFavoriteColor,
        IQuestionsStateService.Question.YourFavoriteColor,
        IQuestionsStateService.Question.WhenWeStartedDating,
        IQuestionsStateService.Question.WhereWeStartedDating,
        IQuestionsStateService.Question.MyFavoriteAnimal,
        IQuestionsStateService.Question.YourFavoriteAnimal
    ];
    private int _currentQuestionIndex = 0;
    
    public IQuestionsStateService.Question GetCurrentQuestion() => _questions[_currentQuestionIndex];

    public bool CheckAnswer(string answer)
    {
        IQuestionsStateService.Question currentQuestion = GetCurrentQuestion();
        return currentQuestion.CorrectAnswer == answer;
    }

    public void NextQuestion()
    {
        _currentQuestionIndex++;
    }

    public bool IsLastQuestion()
    {
        return _currentQuestionIndex == _questions.Count - 1;
    }
}