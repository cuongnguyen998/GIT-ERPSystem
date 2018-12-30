Imports ASCore.Objects


Imports ASCore.BusinessLogic
Imports ASCore.GUI
Imports ASCore.Framework
Imports System.Net.Mime.MediaTypeNames
Imports Library_Logic.FrameWorkLibrary
Imports Library_Logic
Imports System.Globalization

Public Class Test_Logic
    Public Sub HRRequestColumnValueChangeHeader(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Try
            Dim r As Hashtable = sender.CurrentRow

            Select Case sender.ColumnName
                Case "Department"
                    Dim Tquery As New TQuery
                    Tquery.From("Department", "DP").Where("Code").Is(r("Department"))
                    r("Department Name") = Tquery.GetValue("Name")
                Case "Position"
                    Dim Tquery As New TQuery
                    Tquery.From("HR Position", "HRP").Where("Code").Is(r("Position"))
                    r("Position Name") = Tquery.GetValue("Name")
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Public Sub InsertColum(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim r As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim strSQL As String
            strSQL = "SELECT A.*
                        FROM [ACA QC Observation Planning Line] A LEFT JOIN [ACA QC Observation Result] B
                        ON A.[Code Plan]=B.[Code Plan] AND A.[Code Class] =B.[Code Class] AND A.[Code Teacher] = B.[Code Teacher]
                        WHERE B.[Code Plan] IS NULL AND A.[Code Plan] = '" & r("Code Plan") & "'     " 'để lấy những dòng chưa lấy
            Dim QuerySelectACA As New TQuery
            QuerySelectACA.SQL(strSQL, "PlanningLine")
            Dim TablePlanningLine As New DataTable
            TablePlanningLine = QuerySelectACA.ToTable


            For Each Trow As DataRow In TablePlanningLine.Rows
                ' Bên trái là bảng chưa có dữ liệu
                ' Bên phải là bảng đã có dữ liệu
                Dim QueryInsert As New TQuery
                QueryInsert.Insert("ACA QC Observation Result")
                QueryInsert.Field("Blocked") = 0
                QueryInsert.Field("Code Class") = Trow("Code Class")
                QueryInsert.Field("Code Plan") = Trow("Code Plan")
                QueryInsert.Field("Code Teacher") = Trow("Code Teacher")
                QueryInsert.Field("Create Date") = CDate(Now)
                QueryInsert.Field("Date Observation") = Trow("Date Observation")
                QueryInsert.Field("Date Posting") = CDate(Now)
                QueryInsert.Field("Employee Code") = ""
                QueryInsert.Field("Last Date Modification") = CDate(Now)
                QueryInsert.Field("Result 1") = ""
                QueryInsert.Field("Result 2") = ""
                QueryInsert.Field("TimeIn") = Trow("TimeIn")
                QueryInsert.Field("TimeOut") = Trow("TimeOut")
                QueryInsert.Field("Type") = ""
                QueryInsert.Field("Login ID") = sender.UserName
                QueryInsert.Execute()
            Next

            TQuery.EndTransaction()
            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString
        End Try
    End Sub
End Class
