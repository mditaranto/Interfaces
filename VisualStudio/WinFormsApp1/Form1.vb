Imports System.Runtime.InteropServices.JavaScript.JSType
Imports ClassLibrary1

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click

        Dim nombre = txtNombre.Text

        Dim persona As New clsPersona

        persona.nombre = nombre


        If (String.IsNullOrEmpty(nombre)) Then
            ErrorVacio.Text = "El nombre no puede estar vacío."

        Else
            MessageBox.Show("Hola " & nombre)
            ErrorVacio.Text = ""

        End If

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles ErrorVacio.Click

    End Sub
End Class
