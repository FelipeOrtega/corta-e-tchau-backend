using System;


namespace corta_e_tchau_backend.Model
{
    public class SchedulingGetDTO : EntityBase
    {

        public SchedulingGetDTO(String data, String hora, String description, String status, User user)
        {
            this.data = data;
            this.hora = hora;
            this.description = description;
            this.status = status;
            this.user = user;
        }

        public String data { get; set; }
        public String hora { get; set; }
        public String description { get; set; }
        public String status { get; set; }
        public User user { get; set; }
    }
}
