using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class AdminUsuario
    {
    }
}



/*
Public Sub GuardarDatosUsuario()
    Dim archivolibre As Byte
    With usuario
        '.comenzarEnCarpeta = swEmpezarEnCuaderno
        .sapi5 = swSapi5 'si se usa sapi 5 o sapi 4
'        .permitirEditarActividades = swPermitirCambioEnActividades
        .usarVoz = swHablarVoz
        .mostrarTodasLasTareas = swMostrarAñoEnTareas
        .mostrarTodasLasActividades = swMostrarAñoEnActividades
        .nombre = nombreUsuario
        .usuarioMujer = swUsuarioMujer
        '.leerSignoPuntuación = swLeerSignosPuntuación
        .imprimirDirecto = swImprimirDirecto
        .colorFondo = colorFondo
        .fuenteColor = colorFuente
        .fuenteNombre = NombreFuente
        .fuenteTamaño = tamañoFuente
        .velocidadVoz = velocidadVoz
        .swLeerRenglones = swLeerRenglones
        .swUsarCorrectorOrtográfico = swUsarCorrectorOrtográfico
        .nombreVozSapi4 = nombreSapi4
        .nombreVozSapi5 = nombreSapi5
        '.swInstalarVoz = swInstalarVoz
        .swMúsicaDeFondo = swMúsicaDeFondo
        .swPermitirAbrirArchivos = swPermitirAbrirArchivos
    End With

    archivolibre = FreeFile 'se abre el archivo para guardar los datos de las partidas
    Open App.path + "\datos\datos.gui" For Random As archivolibre Len = Len(usuario)
'    contador = 0
'    While Not EOF(archivolibre)
'        contador = contador + 1
'        Get archivolibre, contador, auxErr
'    Wend
    Put archivolibre, 1, usuario
    Close archivolibre
End Sub
*/