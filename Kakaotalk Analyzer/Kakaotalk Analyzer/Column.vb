'/*************************************************************************
'
'   Copyright (C) 2017. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Module Column

    Declare Unicode Function StrCmpLogicalW Lib "shlwapi.dll" (ByVal s1 As String, ByVal s2 As String) As Integer

    Public Function ComparePath(addr1 As String, addr2 As String) As Integer
        Return StrCmpLogicalW(addr1, addr2)
    End Function

    Public Class PathComparer
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return StrCmpLogicalW(x, y)
        End Function
    End Class
    Public Function GetPathComparer() As IComparer
        Return CType(New PathComparer(), IComparer)
    End Function

    'https://msdn.microsoft.com/ko-kr/library/ms229643(v=vs.90).aspx
    Public Class SortWrapper
        Friend sortItem As ListViewItem
        Friend sortColumn As Integer

        Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
            sortItem = Item
            sortColumn = iColumn
        End Sub

        Public ReadOnly Property [Text]() As String
            Get
                Return sortItem.SubItems(sortColumn).Text
            End Get
        End Property

        Public Class SortComparer
            Implements IComparer
            Private ascending As Boolean

            Public Sub New(ByVal asc As Boolean)
                Me.ascending = asc
            End Sub

            Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

                If IsNothing(x) Or IsNothing(y) Then Return 0

                Dim xItem As SortWrapper = CType(x, SortWrapper)
                Dim yItem As SortWrapper = CType(y, SortWrapper)

                Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
                Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text

                If xText.EndsWith(" KB") AndAlso yText.EndsWith(" KB") Then
                    Dim xNum As String = xText.Substring(0, xText.Length - 3).Replace(",", "")
                    Dim yNum As String = yText.Substring(0, yText.Length - 3).Replace(",", "")

                    If IsNumeric(xNum) AndAlso IsNumeric(yNum) Then
                        Return IIf(Convert.ToInt32(xNum) >= Convert.ToInt32(yNum), 1, -1) * IIf(Me.ascending, 1, -1)
                    End If
                End If

                Return ComparePath(xText, yText) * IIf(Me.ascending, 1, -1)
            End Function
        End Class
    End Class

    Public Class ColHeader
        Inherits ColumnHeader
        Public ascending As Boolean

        Public Sub New(ByVal [text] As String, ByVal width As Integer, ByVal align As HorizontalAlignment, ByVal asc As Boolean)
            Me.Text = [text]
            Me.Width = width
            Me.TextAlign = align
            Me.ascending = asc
        End Sub
    End Class

End Module
