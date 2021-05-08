using System.ComponentModel.DataAnnotations.Schema;

namespace corta_e_tchau_backend.Model
{
    public abstract class EntityBase
    {
        [Column("id")]
        public int id { get; set; }
    }
}
