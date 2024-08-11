namespace BussinessLogic.Models
{
    public class EmailData
    {
        public string From { get; set; }

        public string? To { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string Password { get; set; }

        public EmailData()
        {
            From = "so9469306@gmail.com";
            Password = "lnzr sihx tfai irnw";
            //Password = "ShopOnline123456@";
        }
    }
}
