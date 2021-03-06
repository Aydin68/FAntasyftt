using FantasyftLibraryy.Models;
using FAntasyftt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FAntasyftt.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FantasyftController : ControllerBase
    {
        static fantasyftContext context = new fantasyftContext();

        //----------------------------------------------------------GET-ROUTES---------------------------------------------------------------------------------------------------------------------

        [HttpGet("Matches")]
        public IEnumerable<Match> GetMatches()
        {
            Console.WriteLine("Returning all Matches ...");

            return context.Match;
        }

        [HttpGet("Teams/{teamid}/Matches")]
        public ActionResult<IEnumerable<Match>> GetMatchesOfTeam(int teamid)
        {
            Console.WriteLine($"Returning the gameplan of the Team with the ID:{teamid}...");

            Team selectedTeam = context.Team.Include(p=>p.MId).ThenInclude(l=>l.Sch).Where(l=>l.TId==teamid).FirstOrDefault();
            
           // var mm = context.Match.Where(j => j.TId.Contains(selectedTeam)).ToList();
           var mm = selectedTeam.MId;
            
            
            foreach (var item in mm)
            {
                item.St = context.Stadion.Where(l => l.StId == item.StId).FirstOrDefault(); 
                //item.Sch=context.Schiedsrichter.Where(l=>l.SchId==item.SchId).FirstOrDefault();

               
               
               
            }
           
            if (selectedTeam == null || mm == null)
            {
                return NotFound();
            }
            else
            {
               
                return Ok(mm);
            }

             
          
        }

        [HttpGet("Players")]
        public IEnumerable<Spieler> GetPlayers()
        {
            Console.WriteLine("Returning all Players ...");
            return context.Spieler ;
        }

        

        [HttpGet("Teams")]
        public IEnumerable<Team> GetTeams()
        {
            Console.WriteLine("Returning all Teams ...");
            return context.Team;
        }

       

        [HttpGet("Teams/{teamId}/Players")]
        public IEnumerable<Spieler> GetPlayersOfTeam(int teamId)
        {
            var selectedTeam = context.Team.Where(l => l.TId == teamId).FirstOrDefault();
            var spieler = context.Spieler.Where(k => k.TId == teamId).ToList();
           
           
            Console.WriteLine($"Returning all Players from Team with the ID:{teamId} ...");
            return spieler;
        }

        

        [HttpGet("Coaches")]
        public IEnumerable<Coach> GetCoaches()
        {
            Console.WriteLine("Returning all Coaches ...");
            return context.Coach;
        }

        

        [HttpGet("Teams/{teamId}/Coach")]
        public IEnumerable<Coach> GetCoach(int teamId)
        {
            
            var club = context.Team.Where(L => L.TId == teamId).FirstOrDefault();
            var coach = context.Coach.Where(l => l.TId == teamId).ToList();
         
            

    
            Console.WriteLine($"Returning the coach from the club with the ID: {teamId}...");

            return coach;
            

       
        }

        [HttpGet("Stadiums")]
        public IEnumerable<Stadion> GetStadiums()
        {
            Console.WriteLine("Returning all Stadiums ...");
            return context.Stadion;
        }


        [HttpGet("Teams/{teamId}/Stadium")]
        public ActionResult<Stadion> GetStadium(int teamId)
        {
            var club = context.Team.Where(L => L.TId == teamId).FirstOrDefault();
            var stadion = context.Stadion.Where(l => l.TId == teamId).ToList();
            Console.WriteLine($"Returning Stadium of the club with the ID:{teamId} ...");
            if (club==null||stadion== null)
            {
                return NotFound();
            }
            else
            {
                
                return Ok(stadion); 
            }
            
        }


        [HttpGet("Referees")]
        public IEnumerable<Schiedsrichter> GetReferees()
        {
            Console.WriteLine("Returning all Referees ...");
            return context.Schiedsrichter;
        }


        //----------------------------------------------------------DELETE-ROUTES---------------------------------------------------------------------------------------------------------------------
        

        [HttpDelete("Teams/{teamid}")]
        public ActionResult DeleteTeam(int teamid)
        {
            

            Team selectedTeam = context.Team.Where(p => p.TId == teamid).FirstOrDefault();
            Console.WriteLine($"Deleting Team with the ID: {teamid}...");

            if (selectedTeam == null)
            {
                return NotFound();
            }
            else
            {
               

                context.Team.Remove(selectedTeam);
                context.SaveChanges();
                return Ok();

               
            }
        }

        [HttpDelete("Players/{spielerid}")]
        public ActionResult DeletePlayer(int spielerid)
        {
            Console.WriteLine($"Deleting Player with the ID: {spielerid}...");

            Spieler selectedPlayer = context.Spieler.Where(p =>p.SId == spielerid).FirstOrDefault();
            
            

            if (selectedPlayer == null )
            {
                return NotFound();
            }
            else
            {
              

                context.Spieler.Remove(selectedPlayer);
                context.SaveChanges();

                return Ok();



            }
        }



        

        [HttpDelete("Coaches/{coachid}")]
        public ActionResult DeleteCoach(int coachid)
        {
            Console.WriteLine($"Deleting Coach with the ID: {coachid}...");


            Coach selectedCoach = context.Coach.Where(l => l.CId == coachid).FirstOrDefault();
          
            if (selectedCoach == null)
            {
                return NotFound();
            }
            else
            {
                Team team = context.Team.Where(k => k.TId == selectedCoach.TId).FirstOrDefault();

                if (team != null)
                {
                    context.Coach.Remove(selectedCoach);
                    context.SaveChanges();

                    return Ok();
                }
                else
                    return NotFound();
            }






        }


       



        [HttpDelete("Stadiums/{stadiumid}")]
        public ActionResult DeleteStadium(int stadiumid)
        {
            Console.WriteLine($"Deleting Stadium with the ID: {stadiumid}...");

            Stadion selectedStadium = context.Stadion.Where(l => l.StId == stadiumid).FirstOrDefault();
            


            if (selectedStadium == null)
            {
                return NotFound();
            }
            else
            {
                Team team = context.Team.Where(k => k.TId == selectedStadium.TId).FirstOrDefault();

                if (team != null)
                {
                    context.Stadion.Remove(selectedStadium);
                    context.SaveChanges();

                    return Ok();
                }
                else
                    return NotFound();
            }

        }

        [HttpDelete("Referees/{refereeid}")]
        public ActionResult DeleteReferee(int refereeid)
        {
            Console.WriteLine($"Deleting Referee with the ID: {refereeid}...");
            Schiedsrichter selectedReferee = context.Schiedsrichter.Where(l => l.SchId == refereeid).FirstOrDefault();



            if (selectedReferee == null)
            {

                return NotFound();

            }
            else
            {
               

                context.Schiedsrichter.Remove(selectedReferee);
                context.SaveChanges();


                return Ok();

            }

        }

        [HttpDelete("Matches/{matchid}")]
        public ActionResult DeleteMatch(int matchid)
        {
            Console.WriteLine($"Deleting Match with the ID: {matchid}...");
            Match match = context.Match.Where(l => l.MId == matchid).FirstOrDefault();



            if (match == null)
            {

                return NotFound();

            }
            else
            {
               

                context.Match.Remove(match);
                context.SaveChanges();



                return  Ok();

            }

        }


        //----------------------------------------------------------PATCH-ROUTES---------------------------------------------------------------------------------------------------------------------


        [HttpPatch("Players/{playerId}")]
        public ActionResult UpdatePlayer(int playerId, [FromBody] Spieler player)
        {
            Console.WriteLine($"Updating player with the ID: {playerId} ... ");




            Spieler p = context.Spieler.Where(l => l.SId == playerId).FirstOrDefault(); 

                if (p != null)
                {

                
                p.Uebernehmen = player.Uebernehmen;
                p.Nachname = player.Nachname;
                p.Vorname = player.Vorname;
                p.Alter = player.Alter; 
                p.Preis = player.Preis;
                p.Trikotnummer = player.Trikotnummer;
                p.Kapitaen = player.Kapitaen;
                p.TId = player.TId;


                context.SaveChanges();


                return Ok();
                }
                else
                    return NotFound();
            
         
        }


        [HttpPatch("Coaches/{coachId}")]
        public ActionResult UpdateCoach(int coachId, [FromBody] Coach coach)
        {
            Console.WriteLine($"Updating coach with the ID: {coachId} ... ");




            Coach c = context.Coach.Where(l => l.CId == coachId).FirstOrDefault();
           


            if (c != null)
            {
                
                c.Nachname = coach.Nachname;
                c.Vorname = coach.Vorname;
                c.Herkunft = coach.Herkunft;
                c.TId = coach.TId;



                context.SaveChanges();

                return Ok();
            }
            else
                return NotFound();


        }

        [HttpPatch("Teams/{teamid}")]
        public ActionResult UpdateTeam(int teamid, [FromBody] Team t)
        {
            Console.WriteLine($"Updating Team with the ID: {teamid} ... ");




            Team team = context.Team.Where(l => l.TId == teamid).FirstOrDefault();

            if (team != null)
            {
                team.Name = t.Name;
                team.Land = t.Land;
                team.Liga = t.Liga;
                context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();



        }


        [HttpPatch("Stadiums/{stadid}")]
        public ActionResult UpdateStadium(int stadid, [FromBody] Stadion stadium)
        {
            Console.WriteLine($"Updating Stadium with the ID: {stadid} ... ");




            Stadion s = context.Stadion.Where(l => l.StId == stadid).FirstOrDefault();
           
            if (s != null)
            {

                s.Kapazitaet = stadium.Kapazitaet;
                s.Name = stadium.Name;
                s.TId = stadium.TId;

                context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();


        }

        [HttpPatch("Referees/{refid}")]
        public ActionResult UpdateStadium(int refid, [FromBody] Schiedsrichter sch)
        {
            Console.WriteLine($"Updating Stadium with the ID: {refid} ... ");




            Schiedsrichter s = context.Schiedsrichter.Where(l => l.SchId == refid).FirstOrDefault();


            if (s != null)
            {
            
                s.Herkunft = sch.Herkunft;
                s.Nachname = sch.Nachname;
                s.Aggressivitaet = sch.Aggressivitaet;
                s.Vorname = sch.Vorname;

                context.SaveChanges();

                return Ok();
            }
            else
                return NotFound();


        }

        [HttpPatch("Matches/{matchid}")]
        public ActionResult UpdateMatch(int matchid, [FromBody] Match m)
        {
            Console.WriteLine($"Updating Match with the ID: {matchid} ... ");




            Match match = context.Match.Where(l => l.MId == matchid).FirstOrDefault();


            if (match != null)
            {
           
                match.Art=m.Art;
               

                context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();


        }


        //----------------------------------------------------------POST-ROUTES---------------------------------------------------------------------------------------------------------------------
        [HttpPost("Teams")]
        public ActionResult<Team> AddTeam([FromBody] Team team)
        {
            Console.WriteLine("Adding a new Team...");
            
            context.Team.Add(team);
            context.SaveChanges();
            return Ok(team);
        }

        [HttpPost("Players")]
        public ActionResult<Spieler> AddPlayer([FromBody] Spieler spieler)
        {
            Console.WriteLine("Adding a new Player...");
            
            context.Spieler.Add(spieler);
            context.SaveChanges();
            return Ok(spieler);
        }

        [HttpPost("Teams/{Teamid}(Players")]
        public ActionResult<Spieler> AddPlayer(int teamid,[FromBody] Spieler spieler)
        {
            Team team = context.Team.Where(l => l.TId == teamid).FirstOrDefault();
            Console.WriteLine($"Adding a new Player to the Team with the ID:{teamid}...");

            team.Spieler.Add(spieler);
            context.SaveChanges();
            return Ok(spieler);
        }

        [HttpPost("Stadiums")]
        public ActionResult<Stadion> AddStadium([FromBody] Stadion stadium)
        {
            Console.WriteLine("Adding a new Stadium...");
           
            context.Stadion.Add(stadium);
            context.SaveChanges();
            return Ok(stadium);
        }

        [HttpPost("Coaches")]
        public ActionResult<Coach> AddStadium([FromBody] Coach coach)
        {
            Console.WriteLine("Adding a new Coach...");
            
            context.Coach.Add(coach);
            context.SaveChanges();
            return Ok(coach);
        }

        [HttpPost("Referees")]
        public ActionResult<Schiedsrichter> AddReferee([FromBody] Schiedsrichter schiedsrichter)
        {
            Console.WriteLine("Adding a new Referee...");
            
            context.Schiedsrichter.Add(schiedsrichter);
            context.SaveChanges();
            return Ok(schiedsrichter);
        }

        [HttpPost("Matches")]
        public ActionResult<Match> AddMatch([FromBody] Match m)
        {
            Console.WriteLine("Adding a new Match...");
          
            context.Match.Add(m);
            context.SaveChanges();
            return Ok(m);
        }











    }
}
