using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TeamsCollection teams = new TeamsCollection();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "END")
                {
                    break;
                }

                string[] comandArgs = comand.Split(";");

                try
                {
                    if (comandArgs[0] == "Team")
                    {
                        Team team = new Team(comandArgs[1]);
                        teams.AddTeam(team);
                    }

                    else if (comandArgs[0] == "Add")
                    {
                        Player player = new Player(comandArgs[2], int.Parse(comandArgs[3]), int.Parse(comandArgs[4]),
                            int.Parse(comandArgs[5]), int.Parse(comandArgs[6]), int.Parse(comandArgs[7]));

                        var team = teams.ReturnTeam(comandArgs[1]);
                        team.AddPlayer(player);
                    }

                    else if (comandArgs[0] == "Remove")
                    {
                        var team = teams.ReturnTeam(comandArgs[1]);
                        team.RemovePlayer(comandArgs[2]);
                    }

                    else if (comandArgs[0] == "Rating")
                    {
                        var team = teams.ReturnTeam(comandArgs[1]);
                        Console.WriteLine($"{team.TeamName} - {team.Rating}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
