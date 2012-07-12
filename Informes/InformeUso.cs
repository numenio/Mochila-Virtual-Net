using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class InformeUso
    {
        enum tipoInforme {uso, error}
        enum usoCalculadora { correcto, error }

        tipoInforme tipoDeInforme;
        DateTime fecha;
        Exception exepción;
        int cantActividades;
        int cantActividadesAbiertas;
        int cantLibros;
        int cantCapítulos;
        int cantCapítulosLeídos;
        usoCalculadora usoCalculadora; //cada vez que se usa, para ver si se
    }
}
