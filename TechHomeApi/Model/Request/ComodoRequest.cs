namespace TechHomeApi.Model.Request
{
    public class ComodoRequest
    {
        public string Name { get; set; }
    }
    public class ComodoPostRequest
    {
        public int id_casa { get; set; }
        public required string name { get; set; }
    }
}
