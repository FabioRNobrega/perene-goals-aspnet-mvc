using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace perene_goals_dotnet.Models;

public class GoalsList
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public string UserId { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    public ICollection<GoalsListVote> GoalsListVotes { get; set; } = new List<GoalsListVote>();

    // Clone Method
    public GoalsList CloneForUser(string newUserId)
    {
        var newGoalList = (GoalsList)this.MemberwiseClone();
        newGoalList.UserId = newUserId;
        newGoalList.IsPublic = false;

        foreach (var goal in Goals)
        {
            var newGoal = goal.CloneForGoalList(newGoalList);
            newGoalList.Goals.Add(newGoal);
        }

        return newGoalList;
    }

    // Handle votes
    public Dictionary<string, int> GetVotesCount()
    {
        int votesUp = GoalsListVotes.Sum(v => v.VotesUp);
        int votesDown = GoalsListVotes.Sum(v => v.VotesDown);
        return new Dictionary<string, int> { { "VotesUp", votesUp }, { "VotesDown", votesDown } };
    }
}
