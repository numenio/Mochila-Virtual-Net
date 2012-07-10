using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class Libro
    {
    }
}



/*
Public Function guardarOrdenCapítulosDesdeMatriz(materia As String, libro As String, ParamArray listaCapítulos()) As Boolean
    Dim capítulo As Variant, auxMatriz() As String, i As Integer, contador As Integer, archivolibre As Byte
    On Error GoTo error
    archivolibre = FreeFile
    Open App.path + "\trabajos\" + materia + "\libros\" + libro + "\ordenCapítulos" For Output As #archivolibre
    contador = 0
    For Each capítulo In listaCapítulos
        For i = 0 To UBound(capítulo)
            ReDim Preserve auxMatriz(0 To contador)
            auxMatriz(contador) = capítulo(contador)
            contador = contador + 1
        Next
    Next capítulo
    
    For i = 0 To UBound(auxMatriz)
        Print #archivolibre, auxMatriz(i)
    Next i
    
    Close #archivolibre
    
    guardarOrdenCapítulosDesdeMatriz = True
    Exit Function
error:
    guardarOrdenCapítulosDesdeMatriz = False
End Function


Public Sub guardarOrdenCapítulosLibro(listaCapítulos As ListBox, materia As String, libro As String)
    Dim i As Integer
    Open App.path + "\trabajos\" + materia + "\libros\" + libro + "\ordenCapítulos" For Output As #1
    listaCapítulos.Refresh
    For i = 0 To listaCapítulos.ListCount - 1
        Print #1, listaCapítulos.List(i)
    Next
    Close #1
End Sub



*/