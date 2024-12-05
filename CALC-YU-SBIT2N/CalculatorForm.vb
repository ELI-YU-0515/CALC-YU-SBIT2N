Public Class Form1
    Dim equation As String = "" ' To store the full equation for display

    Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim button As Button = CType(sender, Button)
        equation &= button.Text ' Append the number to the equation
        txtDisplay.Text = equation ' Update the display
    End Sub

    Private Sub OperatorButton_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnSubtract.Click, btnMultiply.Click, btnDivide.Click
        Dim button As Button = CType(sender, Button)
        equation &= " " & button.Text & " " ' Append the operator to the equation with spaces for readability
        txtDisplay.Text = equation ' Update the display
    End Sub

    Private Sub EqualsButton_Click(sender As Object, e As EventArgs) Handles btnEquals.Click
        Try
            ' Use DataTable to evaluate the equation
            Dim result As Double = Convert.ToDouble(New DataTable().Compute(equation.Replace("×", "*").Replace("÷", "/"), Nothing))
            txtDisplay.Text = result.ToString() ' Display the result
            equation = result.ToString() ' Update the equation with the result for further calculations
        Catch ex As Exception
            txtDisplay.Text = "Error" ' Handle invalid equations
            equation = "" ' Reset equation
        End Try
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDisplay.Text = "0" ' Reset display
        equation = "" ' Clear the equation
    End Sub

End Class
