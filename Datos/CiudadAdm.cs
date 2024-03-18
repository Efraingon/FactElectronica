using FactElectronica.Models;

namespace FactElectronica.Datos
{
    public class CiudadAdm
    {
        /// <summary>
        /// Consulta Todas las ciudades
        /// </summary>
        /// <returns>Listado de Ciudades</returns>
        public IEnumerable<Ciudad> Consultar() {
            using (FacturaAppContext contexto = new FacturaAppContext()) {
                return contexto.Ciudades.ToList(); 
            }
        }
        /// <summary>
        /// Guardar Cuidad
        /// </summary>
        /// <param name="modelo"></param>
        public void Guardar (Ciudad modelo){
            using (FacturaAppContext contexto = new FacturaAppContext())
            {
              contexto.Ciudades.Add(modelo);
                contexto.SaveChanges();  
            }
        }
    }
}
