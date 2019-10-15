using System;
using System.Collections.Generic;
using System.Linq;
using Api.Enigma.Repositories.Entities;
using Api.Enigma.Repositories.Interfaces;

namespace Api.Enigma.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public ScoreRepository()
        {
        }

        public void AddNewScore(string player, int level, int time, int step)
        {
            using (var dbContext = new EnigmaDataContext())
            {
                ScoreEntity score = new ScoreEntity();
                score.Player = player;
                score.Level = level;
                score.Time = time;
                score.Step = step;
                dbContext.Scores.Add(score);
                dbContext.SaveChanges();
            }

        }

        public void CleanUpScore()
        {
            using (var dbContext = new EnigmaDataContext())
            {
                var scores = dbContext.Scores;
                dbContext.RemoveRange(scores);
                dbContext.SaveChanges();
            }
        }

        public List<ScoreEntity> GetAllScore()
        {
            using(var dbContext = new EnigmaDataContext())
            {
                return dbContext.Scores.ToList();
            }
        }

        public ScoreEntity GetScore(string player)
        {
            using(var dbContext = new EnigmaDataContext())
            {
                return dbContext.Scores.Where(s => s.Player.ToLower() == player.ToLower()).OrderByDescending(s => s.Score).FirstOrDefault();
            }
        }

        public bool IsScoreAlreadySubmitted(string playerName, int level)
        {
            using (var dbContext = new EnigmaDataContext())
            {
                return dbContext.Scores.Count(c => c.Player.ToLower() == playerName.ToLower() && c.Level == level) > 0;
            }
        }

        public void UpdateScore(string player, int level, int time, int step)
        {
            using (var dbContext = new EnigmaDataContext())
            {
                ScoreEntity score = dbContext.Scores.SingleOrDefault(c => c.Player.ToLower() == player.ToLower() && c.Level == level);
                if(score != null )
                {
                    score.Level = level;
                    score.Time = time;
                    score.Step = step;
                    dbContext.SaveChanges();
                }
                
            }
        }
    }
}
