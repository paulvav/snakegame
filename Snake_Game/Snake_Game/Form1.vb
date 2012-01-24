Public Class Form1
    Dim up As Boolean
    Dim down As Boolean
    Dim moveright As Boolean
    Dim moveleft As Boolean
    Dim game As Boolean = True
    Dim fruitX As Integer
    Dim fruitY As Integer
    Dim score As Integer
    Dim SnakeBit(2) As PictureBox
    Dim last As Integer = 2
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.Up
                If down = True Then
                Else
                    up = True
                    down = False
                    moveleft = False
                    moveright = False
                End If
            Case Keys.Down
                If up = True Then
                Else
                    down = True

                    up = False
                    moveright = False
                    moveleft = False
                End If
            Case Keys.Left
                If moveright = True Then
                Else
                    moveleft = True
                    up = False
                    moveright = False
                    down = False
                End If
            Case Keys.Right
                If moveleft = True Then
                Else
                    moveright = True
                    moveleft = False
                    up = False
                    down = False
                End If
        End Select
    End Sub

    Private Sub time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles time.Tick
        Dim X As Integer
        For X = last To 1 Step -1
            SnakeBit(X).Location = SnakeBit(X - 1).Location
        Next X
        fruitX = Int(Rnd() * 46.5)
        fruitY = Int(Rnd() * 44)
        If up = True Then
            SnakeBit(0).Top -= 10
        ElseIf down = True Then
            SnakeBit(0).Top += 10
        ElseIf moveleft = True Then
            SnakeBit(0).Left -= 10
        ElseIf moveright = True Then
            SnakeBit(0).Left += 10
        End If

        If SnakeBit(0).Top > 440 Or SnakeBit(0).Top < 0 Or SnakeBit(0).Left > 465 Or SnakeBit(0).Left < 0 Then
            Label1.Text = "ballsack"
        End If

        If SnakeBit(0).Location = Fruitpb.Location Then
            Fruitpb.Visible = False
            Fruitpb.Top = fruitY * 10
            Fruitpb.Left = fruitX * 10
            Fruitpb.Visible = True
            score += 1
            Label1.Text = score
            ExtendSnake()
        End If

    End Sub
    Private Sub ExtendSnake()
        Dim ass As New PictureBox
        Me.Controls.Add(ass)
        ass.Width = 10
        ass.Height = 10
        ass.BackColor = Color.Black
        ass.Top = SnakeBit(last).Top
        ass.Left = SnakeBit(last).Left + 12
        last += 1
        ReDim Preserve SnakeBit(last)
        SnakeBit(last) = ass
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As Object, X As Integer
        For Each obj In Me.Controls
            If TypeOf obj Is PictureBox AndAlso obj.tag > "" Then
                X = obj.tag
                SnakeBit(X) = obj
            End If
        Next
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class
