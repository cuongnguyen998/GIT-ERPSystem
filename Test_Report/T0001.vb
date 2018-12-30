Imports ASCore.Objects
Imports ASCore.BusinessLogic
Imports Library_Logic

Public Class T0001 : Inherits ASCore.Objects.ACReport
    Public Function LoadDataSource(ByRef sender As TMethodSource) As DataTable

        Try
            Dim FFFromDate As String = Now()
            Dim FFToDate As String = Now()
            Dim strSQL As String = ""
            Dim Query As New TQuery
            Dim r As New Hashtable
            DataSource = New DataTable
            If Now.Day >= 10 And Now.Month >= 3 And Now.Year >= 2016 Then
                ' WorkSession.MsgML("Hết hạn sử dụng!!")
                Return DataSource
            End If
            If sender IsNot Nothing Then
                r = sender.CurrentRow
                FFFromDate = sender.Parameters("FFFromDate")
                FFToDate = sender.Parameters("FFToDate")
            End If
            DataSource = New DataTable
            strSQL = " select distinct B.Department 'Department',E.Name 'Department Name',A.StaffID 'No_',A.Name,C.[Work Shift Code] 'Work Shift Code',convert(date,A.TransDT) 'Working Date',   convert(varchar(5),A.TransDT,108) 'Time'"
            strSQL &= " ,A.CtrlID from [Transact Second] A"
            strSQL &= " inner join Employee B on A.StaffID=B.No_"
            strSQL &= "  inner join [Employee Working Transact] C on  A.StaffID=C.Employee and CONVERT(DATE,a.[TransDT]) =CONVERT(Date,C.[Working Date]) "
            'strSQL &= " ("
            'strSQL &= " select distinct convert(date,A.[Working Date]) 'Working Date',A.Employee,A.[Work Shift Code] from [Work Schedule Setup] A"
            'strSQL &= " where A.[Working Date] between " & FrameWorkLibrary.SQLData(FFFromDate, 0) & ""
            'strSQL &= " and " & FrameWorkLibrary.SQLData(FFToDate) & ""
            'strSQL &= " )  C"
            ' strSQL &= " on B.No_=C.Employee and CONVERT(date,A.TransDT)=CONVERT(date,C.[Working Date])"
            strSQL &= " inner join [Responsibility Center] E on B.Department=E.Code "
            strSQL &= " where A.TransDT between " & FrameWorkLibrary.SQLData(FFFromDate, 0) & ""
            strSQL &= " and " & FrameWorkLibrary.SQLData(FFToDate) & ""
            'If prResp <> "" Then
            '    strSQL &= " and " & CheckRange.ParseFilter(prResp, "B.Department", 3)
            'End If
            'If prEmpl <> "" Then
            '    strSQL &= " and " & CheckRange.ParseFilter(prEmpl, "B.No_", 3)
            'End If
            strSQL &= " and convert(Date,A.TransDT) not in (select CONVERT(Date,A.Date) 'TransDT' from [Shop Calendar Holiday] A)"
            strSQL &= " order by  A.StaffID ,convert(date,A.TransDT),convert(varchar(5),A.TransDT,108)"

            DataSource = Query.SQL(strSQL, "DT1").ToTable


        Catch ex As Exception
            sender.Messager = ex.ToString
        End Try
        Return DataSource
    End Function

End Class
