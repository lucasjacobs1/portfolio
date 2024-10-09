using LogicLayer.Models.Enums;

namespace LogicLayer.Models
{
    public class AppointmentLink
    {
        //ToDo: When deploying the website change the hostAddress to the server address
        private readonly string hostAddress = "http://localhost:3000/";
        public AppointmentLink(string usernameHashed,string identifierHashed, LinkStatus linkStatus)
        {
            this.UsernameHashed = usernameHashed;
            this.IdentifierHashed = identifierHashed;
            this.LinkStatus = linkStatus;
        }

        public AppointmentLink(int id,string usernameHashed, string identifierHashed, LinkStatus linkStatus)
            : this(usernameHashed,identifierHashed,linkStatus)
        {
            this.id = id;
        }

        public int id { get; private set; }

        public string link { 
            get {
                return hostAddress + "appointment/create/" + UsernameHashed + "/" + IdentifierHashed;
            }
        }
        public LinkStatus LinkStatus { get; set; }
        public string UsernameHashed { get; private set; }
        public string IdentifierHashed { get; private set; }

        
    }
}
