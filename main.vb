Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net

Public Class Main
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal Iparam As Integer) As Integer

#Region "moving form  & opacity"
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        If MousePosition.X < 0 Or MousePosition.Y < 0 Then
            Me.Opacity = 0.8
        End If
    End Sub
    Private Sub Main_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Main_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Me.Opacity = 0.8
    End Sub
    Private Sub Main_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Me.Opacity = 100
    End Sub
    Private Sub Main_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Main_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        drag = False
        Me.Opacity = 0.8
    End Sub

#End Region

#Region "btn proprety"
    Private Sub Pic_close_Click(sender As Object, e As EventArgs) Handles Pic_close.Click
        Me.Close()
    End Sub
    Private Sub Pic_minimiz_Click(sender As Object, e As EventArgs) Handles Pic_minimiz.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'btn home
    Private Sub Btn_Home_Click(sender As Object, e As EventArgs) Handles Btn_Home.Click
        Dim url As String = ""
        Process.Start(url)
    End Sub
    Private Sub Btn_Home_MouseLeave(sender As Object, e As EventArgs) Handles Btn_Home.MouseLeave
        Btn_Home.Location = New System.Drawing.Point(-73, 31)
    End Sub
    Private Sub Btn_Home_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_Home.MouseMove
        Btn_Home.Location = New System.Drawing.Point(-7, 31)
    End Sub

    'btn how to  
    Private Sub Btn_Howto_Click(sender As Object, e As EventArgs) Handles Btn_Howto.Click
        Dim url As String = "https://github.com/sadik-fattah/Apom"
        Process.Start(url)
    End Sub
    Private Sub Btn_Howto_MouseLeave(sender As Object, e As EventArgs) Handles Btn_Howto.MouseLeave
        Btn_Howto.Location = New System.Drawing.Point(-73, 60)

    End Sub
    Private Sub Btn_Howto_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_Howto.MouseMove
        Btn_Howto.Location = New System.Drawing.Point(-7, 60)
    End Sub
    'btn faedbeak
    Private Sub Btn_FaedBeak_Click(sender As Object, e As EventArgs) Handles Btn_FaedBeak.Click
        Dim mail As String = "mailto:exemple@domain.com"
        Process.Start(mail)
    End Sub
    Private Sub Btn_FaedBeak_MouseLeave(sender As Object, e As EventArgs) Handles Btn_FaedBeak.MouseLeave
        Btn_FaedBeak.Location = New System.Drawing.Point(-73, 89)
    End Sub
    Private Sub Btn_FaedBeak_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_FaedBeak.MouseMove
        Btn_FaedBeak.Location = New System.Drawing.Point(-7, 89)
    End Sub
    'btn facebook
    Private Sub Btn_fb_Click(sender As Object, e As EventArgs) Handles Btn_fb.Click
        Dim url As String = "https://www.facebook.com/sadik.fattah.7"
        Process.Start(url)
    End Sub
    Private Sub Btn_fb_MouseLeave(sender As Object, e As EventArgs) Handles Btn_fb.MouseLeave
        Btn_fb.Location = New System.Drawing.Point(-73, 169)
    End Sub
    Private Sub Btn_fb_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_fb.MouseMove
        Btn_fb.Location = New System.Drawing.Point(-7, 169)
    End Sub
    'btn twitter 
    Private Sub Btn_twitter_Click(sender As Object, e As EventArgs) Handles Btn_twitter.Click
        Dim url As String = "https://twitter.com/SadikFattah"
        Process.Start(url)
    End Sub
    Private Sub Btn_twitter_MouseLeave(sender As Object, e As EventArgs) Handles Btn_twitter.MouseLeave
        Btn_twitter.Location = New System.Drawing.Point(-73, 198)
    End Sub
    Private Sub Btn_twitter_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_twitter.MouseMove
        Btn_twitter.Location = New System.Drawing.Point(-7, 198)
    End Sub
    'btn youtube
    Private Sub Btn_youtube_Click(sender As Object, e As EventArgs) Handles Btn_youtube.Click
        Dim url As String = "https://www.youtube.com/channel/UCZr2VGmXdJ-yGLUZztCVFGw"
        Process.Start(url)
    End Sub
    Private Sub Btn_youtube_MouseLeave(sender As Object, e As EventArgs) Handles Btn_youtube.MouseLeave
        Btn_youtube.Location = New System.Drawing.Point(-73, 227)
    End Sub
    Private Sub Btn_youtube_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_youtube.MouseMove
        Btn_youtube.Location = New System.Drawing.Point(-7, 227)
    End Sub
    'btn About
    Private Sub Btn_About_Click(sender As Object, e As EventArgs) Handles Btn_About.Click
        Dim url As String = "http://www.guercif.cf/2016/05/about-as.html"
        Process.Start(url)
    End Sub
    Private Sub Btn_About_MouseLeave(sender As Object, e As EventArgs) Handles Btn_About.MouseLeave
        Btn_About.Location = New System.Drawing.Point(-73, 309)
    End Sub
    Private Sub Btn_About_MouseMove(sender As Object, e As MouseEventArgs) Handles Btn_About.MouseMove
        Btn_About.Location = New System.Drawing.Point(-7, 309)
    End Sub

#End Region


#Region "get hach"
    Function md5_hash(ByVal file_name As String)
        Return hash_generator("md5", file_name)
    End Function
    Function sha_1(ByVal file_name As String)
        Return hash_generator("sha1", file_name)
    End Function
    Function sha_256(ByVal file_name As String)
        Return hash_generator("sha256", file_name)
    End Function
#End Region

#Region "hash_generator & PrintByteArray"
    Function hash_generator(ByRef hash_type As String, ByRef file_name As String)
        Dim hash
        If hash_type.ToLower = "md5" Then
            hash = MD5.Create
        ElseIf hash_type.ToLower = "sha1" Then
            hash = SHA1.Create
        ElseIf hash_type.ToLower = "sha256" Then
            hash = SHA256.Create
        Else
            MessageBox.Show("Unknown value!!!")
            Return False
        End If
        Dim hashValue() As Byte

        Dim filestream As FileStream = File.OpenRead(file_name)
        filestream.Position = 0
        hashValue = hash.ComputeHash(filestream)
        Dim hash_hex = PrintByteArray(hashValue)

        filestream.Close()

        Return hash_hex
    End Function
    Public Function PrintByteArray(ByRef array() As Byte)

        Dim hex_value As String = ""

        Dim i As Integer
        For i = 0 To array.Length - 1

            hex_value += array(i).ToString("x2")
        Next i

        Return hex_value.ToLower
    End Function
#End Region
    Private Sub Btn_Load_Click(sender As Object, e As EventArgs) Handles Btn_Load.Click
        SendMessage(ProgressBar1.Handle, 1040, 3, 0)
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 40
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim path As String = OpenFileDialog1.FileName
            TextBox1.Text = path
            Dim sample As String
            sample = md5_hash(path)
            Label_md5.Text = md5_hash(path)
            Label_sha1.Text = sha_1(path)
            Label_sha256.Text = sha_256(path)

            Using f As System.IO.FileStream = System.IO.File.OpenRead("md5.txt")
                Using s As System.IO.StreamReader = New System.IO.StreamReader(f)
                    While Not s.EndOfStream
                        Dim line As String = s.ReadLine
                        If (line = sample) Then

                            Label_result.Text = "File Infected!"
                            Label_result.ForeColor = Color.Red
                            Timer2.Enabled = True
                            Timer2.Start()

                        Else

                            Label_result.Text = "The File Clean!"
                            Label_result.ForeColor = Color.Green
                            'Timer2.Enabled = True
                           '' Timer2.Start()
                        End If
                    End While
                End Using
            End Using
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(+1)
        If ProgressBar1.Value = 35 Then
            Label_md5.Visible = True
        ElseIf ProgressBar1.Value = 70 Then
            Label_sha1.Visible = True
        ElseIf ProgressBar1.Value = 100 Then
            Label_sha256.Visible = True
            Timer1.Stop()
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        PopUp.Show()
    End Sub

    Private Sub Main_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
