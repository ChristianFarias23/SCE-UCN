

namespace SCEUCN_WEB.Model
{
    public enum Contrato { Oficial, Fijo, Temporal }

    public class Persona
    {
        public string Rut { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email{ get; set;}

        public string Movil{ get; set;}

        public string Unidad{ get; set;}

        public string Oficina{ get; set;}

        public string Anexo{ get; set;}

        //public Rol Rol{ get; set;}

        public Contrato Contrato{ get; set;}
    }
}