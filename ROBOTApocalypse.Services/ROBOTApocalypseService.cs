using ROBOTApocalypse.DB;
using ROBOTApocalypse.Entity;
using ROBOTApocalypse.Entity.ViewModel;
using ROBOTApocalypse.IServices;

namespace ROBOTApocalypse.Services
{
    public class ROBOTApocalypseService : IROBOTApocalypseService
    {
        private readonly ROBOTApocalypseDBContext rOBOTApocalypseDBContext = null;
        public ROBOTApocalypseService(ROBOTApocalypseDBContext _ROBOTApocalypseDBContext)
        {
            this.rOBOTApocalypseDBContext = _ROBOTApocalypseDBContext;
        }
        public SurvivorsViewModel SaveSurvivors(SurvivorsViewModel survivorsViewModel)
        {
            var Survivors = new Survivors()
            {
                Age = survivorsViewModel.Survivors.Age,
                Ammunition = survivorsViewModel.Survivors.Ammunition,
                Flag = survivorsViewModel.Survivors.Flag,
                Food = survivorsViewModel.Survivors.Food,
                Gender = survivorsViewModel.Survivors.Gender,
                Medication = survivorsViewModel.Survivors.Medication,
                Name = survivorsViewModel.Survivors.Name,
                Water = survivorsViewModel.Survivors.Water
            };

            this.rOBOTApocalypseDBContext.Survivors.Add(Survivors);
            this.rOBOTApocalypseDBContext.SaveChanges();
            survivorsViewModel.Survivors = Survivors;

            if(Survivors.Id > 0)
            {
                survivorsViewModel.SurvivorLocation.SurvivorId = Survivors.Id;
                survivorsViewModel.SurvivorLocation =  this.UpdateSurvivorsLocation(survivorsViewModel.SurvivorLocation);
            }

            return survivorsViewModel;
        }


        public SurvivorLocation UpdateSurvivorsLocation(SurvivorLocation survivorLocation)
        {
            if (this.rOBOTApocalypseDBContext.SurvivorLocation.Any(x => x.SurvivorId == survivorLocation.SurvivorId))
            {
                var sLocation = this.rOBOTApocalypseDBContext.SurvivorLocation.FirstOrDefault(x => x.SurvivorId == survivorLocation.SurvivorId);
                sLocation.Latitude = survivorLocation.Latitude;
                sLocation.Longitude = survivorLocation.Longitude;
                survivorLocation = sLocation;
            }
            else
            {
                survivorLocation.Id = null;
                this.rOBOTApocalypseDBContext.SurvivorLocation.Add(survivorLocation);
            }

            this.rOBOTApocalypseDBContext.SaveChanges();
            return survivorLocation;
        }
        public Survivors UpdateSurvivorsStatus(Survivors survivors)
        {
            if (survivors != null && survivors.Id > 0 && this.rOBOTApocalypseDBContext.Survivors.Any(x => x.Id == survivors.Id))
            {
                var survivorsStatus = this.rOBOTApocalypseDBContext.Survivors.FirstOrDefault(x => x.Id == survivors.Id);
                survivorsStatus.Flag = survivors.Flag;
                this.rOBOTApocalypseDBContext.Survivors.Update(survivorsStatus);
                this.rOBOTApocalypseDBContext.SaveChanges();
                survivors = survivorsStatus;
            }
            return survivors;
        }
        public List<Survivors> GetSurvivors()
        {
            return this.rOBOTApocalypseDBContext.Survivors.ToList();
        }
    }
}
