namespace HotelProject.WebUI.Dtos.FollewersDto
{
    public class ResultLinkedInFollowersDto
    {
        public class Rootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {         
            public int connections_count { get; set; }
            public int followers_count { get; set; }        
        }

      

    }
}
