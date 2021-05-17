using System;
using System.Collections.Generic;

namespace corta_e_tchau_backend.Model
{
    public class User : EntityBase
    {
    public String phone { get; set; }
    public String name { get; set; }
    public String password { get; set; }
    public String role { get; set; }
    public List<Scheduling> schedulings { get; set; }
    }
}
