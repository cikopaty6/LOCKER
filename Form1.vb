Imports System.Security.AccessControl
Imports System.IO
Public Class Form1

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim folder As New FolderBrowserDialog
        If folder.ShowDialog = DialogResult.OK Then
            TextBox1.Text = folder.SelectedPath


        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("pick a file first")
        End If

        Dim fs As FileSystemSecurity = File.GetAccessControl(TextBox1.Text)
            fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(TextBox1.Text, fs)
        MsgBox("file locked")



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim fs As FileSystemSecurity = File.GetAccessControl(TextBox1.Text)
        fs.RemoveAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(TextBox1.Text, fs)
        MsgBox("file unlocked")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("pick a file first")
        End If
        IO.File.SetAttributes(TextBox1.Text, IO.FileAttributes.Hidden)
        MsgBox("hidden")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("pick a file first")
        End If
        IO.File.SetAttributes(TextBox1.Text, IO.FileAttributes.Normal)
        MsgBox("UN/hidden")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
