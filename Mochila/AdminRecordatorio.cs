using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class AdminRecordatorio
    {
    }
}


/*
Public Sub GuardarRecordatorio(quéRecordatorio As Recordatorio)
    Dim archivolibre As Byte, contador As Integer, auxRecordatorio As Recordatorio, j As Byte

    On Error GoTo manejoError
    archivolibre = FreeFile 'se abre el archivo para guardar los datos de las partidas
    Open App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)) + "\" + Trim(Str(Int(Mid(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4, 2)))) + "\recordatorios.gui" For Random As archivolibre Len = Len(quéRecordatorio)
    contador = 0
    While Not EOF(archivolibre)
        contador = contador + 1
        Get archivolibre, contador, auxRecordatorio
    Wend
    quéRecordatorio.índiceEnArchivo = contador
    Put archivolibre, contador, quéRecordatorio
    Close archivolibre
    Exit Sub
manejoError:
    If Err.Number = 76 Then
        MkDir (App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)))
        For j = 1 To 12
            MkDir (App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)) + "\" + Trim(Str(j)))
        Next
        Resume Next
    End If
End Sub

Public Sub GuardarRecordatorioEnPosición(quéRecordatorio As Recordatorio, posición As Long)
    Dim archivolibre As Byte, auxRecordatorio As Recordatorio, j As Byte

    On Error GoTo manejoError
    archivolibre = FreeFile 'se abre el archivo para guardar los datos de las partidas
    Open App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)) + "\" + Trim(Str(Int(Mid(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4, 2)))) + "\recordatorios.gui" For Random As archivolibre Len = Len(quéRecordatorio)
    quéRecordatorio.índiceEnArchivo = posición
    Put archivolibre, posición, quéRecordatorio
    Close archivolibre
    Exit Sub
manejoError:
    If Err.Number = 76 Then
        MkDir (App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)))
        For j = 1 To 12
            MkDir (App.path + "\recordatorios\" + Trim(Right(Format(quéRecordatorio.fecha, "dd/mm/yyyy"), 4)) + "\" + Trim(Str(j)))
        Next
        Resume Next
    End If
End Sub



Public Sub cargarRecordatorios()
    Dim archivolibre As Byte, miRec As Recordatorio, mes As Byte, año As Integer ', día As Byte
    Dim contador As Integer, i As Integer
    On Error GoTo manejoError
    mes = Month(Date)
    año = Year(Date)
    archivolibre = FreeFile
    contador = 1 'se deja en blanco el primer recordatorioActivo. Si hay más de uno, es que hay recordatorios activos. Se evalúa en frmOculto
    Open App.path + "\recordatorios\" + Trim(Str(año)) + "\" + Trim(Str(mes)) + "\" + "recordatorios.gui" For Random As #archivolibre Len = Len(miRec)
    Do While Not EOF(archivolibre)   ' Repite hasta el final del archivo.
       Get #archivolibre, , miRec   ' Lee el registro siguiente.
       If Asc(Left(miRec.texto, 1)) <> 0 Then
            If miRec.yaAnunciado = False Then 'si no fue anunciado
                If Format(miRec.fecha, "dd/mm/yyyy") = Format(Date, "dd/mm/yyyy") Then 'si el recordatorio es de hoy
                    If Left(Format(miRec.hora, "HH:mm"), 2) <= Left(Format(Time, "HH:mm"), 2) Then 'si la hora es la actual o menor
                        'se controla que los minutos sean iguales o menores a los actuales
                        If Right(Format(miRec.hora, "HH:mm"), 2) <= Right(Format(Time, "HH:mm"), 2) Then
                            ReDim Preserve recordatoriosActivos(0 To contador)
                            recordatoriosActivos(contador) = miRec
                            contador = contador + 1
                        End If
                    End If
                Else
                    If Right(Format(miRec.fecha, "dd/mm/yyyy"), 4) < Right(Format(Date, "dd/mm/yyyy"), 4) Then   'si el año es menor al actual
                        ReDim Preserve recordatoriosActivos(0 To contador)
                        recordatoriosActivos(contador) = miRec
                        contador = contador + 1
                    Else
                        If Right(Format(miRec.fecha, "dd/mm/yyyy"), 4) = Right(Format(Date, "dd/mm/yyyy"), 4) Then  'si el año es igual al actual
                            If Mid(Format(miRec.fecha, "dd/mm/yyyy"), 4, 2) < Mid(Format(Date, "dd/mm/yyyy"), 4, 2) Then 'si el mes es menor al actual
                                ReDim Preserve recordatoriosActivos(0 To contador)
                                recordatoriosActivos(contador) = miRec
                                contador = contador + 1
                            Else
                                If Mid(Format(miRec.fecha, "dd/mm/yyyy"), 4, 2) = Mid(Format(Date, "dd/mm/yyyy"), 4, 2) Then 'si el mes es igual al actual
                                    If Left(Format(miRec.fecha, "dd/mm/yyyy"), 2) < Left(Format(Date, "dd/mm/yyyy"), 2) Then 'si el día es anterior al actual
                                        ReDim Preserve recordatoriosActivos(0 To contador)
                                        recordatoriosActivos(contador) = miRec
                                        contador = contador + 1
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    Loop
    Close #archivolibre
    Exit Sub
manejoError:
    Exit Sub
End Sub



*/