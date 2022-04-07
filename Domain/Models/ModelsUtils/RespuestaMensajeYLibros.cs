using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ModelsUtils
{
    public class RespuestaMensajeYLibros
    {
        public string? Mensaje { get; set; }
        public List<Libro>? libros { get; set; }
    }
}
