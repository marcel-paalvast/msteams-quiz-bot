namespace MsTeamsQuizBot.Cards;

public interface ITemplate<T>
{
    public string Template { get; }
    public T Data { get; }
}
