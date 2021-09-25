using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTOs
{
    //misma estructura de nuestra entidad de negocio que queremos emular
    //los Dtos NO DEBEN DE TENER LOGICA EN ELLOS... SOLO SIRVEN PARA TRASMIUTIR INFORMACION
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }
}
