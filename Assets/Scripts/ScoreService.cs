using System;

public interface IScoreService
{
    int CurrentScore { get; }
    event Action<int> OnScoreChanged; //Patrón observador también incluido
}