using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class AdminMaterias
    {
    }
}



/*
Public Sub guardarMaterias(listaMaterias As ListBox)
    Dim i As Integer
    Open App.path + "\datos\materias.txt" For Output As #1 'se abre el trabajo ya guardado
    listaMaterias.Refresh
    For i = 0 To listaMaterias.ListCount - 1
        Print #1, listaMaterias.List(i)
    Next
    Close #1
End Sub


Public Sub guardarHistorial(listaMaterias As ListBox)
    Dim swArchivoRepetido As Boolean, nextline As String, i As Integer
    
    On Error GoTo manejoError
    'se guardan las materias en el historial
    For i = 0 To listaMaterias.ListCount - 1 'se chequea que cada materia no esté ya guardada
        Open App.path + "\datos\historialMaterias.txt" For Input As #1 'se abre el trabajo ya guardado para leerlo
        Do While Not EOF(1) 'chequeamos que no esté en la lista ya el registro del archivo a guardar
            Line Input #1, nextline
            If nextline = listaMaterias.List(i) Then
                swArchivoRepetido = True
                Exit Do
            End If
        Loop
        Close #1
        
        If swArchivoRepetido = False Then
            Open App.path + "\datos\historialMaterias.txt" For Append As #1 'se abre el historial para añadir las materias
            Print #1, listaMaterias.List(i)
            swArchivoRepetido = False
            Close #1
        End If
        
        swArchivoRepetido = False
    Next
    Exit Sub
    
manejoError:
    Open App.path + "\datos\historialMaterias.txt" For Output As #1
    Close #1
    Resume
End Sub



Public Sub llenarComboMaterias(Combo As ComboBox)
    Dim archivolibre As Byte, cadena As String
    On Error GoTo manejoError
    archivolibre = FreeFile 'se abren las materias
    Open App.path + "\datos\materias.txt" For Input As archivolibre
    While Not EOF(archivolibre)
        Line Input #archivolibre, cadena
        Combo.AddItem Trim(cadena) 'se añaden las materias al combo
    Wend
    Close #archivolibre
    Exit Sub
manejoError:
    If Err.Number = 52 Then
        Open App.path + "\datos\materias.txt" For Output As #archivolibre 'se abre el trabajo ya guardado
        Close #archivolibre
        Resume
    End If
    
    If Err.Number = 429 Then
'        MsgBox "soy el controlador de la función llenarComboMaterias", , "Para mi creador"
        frmMsgBox.cadenaAMostrar = "Soy el controlador de la función llenarComboMaterias"
        frmMsgBox.swSíNoóAceptar = False 'se elige que sea cuadro aceptar
        frmMsgBox.Show 1
    End If
End Sub



*/