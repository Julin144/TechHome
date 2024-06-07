namespace TechHomeApi.Model.Entity
{
    public class AparelhoEntity
    {
        public int id { get; set; }
        public string Nome { get; set; }

        public string status { get; set; }

        public DateTime Cronograma { get; set; }

        public float consumo { get; set; }

        public int id_comodo { get; set; }
    }
}
