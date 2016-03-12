Class Form1
    WithEvents Compute, Empty As Button
    Dim f(1, 1, 1, 1) As Integer
    WithEvents File As TextBox
    Dim Karnaugh(1, 1, 1, 1) As KarnaughButton
    WithEvents Time As Timer
    Sub AddButton(c As Color, e As Boolean, l As Integer, t As Integer, w As Integer, h As Integer, txt As String)
        Dim b As Button = PrettyButton(New Button, c, e, l, t, w, h, txt)
    End Sub
    Sub Compute_Click() Handles Compute.Click
        Dim d(3, 1, 1, 1), fx(3, 1, 1, 1, 1), fxx(3, 1, 3, 1, 1, 1), IntervallValitud(2, 2, 2, 2), Katteid(1, 1, 1, 1), ReedMulleriTabel(2, 2, 2, 2, 1, 1, 1, 1), VajaMarki As Integer
        Dim Jaak0, Jaak00, Jaak01, Jaak1, Jaak10, Jaak11, s1, s2, s3, Valjatrykk, z1, z2 As String
        If f(0, 0, 0, 0) > 0 And f(0, 0, 0, 1) > 0 And f(0, 0, 1, 0) > 0 And f(0, 0, 1, 1) > 0 And f(0, 1, 0, 0) > 0 And f(0, 1, 0, 1) > 0 And f(0, 1, 1, 0) > 0 And f(0, 1, 1, 1) > 0 And f(1, 0, 0, 0) > 0 And f(1, 0, 0, 1) > 0 And f(1, 0, 1, 0) > 0 And f(1, 0, 1, 1) > 0 And f(1, 1, 0, 0) > 0 And f(1, 1, 0, 1) > 0 And f(1, 1, 1, 0) > 0 And f(1, 1, 1, 1) > 0 Or f(0, 0, 0, 0) Mod 2 = 0 And f(0, 0, 0, 1) Mod 2 = 0 And f(0, 0, 1, 0) Mod 2 = 0 And f(0, 0, 1, 1) Mod 2 = 0 And f(0, 1, 0, 0) Mod 2 = 0 And f(0, 1, 0, 1) Mod 2 = 0 And f(0, 1, 1, 0) Mod 2 = 0 And f(0, 1, 1, 1) Mod 2 = 0 And f(1, 0, 0, 0) Mod 2 = 0 And f(1, 0, 0, 1) Mod 2 = 0 And f(1, 0, 1, 0) Mod 2 = 0 And f(1, 0, 1, 1) Mod 2 = 0 And f(1, 1, 0, 0) Mod 2 = 0 And f(1, 1, 0, 1) Mod 2 = 0 And f(1, 1, 1, 0) Mod 2 = 0 And f(1, 1, 1, 1) Mod 2 = 0 Then
            MsgBox("See on liiga igav funktsioon...")
            Exit Sub
        End If
        Valjatrykk = Minimeeri(1) & Minimeeri(0)
        If Not (f(0, 0, 0, 0) = 2 Or f(0, 0, 0, 1) = 2 Or f(0, 0, 1, 0) = 2 Or f(0, 0, 1, 1) = 2 Or f(0, 1, 0, 0) = 2 Or f(0, 1, 0, 1) = 2 Or f(0, 1, 1, 0) = 2 Or f(0, 1, 1, 1) = 2 Or f(1, 0, 0, 0) = 2 Or f(1, 0, 0, 1) = 2 Or f(1, 0, 1, 0) = 2 Or f(1, 0, 1, 1) = 2 Or f(1, 1, 0, 0) = 2 Or f(1, 1, 0, 1) = 2 Or f(1, 1, 1, 0) = 2 Or f(1, 1, 1, 1) = 2) Then
            Valjatrykk &= "Reed-Mulleri polünoom:" & vbNewLine & vbNewLine & "Katteid|"
            For y1 = 1 To 2
                For y2 = 1 To 2
                    For y3 = 1 To 2
                        For y4 = 1 To 2
                            For x1 = 0 To 1
                                For x2 = 0 To 1
                                    For x3 = 0 To 1
                                        For x4 = 0 To 1
                                            If (x1 = 1 Or y1 = 2) And (x2 = 1 Or y2 = 2) And (x3 = 1 Or y3 = 2) And (x4 = 1 Or y4 = 2) Then
                                                ReedMulleriTabel(y1, y2, y3, y4, x1, x2, x3, x4) = 1
                                            Else
                                                ReedMulleriTabel(y1, y2, y3, y4, x1, x2, x3, x4) = 0
                                            End If
                                        Next
                                    Next
                                Next
                            Next
                            IntervallValitud(y1, y2, y3, y4) = 2
                        Next
                    Next
                Next
            Next
            For x1 = 0 To 1
                For x2 = 0 To 1
                    For x3 = 0 To 1
                        For x4 = 0 To 1
                            Katteid(x1, x2, x3, x4) = 0
                            For y1 = 0 To 1
                                For y2 = 0 To 1
                                    For y3 = 0 To 1
                                        For y4 = 0 To 1
                                            If ReedMulleriTabel(2 - y1, 2 - y2, 2 - y3, 2 - y4, x1, x2, x3, x4) = 1 Then
                                                If IntervallValitud(2 - y1, 2 - y2, 2 - y3, 2 - y4) = 2 Then
                                                    IntervallValitud(2 - y1, 2 - y2, 2 - y3, 2 - y4) = Math.Abs(f(x1, x2, x3, x4) - (Katteid(x1, x2, x3, x4) Mod 2))
                                                End If
                                                Katteid(x1, x2, x3, x4) += IntervallValitud(2 - y1, 2 - y2, 2 - y3, 2 - y4)
                                            End If
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
            For x1 As Integer = 0 To 1
                For x2 As Integer = 0 To 1
                    For x3 As Integer = 0 To 1
                        For x4 As Integer = 0 To 1
                            Valjatrykk &= TrykiNumber(Katteid(x1, x2, x3, x4)) & "|"
                        Next
                    Next
                Next
            Next
            Valjatrykk &= vbNewLine & "       +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+" & vbNewLine & "       | 0| 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|15|" & vbNewLine & "-------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+" & vbNewLine
            For y1 As Integer = 1 To 2
                For y2 As Integer = 1 To 2
                    For y3 As Integer = 1 To 2
                        For y4 As Integer = 1 To 2
                            If IntervallValitud(y1, y2, y3, y4) = 1 Then
                                Valjatrykk &= "V  " & TrykiVektor(y1, y2, y3, y4) & "|"
                            Else
                                Valjatrykk &= "X  " & TrykiVektor(y1, y2, y3, y4) & "|"
                            End If
                            For x1 As Integer = 0 To 1
                                For x2 As Integer = 0 To 1
                                    For x3 As Integer = 0 To 1
                                        For x4 As Integer = 0 To 1
                                            Valjatrykk &= TrykiKate(ReedMulleriTabel(y1, y2, y3, y4, x1, x2, x3, x4))
                                        Next
                                    Next
                                Next
                            Next
                            Valjatrykk &= vbNewLine & "-------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+" & vbNewLine
                        Next
                    Next
                Next
            Next
            Valjatrykk &= vbNewLine
            VajaMarki = 0
            For y1 As Integer = 1 To 2
                For y2 As Integer = 1 To 2
                    For y3 As Integer = 1 To 2
                        For y4 As Integer = 1 To 2
                            If IntervallValitud(y1, y2, y3, y4) = 1 Then
                                If VajaMarki = 1 Then
                                    Valjatrykk &= "+"
                                Else
                                    VajaMarki = 1
                                End If
                                If y1 = 2 And y2 = 2 And y3 = 2 And y4 = 2 Then
                                    Valjatrykk &= "1"
                                Else
                                    Valjatrykk &= TrykiKonjunktsioon(y1, y2, y3, y4)
                                End If
                            End If
                        Next
                    Next
                Next
            Next
            For y1 As Integer = 0 To 1
                For y2 As Integer = 0 To 1
                    For y3 As Integer = 0 To 1
                        fx(0, 0, y1, y2, y3) = f(0, y1, y2, y3)
                        fx(0, 1, y1, y2, y3) = f(1, y1, y2, y3)
                        fx(1, 0, y1, y2, y3) = f(y1, 0, y2, y3)
                        fx(1, 1, y1, y2, y3) = f(y1, 1, y2, y3)
                        fx(2, 0, y1, y2, y3) = f(y1, y2, 0, y3)
                        fx(2, 1, y1, y2, y3) = f(y1, y2, 1, y3)
                        fx(3, 0, y1, y2, y3) = f(y1, y2, y3, 0)
                        fx(3, 1, y1, y2, y3) = f(y1, y2, y3, 1)
                        For x As Integer = 0 To 3
                            d(x, y1, y2, y3) = (fx(x, 0, y1, y2, y3) + fx(x, 1, y1, y2, y3)) Mod 2
                        Next
                    Next
                Next
            Next
            For y1 As Integer = 0 To 1
                For y2 As Integer = 0 To 1
                    fxx(0, 0, 1, 0, y1, y2) = f(0, 0, y1, y2)
                    fxx(0, 0, 1, 1, y1, y2) = f(0, 1, y1, y2)
                    fxx(0, 1, 1, 0, y1, y2) = f(1, 0, y1, y2)
                    fxx(0, 1, 1, 1, y1, y2) = f(1, 1, y1, y2)
                    fxx(0, 0, 2, 0, y1, y2) = f(0, y1, 0, y2)
                    fxx(0, 0, 2, 1, y1, y2) = f(0, y1, 1, y2)
                    fxx(0, 1, 2, 0, y1, y2) = f(1, y1, 0, y2)
                    fxx(0, 1, 2, 1, y1, y2) = f(1, y1, 1, y2)
                    fxx(0, 0, 3, 0, y1, y2) = f(0, y1, y2, 0)
                    fxx(0, 0, 3, 1, y1, y2) = f(0, y1, y2, 1)
                    fxx(0, 1, 3, 0, y1, y2) = f(1, y1, y2, 0)
                    fxx(0, 1, 3, 1, y1, y2) = f(1, y1, y2, 1)
                    fxx(1, 0, 2, 0, y1, y2) = f(0, y1, 0, y2)
                    fxx(1, 0, 2, 1, y1, y2) = f(0, y1, 1, y2)
                    fxx(1, 1, 2, 0, y1, y2) = f(1, y1, 0, y2)
                    fxx(1, 1, 2, 1, y1, y2) = f(1, y1, 1, y2)
                    fxx(1, 0, 3, 0, y1, y2) = f(y1, 0, y2, 0)
                    fxx(1, 0, 3, 1, y1, y2) = f(y1, 0, y2, 1)
                    fxx(1, 1, 3, 0, y1, y2) = f(y1, 1, y2, 0)
                    fxx(1, 1, 3, 1, y1, y2) = f(y1, 1, y2, 1)
                    fxx(2, 0, 3, 0, y1, y2) = f(y1, y2, 0, 0)
                    fxx(2, 0, 3, 1, y1, y2) = f(y1, y2, 0, 1)
                    fxx(2, 1, 3, 0, y1, y2) = f(y1, y2, 1, 0)
                    fxx(2, 1, 3, 1, y1, y2) = f(y1, y2, 1, 1)
                Next
            Next
            Valjatrykk &= vbNewLine & vbNewLine & "Shannoni arendused:" & vbNewLine & vbNewLine
            For x As Integer = 0 To 3
                s1 = "x" & Ylejaanud1(x)
                s2 = "x" & Ylejaanud2(x)
                s3 = "x" & Ylejaanud3(x)
                Jaak0 = "(" & Minimeeri3(fx(x, 0, 0, 0, 0), fx(x, 0, 0, 0, 1), fx(x, 0, 0, 1, 0), fx(x, 0, 0, 1, 1), fx(x, 0, 1, 0, 0), fx(x, 0, 1, 0, 1), fx(x, 0, 1, 1, 0), fx(x, 0, 1, 1, 1), s1, s2, s3) & ")"
                Jaak1 = "(" & Minimeeri3(fx(x, 1, 0, 0, 0), fx(x, 1, 0, 0, 1), fx(x, 1, 0, 1, 0), fx(x, 1, 0, 1, 1), fx(x, 1, 1, 0, 0), fx(x, 1, 1, 0, 1), fx(x, 1, 1, 1, 0), fx(x, 1, 1, 1, 1), s1, s2, s3) & ")"
                z1 = "x" & CStr(x + 1)
                Valjatrykk &= "¬" & z1 & Jaak0 & "V" & z1 & Jaak1 & vbNewLine
                Valjatrykk &= "[" & z1 & "V" & Jaak0 & "][¬" & z1 & "V" & Jaak1 & "]" & vbNewLine
            Next
            Valjatrykk &= vbNewLine
            For x As Integer = 0 To 2
                For y As Integer = x + 1 To 3
                    If x = 0 Then
                        If y = 1 Then
                            s1 = "x3"
                        Else
                            s1 = "x2"
                        End If
                    Else
                        s1 = "x1"
                    End If
                    If y = 3 Then
                        If x = 2 Then
                            s2 = "x2"
                        Else
                            s2 = "x3"
                        End If
                    Else
                        s2 = "x4"
                    End If
                    Jaak00 = "(" & Minimeeri2(fxx(x, 0, y, 0, 0, 0), fxx(x, 0, y, 0, 0, 1), fxx(x, 0, y, 0, 1, 0), fxx(x, 0, y, 0, 1, 1), s1, s2) & ")"
                    Jaak01 = "(" & Minimeeri2(fxx(x, 0, y, 1, 0, 0), fxx(x, 0, y, 1, 0, 1), fxx(x, 0, y, 1, 1, 0), fxx(x, 0, y, 1, 1, 1), s1, s2) & ")"
                    Jaak10 = "(" & Minimeeri2(fxx(x, 1, y, 0, 0, 0), fxx(x, 1, y, 0, 0, 1), fxx(x, 1, y, 0, 1, 0), fxx(x, 1, y, 0, 1, 1), s1, s2) & ")"
                    Jaak11 = "(" & Minimeeri2(fxx(x, 1, y, 1, 0, 0), fxx(x, 1, y, 1, 0, 1), fxx(x, 1, y, 1, 1, 0), fxx(x, 1, y, 1, 1, 1), s1, s2) & ")"
                    z1 = "x" & CStr(x + 1)
                    z2 = "x" & CStr(y + 1)
                    Valjatrykk &= "¬" & z1 & "¬" & z2 & Jaak00 & "V¬" & z1 & z2 & Jaak01 & "V" & z1 & "¬" & z2 & Jaak10 & "V" & z1 & z2 & Jaak11 & vbNewLine
                    Valjatrykk &= "[" & z1 & "V" & z2 & "V" & Jaak00 & "][" & z1 & "V¬" & z2 & "V" & Jaak01 & "][¬" & z1 & "V" & z2 & "V" & Jaak10 & "][¬" & z1 & "V¬" & z2 & "V" & Jaak11 & "]" & vbNewLine
                Next
            Next
            Valjatrykk &= vbNewLine & "Tuletised:" & vbNewLine & vbNewLine
            For x As Integer = 0 To 3
                s1 = "x" & Ylejaanud1(x)
                s2 = "x" & Ylejaanud2(x)
                s3 = "x" & Ylejaanud3(x)
                Valjatrykk &= "x" & CStr(x + 1) & " järgi: " & Minimeeri3(d(x, 0, 0, 0), d(x, 0, 0, 1), d(x, 0, 1, 0), d(x, 0, 1, 1), d(x, 1, 0, 0), d(x, 1, 0, 1), d(x, 1, 1, 0), d(x, 1, 1, 1), s1, s2, s3) & vbNewLine
            Next
        End If
        Try
            My.Computer.FileSystem.WriteAllText(File.Text, Valjatrykk & vbNewLine & vbNewLine & vbNewLine, True)
        Catch
            FileError()
        End Try
    End Sub
    Sub Empty_Click() Handles Empty.Click
        Try
            My.Computer.FileSystem.WriteAllText(File.Text, "", False)
        Catch
            FileError()
        End Try
    End Sub
    Sub File_TextChanged() Handles File.TextChanged
        Time.Stop()
        File.BackColor = Color.FromArgb(255, 250, 220)
    End Sub
    Sub FileError()
        File.BackColor = Color.FromArgb(255, 125, 95)
        Time.Start()
    End Sub
    Function Ind(ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As Integer
        Return LoendaPiirkond(1, x1, x2, x3, x4)
    End Function
    Sub KarnaughClick(x As Integer, y As Integer, z As Integer, w As Integer)
        f(x, y, z, w) = (f(x, y, z, w) + 1) Mod 3
        Select Case f(x, y, z, w)
            Case 0
                Karnaugh(x, y, z, w).BackColor = Color.MediumSeaGreen
            Case 1
                Karnaugh(x, y, z, w).BackColor = Color.YellowGreen
            Case 2
                Karnaugh(x, y, z, w).BackColor = Color.PowderBlue
        End Select
        Karnaugh(x, y, z, w).Text = LogicalToString(f(x, y, z, w))
    End Sub
    Function LoendaPiirkond(ByVal Piirkond As Integer, ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As Integer
        Dim Tulemus As Integer
        Tulemus = 0
        If x1 = Piirkond Then
            Tulemus += 1
        End If
        If x2 = Piirkond Then
            Tulemus += 1
        End If
        If x3 = Piirkond Then
            Tulemus += 1
        End If
        If x4 = Piirkond Then
            Tulemus += 1
        End If
        Return Tulemus
    End Function
    Function Maaramatusi(ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As Integer
        Return LoendaPiirkond(2, x1, x2, x3, x4)
    End Function
    Sub Me_Load() Handles Me.Load
        Me.BackColor = Color.BurlyWood
        Me.Size = New Size(240, 330)
        Me.Text = "Loogikafunktsioonid!"
        Time = New Timer
        Time.Interval = 8
        AddButton(Color.BurlyWood, False, 12, 12, 40, 40, "    zw" & vbNewLine & "xy    ")
        Dim LabelText As String() = {"00", "01", "11", "10"}
        For i As Integer = 0 To 3
            Dim LabelLocation As Integer = 52 + i * 40
            AddButton(Color.BurlyWood, False, 12, LabelLocation, 40, 40, LabelText(i))
            AddButton(Color.BurlyWood, False, LabelLocation, 12, 40, 40, LabelText(i))
        Next
        Dim KarnaughLocation As Integer(,) = {{52, 92}, {172, 132}}
        For x As Integer = 0 To 1
            For y As Integer = 0 To 1
                For z As Integer = 0 To 1
                    For w As Integer = 0 To 1
                        f(x, y, z, w) = 0
                        Karnaugh(x, y, z, w) = NewKarnaughButton(x, y, z, w, Color.MediumSeaGreen, True, KarnaughLocation(z, w), KarnaughLocation(x, y), 40, 40, "0")
                    Next
                Next
            Next
        Next
        File = New TextBox
        File.BackColor = Color.FromArgb(255, 250, 220)
        File.Location = New Point(12, 218)
        File.Size = New Size(200, 20)
        File.Text = "C:\Users\" & Environment.UserName & "\Desktop\Loogikafunktsioonid.txt"
        Me.Controls.Add(File)
        Compute = PrettyButton(New Button, Color.CadetBlue, True, 31, 244, 50, 40, "Arvuta")
        Empty = PrettyButton(New Button, Color.DarkSalmon, True, 113, 244, 80, 40, "Tühjenda fail")
    End Sub
    Function Minimeeri(Piirkond As Integer) As String
        Dim Erinevusi, Erinevuskoht, i(15), IntervallArvestatud(15), Kaetud(1, 1, 1, 1), Katmata, KatmataVektorid(15), Katteid, Kattekoht, Kattetabel(15, 1, 1, 1, 1), Kirjutamisloendur(3, 4), Kleebitud(3, 4, 12), Kordub, KuhuKirjutada, KuhuKirjutada2, MaksimaalsedIntervallid(15, 3), MaksimaalseidIntervalle, McCluskey(3, 4, 12, 3), MinimaalnePikkus, Normaalkujusid, NormaalkujuSisaldabIntervalli(15, 15), Olemas(2, 2, 2, 2), Olulised(7), Olulisi, Pikkus, Pikkused(15), Sulgusid, Sulud(15, 15), Sulupikkused(15), TestNormaalkujuSisaldabIntervalli(15), Tulbaridasid, Vajalik(3, 4, 12), Vajalikke, VajaMarki, Vektor(3), y(3) As Integer
        Dim Tulbad(3, 33), Valjatrykk As String
        Valjatrykk = CStr(Piirkond) & " piirkond" & vbNewLine & vbNewLine
        For Tulp = 0 To 3
            For Indeks = 0 To 4
                Kirjutamisloendur(Tulp, Indeks) = 0
            Next
        Next
        For x1 As Integer = 0 To 2
            For x2 As Integer = 0 To 2
                For x3 As Integer = 0 To 2
                    For x4 As Integer = 0 To 2
                        Olemas(x1, x2, x3, x4) = 0
                    Next
                Next
            Next
        Next
        Vajalikke = 0
        For x1 As Integer = 0 To 1
            For x2 As Integer = 0 To 1
                For x3 As Integer = 0 To 1
                    For x4 As Integer = 0 To 1
                        Select Case f(x1, x2, x3, x4)
                            Case 2
                                Vajalik(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4))) = 0
                                Kaetud(x1, x2, x3, x4) = 1
                            Case Piirkond
                                Vajalik(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4))) = 1
                                Vajalikke += 1
                                Kaetud(x1, x2, x3, x4) = 0
                            Case Else
                                Kaetud(x1, x2, x3, x4) = 1
                        End Select
                        If f(x1, x2, x3, x4) = 2 Or f(x1, x2, x3, x4) = Piirkond Then
                            Kleebitud(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4))) = 0
                            McCluskey(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4)), 0) = x1
                            McCluskey(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4)), 1) = x2
                            McCluskey(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4)), 2) = x3
                            McCluskey(0, Ind(x1, x2, x3, x4), Kirjutamisloendur(0, Ind(x1, x2, x3, x4)), 3) = x4
                            Kirjutamisloendur(0, Ind(x1, x2, x3, x4)) += 1
                        End If
                    Next
                Next
            Next
        Next
        For Tulp As Integer = 0 To 2
            For Indeks As Integer = 0 To 3 - Tulp
                For Asukoht1 As Integer = 0 To Kirjutamisloendur(Tulp, Indeks) - 1
                    For Asukoht2 As Integer = 0 To Kirjutamisloendur(Tulp, Indeks + 1) - 1
                        Erinevusi = 0
                        For x As Integer = 0 To 3
                            If McCluskey(Tulp, Indeks, Asukoht1, x) <> McCluskey(Tulp, Indeks + 1, Asukoht2, x) Then
                                If McCluskey(Tulp, Indeks, Asukoht1, x) = 2 Or McCluskey(Tulp, Indeks + 1, Asukoht2, x) = 2 Then
                                    Erinevusi = 2
                                    Exit For
                                Else
                                    Erinevusi += 1
                                    Erinevuskoht = x
                                End If
                            End If
                        Next
                        If Erinevusi = 1 Then
                            Kleebitud(Tulp, Indeks, Asukoht1) = 1
                            Kleebitud(Tulp, Indeks + 1, Asukoht2) = 1
                            For x As Integer = 0 To 3
                                Vektor(x) = McCluskey(Tulp, Indeks, Asukoht1, x)
                            Next
                            Vektor(Erinevuskoht) = 2
                            If Olemas(Vektor(0), Vektor(1), Vektor(2), Vektor(3)) = 0 Then
                                Olemas(Vektor(0), Vektor(1), Vektor(2), Vektor(3)) = 1
                                For x As Integer = 0 To 3
                                    McCluskey(Tulp + 1, Indeks, Kirjutamisloendur(Tulp + 1, Indeks), x) = Vektor(x)
                                Next
                                Kleebitud(Tulp + 1, Indeks, Kirjutamisloendur(Tulp + 1, Indeks)) = 0
                                Vajalik(Tulp + 1, Indeks, Kirjutamisloendur(Tulp + 1, Indeks)) = Math.Max(Vajalik(Tulp, Indeks, Asukoht1), Vajalik(Tulp, Indeks + 1, Asukoht2))
                                Kirjutamisloendur(Tulp + 1, Indeks) += 1
                            End If
                        End If
                    Next
                Next
            Next
        Next
        Tulbaridasid = 0
        MaksimaalseidIntervalle = 0
        For Tulp As Integer = 0 To 3
            If Kirjutamisloendur(Tulp, 0) > 0 Or Kirjutamisloendur(Tulp, 1) > 0 Or Kirjutamisloendur(Tulp, 2) > 0 Or Kirjutamisloendur(Tulp, 3) > 0 Or Kirjutamisloendur(Tulp, 4) > 0 Then
                Tulbad(Tulp, 0) = "I|Int. | M |"
                KuhuKirjutada = 1
            Else
                Exit For
            End If
            For Indeks As Integer = 0 To 4
                If Kirjutamisloendur(Tulp, Indeks) > 0 Then
                    If KuhuKirjutada = 1 Then
                        Tulbad(Tulp, 1) = "-+-----+---+"
                    Else
                        Tulbad(Tulp, KuhuKirjutada) = "-+-----+---|"
                    End If
                    KuhuKirjutada += 1
                    If KuhuKirjutada > Tulbaridasid Then
                        Tulbaridasid = KuhuKirjutada
                    End If
                    For Asukoht As Integer = 0 To Kirjutamisloendur(Tulp, Indeks) - 1
                        If Tulbad(Tulp, KuhuKirjutada - 1).Chars(0) = "-" Then
                            Tulbad(Tulp, KuhuKirjutada) = CStr(Indeks) & "|" & TrykiVektor(McCluskey(Tulp, Indeks, Asukoht, 0), McCluskey(Tulp, Indeks, Asukoht, 1), McCluskey(Tulp, Indeks, Asukoht, 2), McCluskey(Tulp, Indeks, Asukoht, 3)) & TrykiTarn(Vajalik(Tulp, Indeks, Asukoht))
                        Else
                            Tulbad(Tulp, KuhuKirjutada) = " |" & TrykiVektor(McCluskey(Tulp, Indeks, Asukoht, 0), McCluskey(Tulp, Indeks, Asukoht, 1), McCluskey(Tulp, Indeks, Asukoht, 2), McCluskey(Tulp, Indeks, Asukoht, 3)) & TrykiTarn(Vajalik(Tulp, Indeks, Asukoht))
                        End If
                        If Kleebitud(Tulp, Indeks, Asukoht) = 1 Then
                            Tulbad(Tulp, KuhuKirjutada) &= " x |"
                        Else
                            If Vajalik(Tulp, Indeks, Asukoht) = 1 Then
                                For x As Integer = 0 To 3
                                    MaksimaalsedIntervallid(MaksimaalseidIntervalle, x) = McCluskey(Tulp, Indeks, Asukoht, x)
                                Next
                                Pikkused(MaksimaalseidIntervalle) = 4 - Maaramatusi(MaksimaalsedIntervallid(MaksimaalseidIntervalle, 0), MaksimaalsedIntervallid(MaksimaalseidIntervalle, 1), MaksimaalsedIntervallid(MaksimaalseidIntervalle, 2), MaksimaalsedIntervallid(MaksimaalseidIntervalle, 3))
                                For x1 As Integer = 0 To 1
                                    For x2 As Integer = 0 To 1
                                        For x3 As Integer = 0 To 1
                                            For x4 As Integer = 0 To 1
                                                If (McCluskey(Tulp, Indeks, Asukoht, 0) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 0) = x1) And (McCluskey(Tulp, Indeks, Asukoht, 1) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 1) = x2) And (McCluskey(Tulp, Indeks, Asukoht, 2) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 2) = x3) And (McCluskey(Tulp, Indeks, Asukoht, 3) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 3) = x4) Then
                                                    Kattetabel(MaksimaalseidIntervalle, x1, x2, x3, x4) = 1
                                                Else
                                                    Kattetabel(MaksimaalseidIntervalle, x1, x2, x3, x4) = 0
                                                End If
                                            Next
                                        Next
                                    Next
                                Next
                                MaksimaalseidIntervalle += 1
                                Tulbad(Tulp, KuhuKirjutada) &= "a" & TrykiNumber(MaksimaalseidIntervalle) & "|"
                            Else
                                Tulbad(Tulp, KuhuKirjutada) &= " * |"
                            End If
                        End If
                        KuhuKirjutada += 1
                        If KuhuKirjutada > Tulbaridasid Then
                            Tulbaridasid = KuhuKirjutada
                        End If
                    Next
                End If
            Next
        Next
        For Rida As Integer = 0 To Tulbaridasid - 1
            Valjatrykk &= Tulbad(0, Rida) & Tulbad(1, Rida) & Tulbad(2, Rida) & Tulbad(3, Rida) & vbNewLine
        Next
        If Not (f(0, 0, 0, 0) = 2 Or f(0, 0, 0, 1) = 2 Or f(0, 0, 1, 0) = 2 Or f(0, 0, 1, 1) = 2 Or f(0, 1, 0, 0) = 2 Or f(0, 1, 0, 1) = 2 Or f(0, 1, 1, 0) = 2 Or f(0, 1, 1, 1) = 2 Or f(1, 0, 0, 0) = 2 Or f(1, 0, 0, 1) = 2 Or f(1, 0, 1, 0) = 2 Or f(1, 0, 1, 1) = 2 Or f(1, 1, 0, 0) = 2 Or f(1, 1, 0, 1) = 2 Or f(1, 1, 1, 0) = 2 Or f(1, 1, 1, 1) = 2) Then
            Select Case Piirkond
                Case 0
                    Valjatrykk &= vbNewLine & "Taandatud konjunktiivne normaalkuju: "
                    For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                        Valjatrykk &= TrykiDisjunktsioon(MaksimaalsedIntervallid(Intervall, 0), MaksimaalsedIntervallid(Intervall, 1), MaksimaalsedIntervallid(Intervall, 2), MaksimaalsedIntervallid(Intervall, 3))
                    Next
                Case 1
                    Valjatrykk &= vbNewLine & "Taandatud disjunktiivne normaalkuju: " & TrykiKonjunktsioon(MaksimaalsedIntervallid(0, 0), MaksimaalsedIntervallid(0, 1), MaksimaalsedIntervallid(0, 2), MaksimaalsedIntervallid(0, 3))
                    For Intervall As Integer = 1 To MaksimaalseidIntervalle - 1
                        Valjatrykk &= "V" & TrykiKonjunktsioon(MaksimaalsedIntervallid(Intervall, 0), MaksimaalsedIntervallid(Intervall, 1), MaksimaalsedIntervallid(Intervall, 2), MaksimaalsedIntervallid(Intervall, 3))
                    Next
            End Select
            Valjatrykk &= vbNewLine
        End If
        Valjatrykk &= vbNewLine & "       |"
        For x1 As Integer = 0 To 1
            For x2 As Integer = 0 To 1
                For x3 As Integer = 0 To 1
                    For x4 As Integer = 0 To 1
                        If f(x1, x2, x3, x4) = Piirkond Then
                            Valjatrykk &= TrykiNumber(8 * x1 + 4 * x2 + 2 * x3 + x4) & "|"
                        End If
                    Next
                Next
            Next
        Next
        Valjatrykk &= vbNewLine
        For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
            Valjatrykk &= "-----"
            For Nr As Integer = 0 To Vajalikke
                Valjatrykk &= "--+"
            Next
            Valjatrykk &= vbNewLine & "a" & TrykiNumber(Intervall + 1) & " (" & CStr(Pikkused(Intervall)) & ")|"
            For x1 As Integer = 0 To 1
                For x2 As Integer = 0 To 1
                    For x3 As Integer = 0 To 1
                        For x4 As Integer = 0 To 1
                            If f(x1, x2, x3, x4) = Piirkond Then
                                Valjatrykk &= TrykiKate(Kattetabel(Intervall, x1, x2, x3, x4))
                            End If
                        Next
                    Next
                Next
            Next
            Valjatrykk &= vbNewLine
        Next
        Valjatrykk &= vbNewLine
        For Normaalkuju As Integer = 0 To 15
            For Intervall As Integer = 0 To 15
                NormaalkujuSisaldabIntervalli(Normaalkuju, Intervall) = 0
            Next
        Next
        For x1 As Integer = 0 To 1
            For x2 As Integer = 0 To 1
                For x3 As Integer = 0 To 1
                    For x4 As Integer = 0 To 1
                        If Kaetud(x1, x2, x3, x4) = 0 Then
                            Katteid = 0
                            For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                                If Kattetabel(Intervall, x1, x2, x3, x4) = 1 Then
                                    Katteid += 1
                                    Kattekoht = Intervall
                                End If
                            Next
                            If Katteid = 1 Then
                                For Normaalkuju As Integer = 0 To 15
                                    NormaalkujuSisaldabIntervalli(Normaalkuju, Kattekoht) = 1
                                Next
                                For y1 As Integer = 0 To 1
                                    For y2 As Integer = 0 To 1
                                        For y3 As Integer = 0 To 1
                                            For y4 As Integer = 0 To 1
                                                If Kattetabel(Kattekoht, y1, y2, y3, y4) = 1 Then
                                                    Kaetud(y1, y2, y3, y4) = 1
                                                End If
                                            Next
                                        Next
                                    Next
                                Next
                            End If
                        End If
                    Next
                Next
            Next
        Next
        Olulisi = 0
        For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
            If NormaalkujuSisaldabIntervalli(0, Intervall) = 1 Then
                Olulised(Olulisi) = Intervall
                Olulisi += 1
            End If
        Next
        If Olulisi = 0 Then
            Valjatrykk &= "Olulised intervallid puuduvad."
        Else
            Valjatrykk &= "Olulised intervallid on a" & CStr(Olulised(0) + 1)
            For Intervall As Integer = 1 To Olulisi - 1
                Valjatrykk &= ", a" & CStr(Olulised(Intervall) + 1)
            Next
        End If
        Valjatrykk &= vbNewLine
        Katmata = 0
        For x1 As Integer = 0 To 1
            For x2 As Integer = 0 To 1
                For x3 As Integer = 0 To 1
                    For x4 As Integer = 0 To 1
                        If Kaetud(x1, x2, x3, x4) = 0 Then
                            KatmataVektorid(Katmata) = 8 * x1 + 4 * x2 + 2 * x3 + x4
                            Katmata += 1
                        End If
                    Next
                Next
            Next
        Next
        If Katmata = 0 Then
            Normaalkujusid = 1
            Valjatrykk &= "Kõik piirkonda kuuluvad vektorid on kaetud."
        Else
            Valjatrykk &= "Katmata on vektorid " & CStr(KatmataVektorid(0))
            For Vektorike As Integer = 1 To Katmata - 1
                Valjatrykk &= ", " & CStr(KatmataVektorid(Vektorike))
            Next
            Valjatrykk &= vbNewLine & vbNewLine
            KuhuKirjutada = 0
            For x1 As Integer = 0 To 1
                For x2 As Integer = 0 To 1
                    For x3 As Integer = 0 To 1
                        For x4 As Integer = 0 To 1
                            If Kaetud(x1, x2, x3, x4) = 0 Then
                                KuhuKirjutada2 = 0
                                For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                                    If Kattetabel(Intervall, x1, x2, x3, x4) = 1 Then
                                        Sulud(KuhuKirjutada, KuhuKirjutada2) = Intervall
                                        KuhuKirjutada2 += 1
                                    End If
                                Next
                                Sulupikkused(KuhuKirjutada) = KuhuKirjutada2
                                KuhuKirjutada += 1
                            End If
                        Next
                    Next
                Next
            Next
            Sulgusid = KuhuKirjutada
            If Sulgusid = 1 Then
                Valjatrykk &= "a" & CStr(Sulud(0, 0) + 1)
                For Asukoht As Integer = 1 To Sulupikkused(0) - 1
                    Valjatrykk &= "Va" & CStr(Sulud(0, Asukoht) + 1)
                Next
            Else
                For Sulg As Integer = 0 To Sulgusid - 1
                    If Sulupikkused(Sulg) = 1 Then
                        Valjatrykk &= "a" & CStr(Sulud(Sulg, 0) + 1)
                    Else
                        Valjatrykk &= "(a" & CStr(Sulud(Sulg, 0) + 1)
                        For Asukoht As Integer = 1 To Sulupikkused(Sulg) - 1
                            Valjatrykk &= "Va" & CStr(Sulud(Sulg, Asukoht) + 1)
                        Next
                        Valjatrykk &= ")"
                    End If
                Next
            End If
            MinimaalnePikkus = 1000
            For Nr As Integer = 0 To Sulgusid - 1
                i(Nr) = 0
            Next
            Do
                For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                    IntervallArvestatud(Intervall) = 0
                Next
                Pikkus = 0
                For Sulg As Integer = 0 To Sulgusid - 1
                    If IntervallArvestatud(Sulud(Sulg, i(Sulg))) = 0 Then
                        IntervallArvestatud(Sulud(Sulg, i(Sulg))) = 1
                        Pikkus += Pikkused(Sulud(Sulg, i(Sulg)))
                    End If
                Next
                MinimaalnePikkus = Math.Min(MinimaalnePikkus, Pikkus)
                i(0) += 1
                For Nr As Integer = 0 To Sulgusid - 2
                    If i(Nr) = Sulupikkused(Nr) Then
                        i(Nr) = 0
                        i(Nr + 1) += 1
                    Else
                        Exit For
                    End If
                Next
                If i(Sulgusid - 1) = Sulupikkused(Sulgusid - 1) Then
                    Exit Do
                End If
            Loop
            For Nr As Integer = 0 To Sulgusid - 1
                i(Nr) = 0
            Next
            Normaalkujusid = 0
            Do
                For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                    IntervallArvestatud(Intervall) = 0
                Next
                Pikkus = 0
                For Sulg As Integer = 0 To Sulgusid - 1
                    If IntervallArvestatud(Sulud(Sulg, i(Sulg))) = 0 Then
                        IntervallArvestatud(Sulud(Sulg, i(Sulg))) = 1
                        Pikkus += Pikkused(Sulud(Sulg, i(Sulg)))
                    End If
                Next
                If Pikkus = MinimaalnePikkus Then
                    For Sulg As Integer = 0 To Sulgusid - 1
                        NormaalkujuSisaldabIntervalli(Normaalkujusid, Sulud(Sulg, i(Sulg))) = 1
                    Next
                    Kordub = 0
                    For Normaalkuju As Integer = 0 To Normaalkujusid - 1
                        Erinevusi = 0
                        For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                            If NormaalkujuSisaldabIntervalli(Normaalkujusid, Intervall) <> NormaalkujuSisaldabIntervalli(Normaalkuju, Intervall) Then
                                Erinevusi = 1
                                Exit For
                            End If
                        Next
                        If Erinevusi = 0 Then
                            Kordub = 1
                            Exit For
                        End If
                    Next
                    If Kordub = 1 Then
                        For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                            NormaalkujuSisaldabIntervalli(Normaalkujusid, Intervall) = 0
                        Next
                        For Intervall As Integer = 0 To Olulisi - 1
                            NormaalkujuSisaldabIntervalli(Normaalkujusid, Olulised(Intervall)) = 1
                        Next
                    Else
                        Normaalkujusid += 1
                    End If
                End If
                i(0) += 1
                For Nr As Integer = 0 To Sulgusid - 2
                    If i(Nr) = Sulupikkused(Nr) Then
                        i(Nr) = 0
                        i(Nr + 1) += 1
                    Else
                        Exit For
                    End If
                Next
                If i(Sulgusid - 1) = Sulupikkused(Sulgusid - 1) Then
                    Exit Do
                End If
            Loop
        End If
        Select Case Piirkond
            Case 0
                Valjatrykk &= vbNewLine & vbNewLine & "Minimaalne konjunktiivne normaalkuju" & vbNewLine & vbNewLine
                For Normaalkuju As Integer = 0 To Normaalkujusid - 1
                    For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                        If NormaalkujuSisaldabIntervalli(Normaalkuju, Intervall) = 1 Then
                            Valjatrykk &= TrykiDisjunktsioon(MaksimaalsedIntervallid(Intervall, 0), MaksimaalsedIntervallid(Intervall, 1), MaksimaalsedIntervallid(Intervall, 2), MaksimaalsedIntervallid(Intervall, 3))
                        End If
                    Next
                    Valjatrykk &= vbNewLine
                Next
            Case 1
                Valjatrykk &= vbNewLine & vbNewLine & "Minimaalne disjunktiivne normaalkuju" & vbNewLine & vbNewLine
                For Normaalkuju As Integer = 0 To Normaalkujusid - 1
                    VajaMarki = 0
                    For Intervall As Integer = 0 To MaksimaalseidIntervalle - 1
                        If NormaalkujuSisaldabIntervalli(Normaalkuju, Intervall) = 1 Then
                            If VajaMarki = 1 Then
                                Valjatrykk &= "V"
                            Else
                                VajaMarki = 1
                            End If
                            Valjatrykk &= TrykiKonjunktsioon(MaksimaalsedIntervallid(Intervall, 0), MaksimaalsedIntervallid(Intervall, 1), MaksimaalsedIntervallid(Intervall, 2), MaksimaalsedIntervallid(Intervall, 3))
                        End If
                    Next
                    Valjatrykk &= vbNewLine
                Next
        End Select
        Return Valjatrykk & vbNewLine
    End Function
    Function Minimeeri2(ByVal f0 As Integer, ByVal f1 As Integer, ByVal f2 As Integer, ByVal f3 As Integer, ByVal x1 As String, ByVal x2 As String) As String
        Select Case f0
            Case 0
                Select Case f1
                    Case 0
                        Select Case f2
                            Case 0
                                Select Case f3
                                    Case 0
                                        Return "0"
                                    Case 1
                                        Return CStr(x1) & CStr(x2)
                                End Select
                            Case 1
                                Select Case f3
                                    Case 0
                                        Return CStr(x1) & "¬" & CStr(x2)
                                    Case 1
                                        Return CStr(x1)
                                End Select
                        End Select
                    Case 1
                        Select Case f2
                            Case 0
                                Select Case f3
                                    Case 0
                                        Return "¬" & CStr(x1) & CStr(x2)
                                    Case 1
                                        Return CStr(x2)
                                End Select
                            Case 1
                                Select Case f3
                                    Case 0
                                        Return CStr(x1) & "+" & CStr(x2)
                                    Case 1
                                        Return CStr(x1) & "V" & CStr(x2)
                                End Select
                        End Select
                End Select
            Case 1
                Select Case f1
                    Case 0
                        Select Case f2
                            Case 0
                                Select Case f3
                                    Case 0
                                        Return CStr(x1) & "?" & CStr(x2)
                                    Case 1
                                        Return CStr(x1) & "?" & CStr(x2)
                                End Select
                            Case 1
                                Select Case f3
                                    Case 0
                                        Return "¬" & CStr(x2)
                                    Case 1
                                        Return CStr(x2) & "?" & CStr(x1)
                                End Select
                        End Select
                    Case 1
                        Select Case f2
                            Case 0
                                Select Case f3
                                    Case 0
                                        Return "¬" & CStr(x1)
                                    Case 1
                                        Return CStr(x1) & "?" & CStr(x2)
                                End Select
                            Case 1
                                Select Case f3
                                    Case 0
                                        Return CStr(x1) & "|" & CStr(x2)
                                    Case 1
                                        Return "1"
                                End Select
                        End Select
                End Select
        End Select
    End Function
    Function Minimeeri3(ByVal f0 As Integer, ByVal f1 As Integer, ByVal f2 As Integer, ByVal f3 As Integer, ByVal f4 As Integer, ByVal f5 As Integer, ByVal f6 As Integer, ByVal f7 As Integer, ByVal z1 As String, ByVal z2 As String, ByVal z3 As String) As String
        Dim Erinevusi, Erinevuskoht, fn(1, 1, 1), i(7), IntervallArvestatud(7), Kaetud(1, 1, 1), Kattetabel(7, 1, 1, 1), Kirjutamisloendur(2, 3), Kleebitud(2, 3, 5), Lihtimplikandid(7, 2), Lihtimplikante, McCluskey(2, 3, 5, 2), MinimaalnePikkus, Olemas(2, 2, 2), Pikkus, Pikkused(7), VajaMarki, Vektor(2), y(2) As Integer
        Dim Normaalkuju, z(2) As String
        If f0 = 0 And f1 = 0 And f2 = 0 And f3 = 0 And f4 = 0 And f5 = 0 And f6 = 0 And f7 = 0 Then
            Return "0"
        ElseIf f0 = 1 And f1 = 1 And f2 = 1 And f3 = 1 And f4 = 1 And f5 = 1 And f6 = 1 And f7 = 1 Then
            Return "1"
        End If
        fn(0, 0, 0) = f0
        fn(0, 0, 1) = f1
        fn(0, 1, 0) = f2
        fn(0, 1, 1) = f3
        fn(1, 0, 0) = f4
        fn(1, 0, 1) = f5
        fn(1, 1, 0) = f6
        fn(1, 1, 1) = f7
        z(0) = z1
        z(1) = z2
        z(2) = z3
        For Tulp As Integer = 0 To 2
            For Indeks As Integer = 0 To 3
                Kirjutamisloendur(Tulp, Indeks) = 0
            Next
        Next
        For x1 As Integer = 0 To 2
            For x2 As Integer = 0 To 2
                For x3 As Integer = 0 To 2
                    Olemas(x1, x2, x3) = 0
                Next
            Next
        Next
        For x1 As Integer = 0 To 1
            For x2 As Integer = 0 To 1
                For x3 As Integer = 0 To 1
                    If fn(x1, x2, x3) = 1 Then
                        Kleebitud(0, Ind(x1, x2, x3, 0), Kirjutamisloendur(0, Ind(x1, x2, x3, 0))) = 0
                        McCluskey(0, Ind(x1, x2, x3, 0), Kirjutamisloendur(0, Ind(x1, x2, x3, 0)), 0) = x1
                        McCluskey(0, Ind(x1, x2, x3, 0), Kirjutamisloendur(0, Ind(x1, x2, x3, 0)), 1) = x2
                        McCluskey(0, Ind(x1, x2, x3, 0), Kirjutamisloendur(0, Ind(x1, x2, x3, 0)), 2) = x3
                        Kirjutamisloendur(0, Ind(x1, x2, x3, 0)) += 1
                    End If
                Next
            Next
        Next
        For Tulp As Integer = 0 To 1
            For Indeks As Integer = 0 To 2 - Tulp
                For Asukoht1 As Integer = 0 To Kirjutamisloendur(Tulp, Indeks) - 1
                    For Asukoht2 As Integer = 0 To Kirjutamisloendur(Tulp, Indeks + 1) - 1
                        Erinevusi = 0
                        For x As Integer = 0 To 2
                            If McCluskey(Tulp, Indeks, Asukoht1, x) <> McCluskey(Tulp, Indeks + 1, Asukoht2, x) Then
                                If McCluskey(Tulp, Indeks, Asukoht1, x) = 2 Or McCluskey(Tulp, Indeks + 1, Asukoht2, x) = 2 Then
                                    Erinevusi = 2
                                    Exit For
                                Else
                                    Erinevusi += 1
                                    Erinevuskoht = x
                                End If
                            End If
                        Next
                        If Erinevusi = 1 Then
                            Kleebitud(Tulp, Indeks, Asukoht1) = 1
                            Kleebitud(Tulp, Indeks + 1, Asukoht2) = 1
                            For x As Integer = 0 To 2
                                Vektor(x) = McCluskey(Tulp, Indeks, Asukoht1, x)
                            Next
                            Vektor(Erinevuskoht) = 2
                            If Olemas(Vektor(0), Vektor(1), Vektor(2)) = 0 Then
                                Olemas(Vektor(0), Vektor(1), Vektor(2)) = 1
                                For x As Integer = 0 To 2
                                    McCluskey(Tulp + 1, Indeks, Kirjutamisloendur(Tulp + 1, Indeks), x) = Vektor(x)
                                Next
                                Kleebitud(Tulp + 1, Indeks, Kirjutamisloendur(Tulp + 1, Indeks)) = 0
                                Kirjutamisloendur(Tulp + 1, Indeks) += 1
                            End If
                        End If
                    Next
                Next
            Next
        Next
        Lihtimplikante = 0
        For Tulp As Integer = 0 To 2
            For Indeks As Integer = 0 To 3
                If Kirjutamisloendur(Tulp, Indeks) > 0 Then
                    For Asukoht As Integer = 0 To Kirjutamisloendur(Tulp, Indeks) - 1
                        If Kleebitud(Tulp, Indeks, Asukoht) = 0 Then
                            For x As Integer = 0 To 2
                                Lihtimplikandid(Lihtimplikante, x) = McCluskey(Tulp, Indeks, Asukoht, x)
                            Next
                            Pikkused(Lihtimplikante) = 3 - Maaramatusi(Lihtimplikandid(Lihtimplikante, 0), Lihtimplikandid(Lihtimplikante, 1), Lihtimplikandid(Lihtimplikante, 2), 2)
                            For x1 As Integer = 0 To 1
                                For x2 As Integer = 0 To 1
                                    For x3 As Integer = 0 To 1
                                        If (McCluskey(Tulp, Indeks, Asukoht, 0) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 0) = x1) And (McCluskey(Tulp, Indeks, Asukoht, 1) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 1) = x2) And (McCluskey(Tulp, Indeks, Asukoht, 2) = 2 Or McCluskey(Tulp, Indeks, Asukoht, 2) = x3) Then
                                            Kattetabel(Lihtimplikante, x1, x2, x3) = 1
                                        Else
                                            Kattetabel(Lihtimplikante, x1, x2, x3) = 0
                                        End If
                                    Next
                                Next
                            Next
                            Lihtimplikante += 1
                        End If
                    Next
                End If
            Next
        Next
        For Nr As Integer = 0 To Lihtimplikante - 1
            i(Nr) = 0
        Next
        MinimaalnePikkus = 1000
        Do
            For x1 As Integer = 0 To 1
                For x2 As Integer = 0 To 1
                    For x3 As Integer = 0 To 1
                        Kaetud(x1, x2, x3) = 0
                    Next
                Next
            Next
            For Implikant As Integer = 0 To Lihtimplikante - 1
                If i(Implikant) = 1 Then
                    For x1 As Integer = 0 To 1
                        For x2 As Integer = 0 To 1
                            For x3 As Integer = 0 To 1
                                If Kattetabel(Implikant, x1, x2, x3) = 1 Then
                                    Kaetud(x1, x2, x3) = 1
                                End If
                            Next
                        Next
                    Next
                End If
            Next
            If fn(0, 0, 0) = Kaetud(0, 0, 0) And fn(0, 0, 1) = Kaetud(0, 0, 1) And fn(0, 1, 0) = Kaetud(0, 1, 0) And fn(0, 1, 1) = Kaetud(0, 1, 1) And fn(1, 0, 0) = Kaetud(1, 0, 0) And fn(1, 0, 1) = Kaetud(1, 0, 1) And fn(1, 1, 0) = Kaetud(1, 1, 0) And fn(1, 1, 1) = Kaetud(1, 1, 1) Then
                Pikkus = 0
                For Implikant As Integer = 0 To Lihtimplikante - 1
                    Pikkus += i(Implikant) * Pikkused(Implikant)
                Next
                MinimaalnePikkus = Math.Min(MinimaalnePikkus, Pikkus)
            End If
            i(0) += 1
            For Nr As Integer = 0 To Lihtimplikante - 2
                If i(Nr) = 2 Then
                    i(Nr) = 0
                    i(Nr + 1) += 1
                Else
                    Exit For
                End If
            Next
            If i(Lihtimplikante - 1) = 2 Then
                Exit Do
            End If
        Loop
        For Nr As Integer = 0 To Lihtimplikante - 1
            i(Nr) = 0
        Next
        Do
            For x1 As Integer = 0 To 1
                For x2 As Integer = 0 To 1
                    For x3 As Integer = 0 To 1
                        Kaetud(x1, x2, x3) = 0
                    Next
                Next
            Next
            For Implikant As Integer = 0 To Lihtimplikante - 1
                If i(Implikant) = 1 Then
                    For x1 As Integer = 0 To 1
                        For x2 As Integer = 0 To 1
                            For x3 As Integer = 0 To 1
                                If Kattetabel(Implikant, x1, x2, x3) = 1 Then
                                    Kaetud(x1, x2, x3) = 1
                                End If
                            Next
                        Next
                    Next
                End If
            Next
            If fn(0, 0, 0) = Kaetud(0, 0, 0) And fn(0, 0, 1) = Kaetud(0, 0, 1) And fn(0, 1, 0) = Kaetud(0, 1, 0) And fn(0, 1, 1) = Kaetud(0, 1, 1) And fn(1, 0, 0) = Kaetud(1, 0, 0) And fn(1, 0, 1) = Kaetud(1, 0, 1) And fn(1, 1, 0) = Kaetud(1, 1, 0) And fn(1, 1, 1) = Kaetud(1, 1, 1) Then
                Pikkus = 0
                For Implikant As Integer = 0 To Lihtimplikante - 1
                    Pikkus += i(Implikant) * Pikkused(Implikant)
                Next
                If Pikkus = MinimaalnePikkus Then
                    Normaalkuju = ""
                    VajaMarki = 0
                    For Implikant As Integer = 0 To Lihtimplikante - 1
                        If i(Implikant) = 1 Then
                            If VajaMarki = 1 Then
                                Normaalkuju &= "V"
                            Else
                                VajaMarki = 1
                            End If
                            For x As Integer = 0 To 2
                                Select Case Lihtimplikandid(Implikant, x)
                                    Case 0
                                        Normaalkuju &= "¬" & z(x)
                                    Case 1
                                        Normaalkuju &= z(x)
                                End Select
                            Next
                        End If
                    Next
                    Return Normaalkuju
                End If
            End If
            i(0) += 1
            For Nr As Integer = 0 To Lihtimplikante - 2
                If i(Nr) = 2 Then
                    i(Nr) = 0
                    i(Nr + 1) += 1
                Else
                    Exit For
                End If
            Next
        Loop
    End Function
    Function NewKarnaughButton(x As Integer, y As Integer, z As Integer, w As Integer, c As Color, e As Boolean, l As Integer, t As Integer, wdth As Integer, hght As Integer, txt As String) As KarnaughButton
        Dim b As KarnaughButton = PrettyButton(New KarnaughButton(x, y, z, w), c, e, l, t, hght, wdth, txt)
        AddHandler b.Click, AddressOf b.KarnaughClick
        Return b
    End Function
    Function PrettyButton(Of T As Button)(b As T, c As Color, e As Boolean, lft As Integer, tp As Integer, w As Integer, h As Integer, txt As String) As T
        b.BackColor = c
        b.Enabled = e
        b.Location = New Point(lft, tp)
        b.Size = New Size(w, h)
        b.Text = txt
        Me.Controls.Add(b)
        Return b
    End Function
    Sub Time_Tick() Handles Time.Tick
        If File.BackColor = Color.FromArgb(255, 250, 220) Then
            Time.Stop()
        Else
            File.BackColor = Color.FromArgb(File.BackColor.ToArgb + 257)
        End If
    End Sub
    Function TrykiDisjunktsioon(ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As String
        Dim Vajamarki, x(3) As Integer
        Dim Disjunktsioon As String
        x(0) = x1
        x(1) = x2
        x(2) = x3
        x(3) = x4
        Disjunktsioon = "("
        Vajamarki = 0
        For y As Integer = 0 To 3
            If x(y) < 2 Then
                If Vajamarki = 1 Then
                    Disjunktsioon &= "V"
                Else
                    Vajamarki = 1
                End If
                Select Case x(y)
                    Case 0
                        Disjunktsioon &= "x" & CStr(y + 1)
                    Case 1
                        Disjunktsioon &= "¬x" & CStr(y + 1)
                End Select
            End If
        Next
        Return Disjunktsioon & ")"
    End Function
    Function TrykiKate(ByVal Kate As Integer) As String
        If Kate = 1 Then
            Return " x|"
        Else
            Return "  |"
        End If
    End Function
    Function TrykiKonjunktsioon(ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As String
        Dim x(3) As Integer
        Dim Konjunktsioon As String
        x(0) = x1
        x(1) = x2
        x(2) = x3
        x(3) = x4
        Konjunktsioon = ""
        For y As Integer = 0 To 3
            Select Case x(y)
                Case 0
                    Konjunktsioon &= "¬x" & CStr(y + 1)
                Case 1
                    Konjunktsioon &= "x" & CStr(y + 1)
            End Select
        Next
        Return Konjunktsioon
    End Function
    Function TrykiNumber(ByVal Nr As Integer) As String
        If Nr < 10 Then
            Return CStr(Nr) & " "
        Else
            Return CStr(Nr)
        End If
    End Function
    Function TrykiTarn(ByVal Vajalik As Integer) As String
        Select Case Vajalik
            Case 0
                Return "*|"
            Case 1
                Return " |"
        End Select
    End Function
    Function TrykiVektor(ByVal x1 As Integer, ByVal x2 As Integer, ByVal x3 As Integer, ByVal x4 As Integer) As String
        Return LogicalToString(x1) & LogicalToString(x2) & LogicalToString(x3) & LogicalToString(x4)
    End Function
    Function Ylejaanud1(ByVal x As Integer) As String
        If x = 0 Then
            Return "2"
        Else
            Return "1"
        End If
    End Function
    Function Ylejaanud2(ByVal x As Integer) As String
        If x < 2 Then
            Return "3"
        Else
            Return "2"
        End If
    End Function
    Function Ylejaanud3(ByVal x As Integer) As String
        If x = 3 Then
            Return "3"
        Else
            Return "4"
        End If
    End Function
End Class
Class KarnaughButton
    Inherits Button
    Dim x, y, z, w As Integer
    Sub New(a As Integer, b As Integer, c As Integer, d As Integer)
        x = a
        y = b
        z = c
        w = d
    End Sub
    Sub KarnaughClick()
        Form1.KarnaughClick(x, y, z, w)
    End Sub
End Class
Module Logic
    Function Glue(x As Integer, y As Integer) As Integer
        Select Case x
            Case 0
                Return 0
            Case 1
                Select Case y
                    Case 0
                        Return 0
                    Case 1
                        Return 1
                    Case 2
                        Return 1
                End Select
            Case 2
                Select Case y
                    Case 0
                        Return 0
                    Case 1
                        Return 1
                    Case 2
                        Return 2
                End Select
        End Select
    End Function
    Function LogicalNot(x As Integer) As Integer
        Select Case x
            Case 0
                Return 1
            Case 1
                Return 0
            Case 2
                Return 2
        End Select
    End Function
End Module
Module PrintLogic
    Function LogicalToString(x As Integer) As String
        Select Case x
            Case 0
                Return "0"
            Case 1
                Return "1"
            Case 2
                Return "-"
        End Select
    End Function
End Module