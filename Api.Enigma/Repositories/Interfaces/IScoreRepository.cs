using System;
using System.Collections.Generic;
using Api.Enigma.Repositories.Entities;

namespace Api.Enigma.Repositories.Interfaces
{
    public interface IScoreRepository
    {
        void AddNewScore(string player, int level, int time, int step);

        void UpdateScore(string player, int level, int time, int step);

        bool IsScoreAlreadySubmitted(string playerName, int level);

        List<ScoreEntity> GetAllScore();

        ScoreEntity GetScore(string player);

        void CleanUpScore();
    }
}
