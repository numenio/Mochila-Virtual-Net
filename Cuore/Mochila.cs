using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class Mochila
    {
    }
}


/*
Public Function sonidoForm(quéForm As Byte) As String
    Dim archivo As String
    
    'corregir que las variables se cargen desde la configuración
'    rutaMúsicaFormPrincipal = "principal.mid"
'    rutaMúsicaFormCuaderno = "cuaderno.mid"
'    rutaMúsicaFormActividad = "actividades.mid"
'    rutaMúsicaFormTareas = "tareas.mid"
'    rutaMúsicaFormLibros = "libros.mid"
'    rutaMúsicaFormAccesorios = "accesorios.mid"
    
    archivo = App.path + "\sonidos\formularios\"
    Select Case quéForm
        Case formularios.principal
            If Trim(usuario.rutaMúsicaFormPrincipal) <> "" And Trim(Left(usuario.rutaMúsicaFormPrincipal, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormPrincipal)
            Else
                archivo = archivo + "principal.mid"
            End If
        Case formularios.cuaderno
            If Trim(usuario.rutaMúsicaFormCuaderno) <> "" And Trim(Left(usuario.rutaMúsicaFormCuaderno, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormCuaderno)
            Else
                archivo = archivo + "cuaderno.mid"
            End If
        Case formularios.actividades
            If Trim(usuario.rutaMúsicaFormActividad) <> "" And Trim(Left(usuario.rutaMúsicaFormActividad, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormActividad)
            Else
                archivo = archivo + "actividades.mid"
            End If
        Case formularios.tareasAnt
            If Trim(usuario.rutaMúsicaFormTareas) <> "" And Trim(Left(usuario.rutaMúsicaFormTareas, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormTareas)
            Else
                archivo = archivo + "tareas.mid"
            End If
        Case formularios.libros
            If Trim(usuario.rutaMúsicaFormLibros) <> "" And Trim(Left(usuario.rutaMúsicaFormLibros, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormLibros)
            Else
                archivo = archivo + "libros.mid"
            End If
        Case formularios.accesorios
            If Trim(usuario.rutaMúsicaFormAccesorios) <> "" And Trim(Left(usuario.rutaMúsicaFormAccesorios, 1)) <> Chr(0) Then
                archivo = archivo + Trim(usuario.rutaMúsicaFormAccesorios)
            Else
                archivo = archivo + "accesorios.mid"
            End If
    End Select
    sonidoForm = archivo
End Function

Public Sub reproducirForm(quéForm As Byte)
    If swMúsicaDeFondo = True Then
        frmOculto.swContinuarReproducción = False
        frmOculto.media.Stop
        frmOculto.media.FileName = sonidoForm(quéForm)
        frmOculto.swContinuarReproducción = True
'        frmOculto.media.Play
    Else
        If frmOculto.media.PlayState = mpPlaying Then
            frmOculto.swContinuarReproducción = False
            frmOculto.media.Stop
        End If
   End If
End Sub


Public Function existeCarpeta(ByVal rutaCarpeta As String) As Boolean 'si existe o no una carpeta o archivo
    Dim x As Integer
    On Error GoTo Fallo
    x = GetAttr(rutaCarpeta)
    existeCarpeta = True
    Exit Function
Fallo:
    existeCarpeta = False
End Function


Sub evaluarSelección(cuadroRTF As RichTextBox, control As Boolean, Shift As Boolean, teclaQueSelecciona As Byte)    'As String
    Static LenSelecciónAnterior As Currency
    Dim estadoSelección As Byte, cadena As String
    
    If Len(cuadroRTF.SelText) < LenSelecciónAnterior Then estadoSelección = selección.disminuyó
    If Len(cuadroRTF.SelText) > LenSelecciónAnterior Then estadoSelección = selección.creció
    If Len(cuadroRTF.SelText) = LenSelecciónAnterior Then estadoSelección = selección.igual
    
    If estadoSelección <> selección.igual Then
        If cuadroRTF.SelText = "" And estadoSelección = selección.disminuyó Then cadena = "quitando la selección"
        If cuadroRTF.SelText = "" And LenSelecciónAnterior <> 0 And teclaQueSelecciona = tecla.borrar Then cadena = "borrando la selección"
        '++++++++++++++++++++++++++++++++++++++++++++
        'se selecciona con shift y control apretadas
        If control And Shift Then 'si se va seleccionando texto con control y shift
            If (teclaQueSelecciona = tecla.flechaDerecha Or teclaQueSelecciona = tecla.flechaIzquierda) Then   'seleccionado por palabras
                If cuadroRTF.Text <> "" Then
                    cadena = "texto seleccionado: " + cuadroRTF.SelText
                Else
                    cadena = "no se puede seleccionar porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.inicio Then
                If cuadroRTF.Text <> "" Then
                    If cuadroRTF.SelText <> "" Then
                        If estadoSelección = selección.creció Then cadena = "seleccionado todo el texto desde donde estabas hasta el principio de la hoja"
                        If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta el principio de la hoja"
                    Else
                        cadena = "se ha sacado la selección del texto"
                    End If
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.fin Then
                If cuadroRTF.Text <> "" Then
                    If cuadroRTF.SelText <> "" Then
                        If estadoSelección = selección.creció Then cadena = "seleccionado todo el texto desde donde estabas hasta el final de la hoja"
                        If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta el final de la hoja"
                        'cadena =  "seleccionado todo el texto desde donde estabas hasta el final de la hoja"
                    Else
                        cadena = "se ha dejado de seleccionar todo el texto"
                    End If
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.flechaArriba Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionado desde donde estabas hasta el principio del párrafo"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta el principio del párrafo"
                    'cadena =  "seleccionado desde donde estabas hasta el principio del párrafo"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.flechaAbajo Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionado desde donde estabas hasta el final del párrafo"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta el final del párrafo"
                    'cadena =  "seleccionado desde donde estabas hasta el final del párrafo"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.avancePágina Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando varios renglones desde donde estabas hacia arriba en la hoja"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección varios renglones desde donde estabas hacia arriba en la hoja"
                    'cadena =  "seleccionando varios renglones desde donde estabas hacia arriba en la hoja"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.retrocesoPágina Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando varios renglones desde donde estabas hacia abajo en la hoja"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección varios renglones desde donde estabas hacia abajo en la hoja"
                    'cadena =  "seleccionando varios renglones desde donde estabas hacia abajo en la hoja"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
        End If
        
        '++++++++++++++++++++++++++++++++++++++++++++
        'se selecciona solamente con shift
        If Shift And Not control Then 'si se va seleccionando texto con control y shift
            If (teclaQueSelecciona = tecla.flechaDerecha Or teclaQueSelecciona = tecla.flechaIzquierda) Then   'seleccionado por letras
                If cuadroRTF.Text <> "" Then
                    cadena = "texto seleccionado: "
                    If Left(cuadroRTF.SelText, 1) = " " Then cadena = cadena + " espacio "
                    If Left(cuadroRTF.SelText, 1) = Chr(13) Then cadena = cadena + " bajada de línea "
                    
                    cadena = cadena + cuadroRTF.SelText
                Else
                    cadena = "no se puede seleccionar porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.inicio Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando el texto hasta el principio del renglón"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección, queda seleccionado: " + cuadroRTF.SelText
                    'cadena =  "seleccionando el texto hasta el principio del renglón"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.fin Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando el texto hasta el final del renglón"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección, queda seleccionado: " + cuadroRTF.SelText
                    'cadena =  "seleccionando el texto hasta el final del renglón"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.flechaArriba Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionado desde donde estabas hasta la misma posición del renglón superior"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta la misma posición del renglón superior"
                    'cadena =  "seleccionado desde donde estabas hasta la misma posición del renglón superior"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.flechaAbajo Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionado desde donde estabas hasta la misma posición del renglón inferior"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección desde donde estabas hasta la misma posición del renglón inferior"
                    'cadena =  "seleccionado desde donde estabas hasta la misma posición del renglón inferior"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.avancePágina Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando varios renglones desde donde estabas hacia arriba en la hoja"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección varios renglones desde donde estabas hacia arriba en la hoja"
                    'cadena =  "seleccionando varios renglones desde donde estabas hacia arriba en la hoja"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
            
            If teclaQueSelecciona = tecla.retrocesoPágina Then
                If cuadroRTF.Text <> "" Then
                    If estadoSelección = selección.creció Then cadena = "seleccionando varios renglones desde donde estabas hacia abajo en la hoja"
                    If estadoSelección = selección.disminuyó Then cadena = "disminuyendo la selección varios renglones desde donde estabas hacia abajo en la hoja"
                    'cadena =  "seleccionando varios renglones desde donde estabas hacia abajo en la hoja"
                Else
                    cadena = "no se puede seleccionar porque porque la hoja está vacía"
                End If
            End If
        End If
    
        
        If control And teclaQueSelecciona = tecla.a Then 'seleccionar todo el texto
            If cuadroRTF.Text <> "" Then
                cadena = "se seleccionó todo el texto de la hoja"
            Else
                cadena = "No se puede seleccionar porque la hoja está vacía"
            End If
        End If
        
        If cadena <> "" Then Decir cadena
    End If
    
    LenSelecciónAnterior = Len(cuadroRTF.SelText)
End Sub


Public Function compararFechas(fecha1 As Date, fecha2 As Date) As Byte
    Dim día1 As Byte, día2 As Byte, mes1 As Byte, mes2 As Byte, año1 As Integer, año2 As Integer
    
    día1 = Left(Format(fecha1, "dd/mm/yyyy"), 2)
    día2 = Left(Format(fecha2, "dd/mm/yyyy"), 2)
    
    mes1 = Mid(Format(fecha1, "dd/mm/yyyy"), 4, 2)
    mes2 = Mid(Format(fecha2, "dd/mm/yyyy"), 4, 2)
    
    año1 = Right(Format(fecha1, "dd/mm/yyyy"), 4)
    año2 = Right(Format(fecha2, "dd/mm/yyyy"), 4)
    
    If año1 > año2 Then
        compararFechas = comparación.primeroMayor
        Exit Function
    End If
    
    If año1 < año2 Then
        compararFechas = comparación.primeroMenor
        Exit Function
    End If
    
    If año1 = año2 Then
        If mes1 > mes2 Then
            compararFechas = comparación.primeroMayor
            Exit Function
        End If
        
        If mes1 < mes2 Then
            compararFechas = comparación.primeroMenor
            Exit Function
        End If
        
        If mes1 = mes2 Then
            If día1 > día2 Then
                compararFechas = comparación.primeroMayor
                Exit Function
            End If
            
            If día1 < día2 Then
                compararFechas = comparación.primeroMenor
                Exit Function
            End If
            
            If día1 = día2 Then
                compararFechas = comparación.iguales
                Exit Function
            End If
        End If
    End If
End Function


Public Function compararHora(primerHora As Date, segundaHora As Date) As Byte
    Dim hora1 As Byte, hora2 As Byte, minutos1 As Byte, minutos2 As Byte
    
    hora1 = Left(Format(primerHora, "HH:mm"), 2)
    hora2 = Left(Format(segundaHora, "HH:mm"), 2)
    minutos1 = Right(Format(primerHora, "HH:mm"), 2)
    minutos2 = Right(Format(segundaHora, "HH:mm"), 2)
    
    If hora1 > hora2 Then
        compararHora = comparación.primeroMayor
        Exit Function
    End If
    
    If hora1 < hora2 Then
        compararHora = comparación.primeroMenor
        Exit Function
    End If
    
    If hora1 = hora2 Then
        If minutos1 > minutos2 Then
            compararHora = comparación.primeroMayor
            Exit Function
        End If
    
        If minutos1 < minutos2 Then
            compararHora = comparación.primeroMenor
            Exit Function
        End If
        
        If minutos1 = minutos2 Then
            compararHora = comparación.iguales
            Exit Function
        End If
    End If
End Function



' ----------------------------------------------------------------------------------------
' \\ --   Subrutina para cargar en forma dinámica el menú de opciones
' ----------------------------------------------------------------------------------------
Public Sub Cargar_Menu(El_SubMenu As Object, palabras() As String)
    Dim i As Integer
    
    ' -- Por si hay Submenu cargados, los descarga a todos
    For i = 1 To El_SubMenu.Count - 1
        Unload El_SubMenu(i)
    Next
    
    If UBound(palabras) <> 0 Then 'si se manda alguna palabra para el menú
        For i = 0 To UBound(palabras)
            ' -- Establecer el caption del primer SubMenu
            El_SubMenu(El_SubMenu.Count - 1).Caption = palabras(i)
            
            ' -- Crear otro menú dinamicamente mediante Load
            If i <> UBound(palabras) Then Load El_SubMenu(El_SubMenu.Count)
        Next
    Else
        El_SubMenu(El_SubMenu.Count - 1).Caption = "No sé qué palabra sugerirte"
    End If
End Sub





Public Sub Cargar_Menú_En_Lista(lista As ListBox, palabras() As String)
    Dim i As Byte
    
    lista.Clear
    For i = 0 To UBound(palabras)
        lista.AddItem palabras(i)
    Next
    lista.Visible = True
    lista.SetFocus
End Sub



Public Function buscarPalabraParaCorregir(cuadroRTF As RichTextBox) As String
    Dim cont As Long ', cadena As String,
    Dim cont2 As Long
    
    cont = cuadroRTF.SelStart
    If cont <> 0 Then
        'Do While Mid(cuadroRtf.Text, cont, 1) <> Chr(1) 'se busca el comienzo de la palabra
        Do While (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 65 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 90) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 97 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 122) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 192 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 220) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 224 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 252)
            cont = cont - 1
            If cont = 0 Then Exit Do
        Loop
    End If
    
    cont2 = cont + 1
    
    'se busca ve cuánto mide la palabra
    If cont2 < Len(cuadroRTF.Text) Then
        Do While (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 65 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 90) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 97 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 122) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 192 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 220) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 224 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 252)
            cont2 = cont2 + 1
            If cont2 >= Len(cuadroRTF.Text) Then Exit Do
        Loop
    End If
    
'    If cont = 0 Then
'        cont = 1
'    Else
        cont = cont + 1
'    End If
    
    If cont2 = Len(cuadroRTF.Text) Then ' cont = 1 And cont2 = Len(cuadroRtf.Text) Then 'si hay una sola palabra escrita o si es la última palabra
        buscarPalabraParaCorregir = Trim(Mid(cuadroRTF.Text, cont, cont2))
    Else
        If cont2 - cont >= 0 Then
            buscarPalabraParaCorregir = Trim(Mid(cuadroRTF.Text, cont, cont2 - cont))
        Else
            buscarPalabraParaCorregir = ""
        End If
    End If
End Function

Public Sub corregirConPalabraSeleccionada(cuadroRTF As RichTextBox, palabra As String)
    Dim cont As Long ', cadena As String,
    Dim cont2 As Long
    
    cont = cuadroRTF.SelStart
    If cont <> 0 Then
        'Do While Mid(cuadroRtf.Text, cont, 1) <> Chr(1) 'se busca el comienzo de la palabra
        Do While (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 65 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 90) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 97 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 122) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 192 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 220) _
        Or (Asc(Mid(cuadroRTF.Text, cont, 1)) >= 224 And Asc(Mid(cuadroRTF.Text, cont, 1)) <= 252)
            cont = cont - 1
            If cont = 0 Then Exit Do
        Loop
    End If
    
    cont2 = cont + 1
    
    'se busca ve cuánto mide la palabra
    If cont2 < Len(cuadroRTF.Text) Then
        Do While (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 65 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 90) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 97 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 122) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 192 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 220) _
        Or (Asc(Mid(cuadroRTF.Text, cont2, 1)) >= 224 And Asc(Mid(cuadroRTF.Text, cont2, 1)) <= 252)
            cont2 = cont2 + 1
            If cont2 >= Len(cuadroRTF.Text) Then Exit Do
        Loop
    End If
    
    If cont2 = Len(cuadroRTF.Text) Then cont2 = cont2 + 1
    
    cuadroRTF.SelStart = cont ' Comenzamos desde la cantidad de caracteres menos 1
    cuadroRTF.SelLength = cont2 - cont - 1 ' Con un maximo de un caracter.
    cuadroRTF.SelText = palabra ' Borramos
End Sub
*/