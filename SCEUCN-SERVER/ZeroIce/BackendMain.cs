using System;
using System.Collections.Generic;
using CL.UCN.DISC.PDIS.SCE.Server.Controller;
using CL.UCN.DISC.PDIS.SCE.Server.ZeroIce.Model;
using Ice;
using Microsoft.Extensions.Logging;

namespace CL.UCN.DISC.PDIS.SCE.Server.ZeroIce.Controller {

    /// <summary>
    /// Implementacion concreta.
    /// </summary>
    public class BackendMain : IBackendMainDisp_ {

        /// <summary>
        /// The Logger.
        /// </summary>
        private readonly ILogger<BackendMain> _logger;

        /// <summary>
        /// The Main Controller.
        /// </summary>
        private readonly IMainController _mainController;

        /// <summary>
        /// The Constructor.
        /// </summary>
        public BackendMain(ILogger<BackendMain> logger, IMainController mainController) {
            _logger = logger;
            _mainController = mainController;
        }

        public override List<Vehiculo> obtenerVehiculos(Current current = null) {
            return _mainController.GetVehiculos();
        }

        public override void registrarIngreso(string placa, Porteria porteria, Current current = null) {

            // 1.- Verificar si el vehiculo se encuentra registrado.
            Vehiculo vehiculoRegistro = _mainController.GetVehiculo(placa);

            if (vehiculoRegistro == null) {
                _logger.LogCritical(LE.Find, "Error: El vehiculo Placa [{placa}] no existe en el backend.", placa);
                return;
            }

            // 2.- Intentar parsear la porteria.

            // 3.- Crear la fecha del registro.
            string fechaRegistro = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

            // 4.- Crear el registro.
            Registro nuevoRegistro = new Registro {
                vehiculo = vehiculoRegistro,
                porteria = porteria,
                fecha = fechaRegistro
            };

            // 5.- Guardar el registro.
            _mainController.Save(nuevoRegistro);

            _logger.LogInformation(LE.Save, "Ok: Se ha guardado el registro [Placa: {0}, Porteria: {1}, Fecha: {2}]", nuevoRegistro.vehiculo.placa, nuevoRegistro.porteria, nuevoRegistro.fecha);
        }

        public override void registrarIngresoOffline(string placa, Porteria porteria, string fecha, Current current = null) {
            throw new NotImplementedException();
        }

        /* 
        public override List<Vehiculo> obtenerVehiculos(Current current = null) {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            foreach (var vehiculo in _mainController.GetVehiculos()) {
                vehiculos.Add(ModelConverter.Convert(vehiculo));
            }
            return vehiculos;
        }

        public override void registrarIngreso(string placa, Porteria porteria, Current current = null) {
            // 1.- Verificar si el vehiculo se encuentra registrado.
            Model.Vehiculo vehiculoRegistro = _mainController.GetVehiculo(placa);

            if (vehiculoRegistro == null) {
                _logger.LogCritical(LE.Find, "Error: El vehiculo Placa [{placa}] no existe en el backend.", placa);
                return;
            }

            // 2.- Intentar parsear la porteria.
            Model.Porteria porteriaRegistro;

            try {
                // OLD: 
                // porteriaRegistro = (Model.Porteria) Enum.Parse(typeof(Model.Porteria), porteria.ToString());

                // NEW:
                porteriaRegistro = ModelConverter.Parse<Model.Porteria>(porteria.ToString());

            } catch (System.Exception) {
                _logger.LogCritical(LE.Converter, "Error: La porteria especificada [{0}] no es valida!", porteria);
                return;
            }

            // 3.- Crear la fecha del registro.
            string fechaRegistro = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

            // 4.- Crear el registro.
            Model.Registro nuevoRegistro = new Model.Registro {
                Vehiculo = vehiculoRegistro,
                Porteria = porteriaRegistro,
                Fecha = fechaRegistro
            };

            // 5.- Guardar el registro.
            _mainController.Save(nuevoRegistro);

            _logger.LogInformation(LE.Save, "Ok: Se ha guardado el registro [Placa: {0}, Porteria: {1}, Fecha: {2}]", nuevoRegistro.Vehiculo.Placa, nuevoRegistro.Porteria, nuevoRegistro.Fecha);

        }

        public override void registrarIngresoOffline(string placa, Porteria porteria, string fecha, Current current = null) {
            throw new NotImplementedException();
        }

        */
    }

}