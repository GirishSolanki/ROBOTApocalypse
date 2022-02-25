using ROBOTApocalypse.Entity;
using ROBOTApocalypse.Entity.ViewModel;

namespace ROBOTApocalypse.IServices
{
    public interface IROBOTApocalypseService
    {
        SurvivorsViewModel SaveSurvivors(SurvivorsViewModel survivorsViewModel);
        SurvivorLocation UpdateSurvivorsLocation(SurvivorLocation survivorLocation);
        Survivors UpdateSurvivorsStatus(Survivors survivors);
        List<Survivors> GetSurvivors();
    }
}
