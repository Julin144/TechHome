using TechHomeApi.Model.Entity;

namespace TechHomeApi.Model.Response
{
    public class CasaResponse
    {
        public string status { get; set; }

        public List<CasaEntity> casaEntities { get; set; }
    }
}
