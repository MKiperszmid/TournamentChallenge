using System;
using System.Collections.Generic;
using System.Linq;
namespace Torneo
{
    //Tournament Challenge made by VirtualMind. https://www.linkedin.com/feed/update/urn:li:activity:6465238703085359104
    //Solution made by Martin Kiperszmid.
    class Program
    {
        static void Main(string[] args)
        {
            //Armamos una lista de todos los partidos que se jugaron.
            List<Match> Matches = new List<Match>{new Match("Boca", "River", Result.LOCAL_WON),
                new Match("Racing", "Independiente", Result.VISITOR_WON),
                new Match("Barcelona", "Real Madrid", Result.DRAW),
                new Match("Independiente", "Real Madrid", Result.DRAW)
            };
            CalculateWinner(6, Matches);
        }

        private static void CalculateWinner(int teamCount, List<Match> matches) //No hubo necesidad de la variable teamCount
        {
            //Diccionario/Mapa con clave siendo el nombre del equipo, y valor siendo su puntaje
            Dictionary<string, int> Teams = new Dictionary<string, int>();
            foreach (var match in matches)
            {
                int localPoints = 0;
                int visitorPoints = 0;
                //Nos fijamos si los equipos del partido, estan incluidos en nuestro diccionario/mapa
                if (!Teams.ContainsKey(match.Local)) Teams.Add(match.Local, 0);
                if (!Teams.ContainsKey(match.Visitor)) Teams.Add(match.Visitor, 0);
                switch (match.Result)
                {
                    case Result.LOCAL_WON:
                        localPoints = 3;
                        break;
                    case Result.VISITOR_WON:
                        visitorPoints = 3;
                        break;
                    case Result.DRAW:
                        localPoints = 1;
                        visitorPoints = 1;
                        break;
                }
                Teams[match.Local] += localPoints;
                Teams[match.Visitor] += visitorPoints;
            }
            Console.WriteLine("Scoreboard: ");
            Console.WriteLine();
            //Ordenamos la lista, dependiendo su puntaje (la posicion 0 del mapa, va a tener al de mayor puntaje)
            var orderedTeams = Teams.OrderByDescending(x => x.Value);
            foreach (var keyPair in orderedTeams)
            {
                Console.WriteLine(keyPair.Key + " - " + keyPair.Value);
            }
            Console.ReadLine();
        }
    }
}
