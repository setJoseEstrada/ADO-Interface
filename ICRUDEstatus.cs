using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduccion_a_ADO
{
    public interface ICRUDEstatus
    {

        List<Estatus> ConsultarTodo();

        Estatus Consultar(int id);
        int Agregar(Estatus estatus);
        
        
        void Actualizar(Estatus estatus);
       

        void Eliminar(int id);
        
    }
}
