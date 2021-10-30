namespace Cigarette.Enterprise.ViewModels 
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool Added { get; set; }
        public bool Failed { get; set; }
        public string CustomProperties { get; set; }
    }
}