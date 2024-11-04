using System;

namespace perene_goals_dotnet.Models;

public class Goal
{
    public int Id {get; set;}
    public string Title { get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public int GoalsListId {get; set;}

    // Navigation Property
    public GoalsList GoalsList {get; set;} = null!; 
    public ICollection<GoalsStep> GoalSteps { get; set; } = new List<GoalsStep>(); 

    // Clone Method
    public Goal CloneForGoalList(GoalsList newGoalList)
    {
        var newGoal = (Goal)this.MemberwiseClone();
        newGoal.GoalsListId = newGoalList.Id;

        foreach ( var step in GoalSteps) 
        {
            var newStep = step.CloneForGoal(newGoal); 
            newGoal.GoalSteps.Add(newStep);
        }
        return newGoal;
    }
}
