using System;


namespace corta_e_tchau_backend.Model
{
    public class Scheduling : EntityBase
    {
        public DateTime date_time { get; set; }
        public String description { get; set; }
        public int user_id { get; set; }
        public String status { get; set; }
        public User user { get; set; }
    }
}
