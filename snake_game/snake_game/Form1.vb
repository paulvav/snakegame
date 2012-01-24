Public Class Form1
    Dim up As Boolean
    Dim down As Boolean
    Dim moveright As Boolean
    Dim moveleft As Boolean
    Dim game As Boolean = True
    Dim fruitX As Integer
    Dim fruitY As Integer
    Dim score As Integer
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.Up
                up = True
                down = False
                moveleft = False
                moveright = False
            Case Keys.Down
                down = True
                up = False
                moveright = False
                moveleft = False
            Case Keys.Left
                moveleft = True
                up = False
                moveright = False
                down = False
            Case Keys.Right
                moveright = True
                moveleft = False
                up = False
                down = False
        End Select
    End Sub

    Private Sub time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles time.Tick
        fruitX = Int(Rnd() * 99)
        fruitY = Int(Rnd() * 99)
        If up = True Then
            PictureBox1.Top -= 10
            PictureBox2.Top -= 10
        ElseIf down = True Then
            PictureBox1.Top += 10
            PictureBox2.Top += 10
        ElseIf moveleft = True Then
            PictureBox1.Left -= 10
            PictureBox2.Left -= 10
        ElseIf moveright = True Then
            PictureBox1.Left += 10
            PictureBox2.Left += 10
        End If

        If PictureBox1.Location = Fruitpb.Location Then
            Fruitpb.Visible = False
            Fruitpb.Top = fruitY * 10
            Fruitpb.Left = fruitX * 10
            Fruitpb.Visible = True
            score += 1
            Label1.Text = score
        End If




    End Sub

 

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

   
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        PictureBox2.Location = PictureBox1.Location
    End Sub
End Class
