using System;

namespace perene_goals_dotnet.Models;

public class GoalsStep
{
    public int Id {get; set;}
    public string Title {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public int GoalId {get; set;}

    // Navigation Property
    public Goal Goal {get; set;} = null!;

    // Clone Method    
    public GoalsStep CloneForGoal(Goal newGoal)
    {
        var newStep = (GoalsStep)this.MemberwiseClone();
        newStep.GoalId = newGoal.Id;
        return newStep;
    }
}
