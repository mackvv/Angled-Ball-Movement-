Public Class Form1

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Left
                If Me.picBar.Bounds.IntersectsWith(Me.borderLeft.Bounds) Then
                Else
                    Me.picBar.Left -= 5
                End If

            Case Keys.Right
                If Me.picBar.Bounds.IntersectsWith(Me.borderRight.Bounds) Then
                Else
                    Me.picBar.Left += 5
                End If
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim color As Integer
        Dim i As Integer

        color = RndInt(3, 1)
        For i = 1 To 20
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.LemonChiffon
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Purple
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.Pink
            End If
        Next i

        color = RndInt(3, 1)
        For i = 1 To 20 Step 2
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.LimeGreen
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Orange
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.SpringGreen
            End If
        Next i

        color = RndInt(3, 1)
        For i = 1 To 20 Step 3
            If color = 1 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Yellow
            ElseIf color = 2 Then
                Me.Controls("brick" & i).BackColor = Drawing.Color.Lavender
            Else
                Me.Controls("brick" & i).BackColor = Drawing.Color.Red
            End If
        Next i
    End Sub

    Function RndInt(ByVal HighNum As Integer, ByVal LowNum As Integer) As Integer
        'returns random number
        Dim randomNum As Integer

        Randomize()
        randomNum = Int((HighNum - LowNum + 1) * Rnd()) + LowNum

        Return randomNum
    End Function

    Private Sub tmrMoveBall_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMoveBall.Tick
        Static UDdirection As String
        Static LRdirection As String

        If Me.picBall.Bounds.IntersectsWith(Me.borderLeft.Bounds) Then
            LRdirection = "right"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderRight.Bounds) Then
            LRdirection = "left"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderTop.Bounds) Then
            UDdirection = "down"
        End If

        If Me.picBall.Bounds.IntersectsWith(Me.borderBottom.Bounds) Then
            picBall.Location = New Point(24, 171)
        End If

        For i = 1 To 20
            If Me.picBall.Bounds.IntersectsWith(Me.Controls("brick" & i).Bounds) Then
                UDdirection = "down"
                Me.Controls("brick" & i).Visible = False
            End If

            If LRdirection = "left" Then
                LRdirection = "left"
            Else
                LRdirection = "right"
            End If
        Next i

        If Me.picBall.Bounds.IntersectsWith(Me.picBar.Bounds) Then
            If LRdirection = "left" Then
                LRdirection = "left"
            Else
                LRdirection = "right"
            End If

            UDdirection = "up"
        End If


        If UDdirection = "up" Then
            picBall.Top = 1
        Else
            picBall.Top += 1
        End If

        If LRdirection = "left" Then
            picBall.Left -= 1
        Else
            picBall.Left += 1
        End If
    End Sub
End Class
