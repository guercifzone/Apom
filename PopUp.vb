Public Class PopUp

    Private Sub Pic_close_Click(sender As Object, e As EventArgs) Handles Pic_close.Click
        Me.Close()
    End Sub


    Private Sub PopUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x, y As String
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        x = Screen.PrimaryScreen.WorkingArea.Width

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y + 20)
        Loop

        My.Computer.Audio.Play(My.Resources.navy_alarm, AudioPlayMode.Background)
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim email As String = "mailto:exemple@domain.com"
        Process.Start(email)
    End Sub
End Class