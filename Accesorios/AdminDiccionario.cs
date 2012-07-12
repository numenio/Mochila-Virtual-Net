using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class AdminDiccionario
    {
    }
}

/*
Public Function buscarEntrada(quéCadena As String, diccionarioElegido As String) As String
    Dim cadenaDiccionario As String
    Dim palabraEncontrada As Boolean
    Dim archivolibre As Byte 'el manejador del diccionario
    Dim palabraNuevaLínea As String
    Dim posiciónDosPuntos As Integer
    
    If existeCarpeta(App.path + "\diccionarios\" + diccionarioElegido) Then
        'si existe el diccionario
        palabraEncontrada = False
        buscarEntrada = ""
        
        archivolibre = FreeFile
        Open App.path + "\diccionarios\" + diccionarioElegido For Input As archivolibre
        Do While Not EOF(archivolibre)   ' Repite el bucle hasta el final del archivo.
            Line Input #archivolibre, cadenaDiccionario ' Lee el carácter en dos variables.
            If palabraEncontrada = False Then 'se ve si la palabra está en el diccionario
                posiciónDosPuntos = InStr(1, cadenaDiccionario, ":") - 1
                If posiciónDosPuntos > 0 Then
                    If LCase(Trim(Left(cadenaDiccionario, posiciónDosPuntos))) = LCase(Trim(quéCadena)) Then
                    'esto sirve para buscar la coincidencia letra por letra de lo que se escribe -> 'If LCase(Trim(Left(cadenaDiccionario, Len(quéCadena)))) = LCase(Trim(quéCadena)) Then
                        buscarEntrada = cadenaDiccionario
                        palabraEncontrada = True
                    End If
                End If
            Else 'si se encontró la palabra, se ve si la definición sigue en el próximo renglón
                palabraNuevaLínea = Left(cadenaDiccionario, InStr(1, cadenaDiccionario, " "))
                'chequear si está en mayúsculas, si es así, salir de la función, sinó, sumar la cadena a la ya obtenida
                If UCase(palabraNuevaLínea) = palabraNuevaLínea Then
                    Exit Function
                Else
                    buscarEntrada = buscarEntrada + " " + cadenaDiccionario
                End If
            End If
        Loop
        Close archivolibre
    Else
        buscarEntrada = ""
    End If
End Function


*/