namespace HotelProject.WebUI.Dtos.FollewersDto
{
    public class ResultInstagramFollowersDto
    {


        public Edge_Followed_By edge_followed_by { get; set; }
        public Edge_Follow edge_follow { get; set; }


        public class Edge_Followed_By
        {
            public int count { get; set; }
        }

        public class Edge_Follow
        {
            public int count { get; set; }
        }



    }
}
