using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class AdminPrograma
    {
    }
}


/*
Public Function SalirDelPrograma() As Boolean
    frmMsgBox.swMostrarCancelar = False
    frmMsgBox.cadenaAMostrar = "¿Realmente querés salir del programa?"
    frmMsgBox.swSíNoóAceptar = True 'se elige que sea cuadro sí-no
    frmMsgBox.Show 1
    If frmMsgBox.swResultadoMostrado = True Then
        SalirDelPrograma = True
    Else
        SalirDelPrograma = False
    End If
End Function

Public Sub chauPrograma()
    On Error Resume Next
    sonido = sndPlaySound(App.path + "\sonidos\fin.wav", SND_SYNC)
    Unload frmOculto
    Set Voz = Nothing
    Set vozSapi4 = Nothing
    If swCuadernoAbierto = True Then Unload frmCuaderno 'si está abierto el cuaderno se lo cierra
    If swLibroAbierto = True Then Unload frmLectorLibro 'si está abierto el lector de libros, se lo cierra
    If swActividadAbierta = True Then Unload frmLectorActividad 'si está abierto el lector de actividad, se lo cierra
    If frmReproductorMúsica.swEstoyAbierto = True Then Unload frmReproductorMúsica
    If objPipe.Running = True Then
        Call objPipe.Terminate
    End If
    KillProcess ("cmd.exe")
    KillProcess ("aspell.exe")
    Set objPipe = Nothing
    End
End Sub



'
'Public Sub instalar()
'    Dim versiónOS As String
'    versiónOS = obtenerVersiónWindows
'
'    Select Case versiónOS
'        Case "windows 95"
'            'call ejecutar (App.Path + "\Ejecutables\instalador98.exe")
'            MsgBox "Acá va el instalador del win 95 del programa porque es la primera vez que se abre"
'        Case "windows 98"
'            'call ejecutar ( App.Path + "\Ejecutables\instalador98.exe")
'            MsgBox "Acá va el instalador del win 98 del programa porque es la primera vez que se abre"
'        Case "windows millennium"
'            MsgBox "Acá va el instalador del millenium del programa porque es la primera vez que se abre"
'        Case "windows nt 3.51"
'            MsgBox "Acá va el instalador del win 3.51 del programa porque es la primera vez que se abre"
'        Case "windows nt 4.0"
'            MsgBox "Acá va el instalador del win nt del programa porque es la primera vez que se abre"
'        Case "windows 2000"
'            MsgBox "Acá va el instalador del win 2000 del programa porque es la primera vez que se abre"
'        Case "windows xp"
'            MsgBox "Acá va el instalador del xp del programa porque es la primera vez que se abre"
'        Case "falló"
'    End Select

Public Sub crearCarpetasPrograma()
    Dim j As Byte, archivolibre As Byte, cadena As String
    
    On Error GoTo manejoError
    archivolibre = FreeFile 'se abren las materias
    Open App.path + "\datos\materias.txt" For Input As archivolibre
    
    MkDir (App.path + "\trabajos")
    MkDir (App.path + "\Comunicaciones")
    MkDir (App.path + "\Recordatorios")
    MkDir (App.path + "\Recordatorios\" + Trim(Str(Year(Date))))
    For j = 1 To 12
        MkDir (App.path + "\Recordatorios\" + Trim(Str(Year(Date))) + "\" + Trim(Str(j)))
    Next
    For j = 1 To 12
        MkDir (App.path + "\Datos\" + Trim(Str(j)))
    Next
    While Not EOF(archivolibre)
        Line Input #archivolibre, cadena
        MkDir (App.path + "\trabajos\" + cadena) 'se crean las carpetas de cada materia
        For j = 1 To 12
            MkDir (App.path + "\trabajos\" + cadena + "\" + Trim(Str(j)))
            MkDir (App.path + "\trabajos\" + cadena + "\" + Trim(Str(j)) + "\datosHojas")
        Next
        MkDir (App.path + "\trabajos\" + cadena + "\actividades")
        MkDir (App.path + "\trabajos\" + cadena + "\soporte")
        MkDir (App.path + "\trabajos\" + cadena + "\evaluaciones") 'carpeta para poner evaluaciones falsas por si los papás quieren modificar una evaluación ya hecha ];)
        For j = 1 To 12
            MkDir (App.path + "\trabajos\" + cadena + "\actividades\" + Trim(Str(j)))
            MkDir (App.path + "\trabajos\" + cadena + "\actividades\" + Trim(Str(j)) + "\datosActividades")
            MkDir (App.path + "\trabajos\" + cadena + "\soporte\" + Trim(Str(j)))
            MkDir (App.path + "\trabajos\" + cadena + "\soporte\" + Trim(Str(j)) + "\datosSoporte")
            MkDir (App.path + "\trabajos\" + cadena + "\evaluaciones\" + Trim(Str(j)))
        Next
        MkDir (App.path + "\trabajos\" + cadena + "\libros")
    Wend
    Close #archivolibre
    
'    Dim lectorRegistro, x
'    Set lectorRegistro = CreateObject("WScript.Shell")
'    lectorRegistro.RegWrite "HKEY_LOCAL_MACHINE\Software\ReyNegro-ReyBlanco\MochilaVirtual\", "1"
'    lectorRegistro.RegWrite "HKEY_LOCAL_MACHINE\Software\ReyNegro-ReyBlanco\MochilaVirtual\datos\", "0"
'    Set lectorRegistro = Nothing
manejoError:
    Resume Next
End Sub


*/