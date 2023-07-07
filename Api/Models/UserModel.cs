namespace Api.Models
{
    public class Users
    {
        public int followers { get; set; }

        public string name { get; set; }

        public string login { get; set; }

        public string company { get; set; }
        public int public_repos { get; set; }

        public float? AverageFollower
        {
            get
            {
                if (public_repos >= 1)
                {
                    return (float)Math.Round((float)followers / public_repos);
                }
                return null;
            }
        }
    }
}