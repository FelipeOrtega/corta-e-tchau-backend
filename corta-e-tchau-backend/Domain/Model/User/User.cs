using System;

namespace corta_e_tchau_backend.Model
{
    public class User : EntityBase
    {
    public String identification_document { get; set; }
    public String username { get; set; }
    public String password { get; set; }
    public String role { get; set; }
    }
}
