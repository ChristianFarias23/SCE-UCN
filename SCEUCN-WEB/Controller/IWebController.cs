// (c) 2019 Proyecto Desarrollo e Integracion de Soluciones, I semestre 2019.

using System.Collections.Generic;
using CL.UCN.DISC.PDIS.SCE.Server.ZeroIce.Model;

// https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines
namespace CL.UCN.DISC.PDIS.SCE.Web.Controller {

    /// <summary>
    /// Declaracion de las operaciones del sistema.
    /// </summary>
    public interface IWebController {

        /// <summary>
        /// Obtiene un Vehiculo a partir de su placa patente.
        /// </summary>
        /// <returns>
        /// El Vehiculo asociado a la patente.
        /// </returns>
        Vehiculo GetVehiculo(string patente);

        /// <summary>
        /// Obtiene todos los Vehiculos presentes en el sistema.
        /// </summary>
        List<Vehiculo> GetVehiculos();


        /// <summary>
        /// Obtiene todos los Vehiculos presentes en el sistema.
        /// </summary>
        List<Persona> GetPersonas();


        void AddOrUpdateVehiculo(string rutPersona, string placa, string marca, Tipo tipo, string anio);


        List<Registro> GetRegistros();
    }

}