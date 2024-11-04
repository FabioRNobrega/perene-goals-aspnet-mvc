using System;

namespace perene_goals_dotnet.Models;

public class GoalsListVote
{
    public int Id {get; set;}
    public int GoalsListId {get; set;}
    public int UserId {get; set;}
    public int VotesUp {get; set;}
    public int VotesDown {get; set;}

    // Navigation Property
    public GoalsList GoalsList {get; set;} = null!;



}
