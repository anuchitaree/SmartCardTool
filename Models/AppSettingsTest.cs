namespace SmartCardTool.Models
{
    public class AppSettings
    {
        public Paths Path { get; set; }
    }

    public class Paths
    {
        public string DataPath { get; set; }

        public string UploadUrl { get; set; }


        public int HoldResultSec { get; set; }

    }

}
