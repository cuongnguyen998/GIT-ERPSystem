Imports ASCore.Objects
Imports ASCore.BusinessLogic
Imports ASCore.GUI

Imports System.Globalization
Public Class HumanResourceLogic
    Public Sub EmployeeWorkingArrangement(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim query As New TQuery
            Dim param = sender.Parameters
            Dim query2 As New TQuery
            Dim sqlString As String
            sqlString = "select * from [HR Department] A where A.[Code] = '" & param("FFDepartment") & "' "
            query2.SQL(sqlString, "LitDepartment")
            query.Insert("HR Employee Work Shift Arrangement")
            query.Field("Department") = param("FFDepartment")
            query.Field("Department Name") = query2.GetValue("Name")
            query.Field("Work Shift Code") = param("FFWorkShift")
            query.Field("From Date") = CDate(param("FFFromDate"))
            query.Field("To Date") = CDate(param("FFToDate"))
            query.Field("Login ID") = sender.UserName
            query.Field("Last Modification Date") = DateTime.Now
            query.Execute()
            TQuery.EndTransaction()
            sender.Messager = "Success"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()
        End Try



    End Sub

    Public Sub ColumnValueChangeAutoInsert(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            Dim columnName As String = sender.ColumnName
            Select Case sender.ColumnName
                Case "EmployeeName"
                    Dim query As New TQuery
                    Dim strSQL As String
                    strSQL = "'select a.EmployeeCode, a.FullName from [HR Employee Info] a where a.EmployeeCode = '" & currentRow("EmployeeCode") & "'"
                    query.SQL(strSQL, "EmployeeCodeList")
                    currentRow("EmployeeName") = query.GetValue("FullName")

            End Select
        Catch ex As Exception
        End Try
    End Sub
#Region "Chức năng phần chấm công"

    ''' <summary>
    ''' Hàm đăng ký nghỉ vắng cho nhân viên
    ''' Bấm vào nút "Đăng ký" sẽ lấy toàn bộ dữ liệu của param truyền xuống bảng bên dưới
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub AbsenceSubmit(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim r As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()

            Dim param As Hashtable = sender.Parameters
            Dim getEmployeeName As New TQuery

            'Look up dữ liệu từ bảng HR Employee Info để lấy ra được tên nhân viên, thay vào cột Employee Code ở bên dưới
            Dim str As String = "select a.FullName from [HR Employee Info] a where a.EmployeeCode = '" & param("FFEmployee") & "'"
            getEmployeeName.SQL(str, "EmployeeName")
            Dim query As New TQuery
            query.Insert("HR Employee Absence")
            query.Field("Department Code") = param("FFDepartment")
            query.Field("Employee Code") = getEmployeeName.GetValue("FullName") 'param("FFEmployee")
            query.Field("Absence Code") = param("FFAbsence")
            query.Field("From Date") = CDate(param("FFFromDate"))
            query.Field("To Date") = CDate(param("FFToDate"))
            query.Field("Status") = 0
            query.Field("Login ID") = sender.UserName
            query.Field("Last Modification Date") = DateTime.Now()
            query.Execute()
            TQuery.EndTransaction()

            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()


        End Try
        'Đang có bug, chỉ insert được 1 lần duy nhất
    End Sub
    ''' <summary>
    ''' Duyệt cho nhân viên nghỉ (chỉ quản lý được phân quyền sử dụng)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub ApproveAbsence(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        'Đang có bug - Không thể duyệt được
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            If (sender.UserName Is "Admin") Then
                Dim query As New TQuery
                query.Update("HR Employee Absence")
                query.Field("Status") = 1
                query.Field("Login ID") = sender.UserName
                query.Field("Last Modification Date") = DateTime.Now()
                query.Where("Employee Code").Is(currentRow("Employee Code"))
                query.Execute()
                TQuery.EndTransaction()
                sender.Messager = "Thành công"
            Else
                sender.Messager = "Bạn không có thẩm quyền duyệt đơn này"
                TQuery.EndTransaction()

            End If
        Catch ex As Exception
            sender.Messager = ex.ToString()
            TQuery.RollBack()

        End Try
    End Sub
    Public Sub Disapprove(ByRef sender As TMethodSource, ByRef e As TMethodArgs)

        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()

            Dim query As New TQuery
            query.Insert("HR Employee Absence")
            query.Field("Status") = 2
            query.Field("Login ID") = sender.UserName
            query.Field("Last Modification Date") = DateTime.Now()
            query.Where("Employee Code").Is(currentRow("Employee Code"))
            query.Execute()

            TQuery.EndTransaction()
            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString()
            TQuery.RollBack()

        End Try
    End Sub
    Public Sub HROvertimeSubmit(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()

            Dim param As Hashtable = sender.Parameters
            Dim query As New TQuery
            Dim queryEmployee As New TQuery
            Dim str As String
            str = "select a.EmployeeCode, a.FullName,a.HRPosition,a.HRDeparment from [HR Employee Info] a where a.EmployeeCode = '" & param("FFEmployeeCode") & "'"
            queryEmployee.SQL(str, "EmployeeInfo")
            query.Insert("HR Overtime Form")
            query.Field("EmployeeCode") = param("FFEmployeeCode")
            query.Field("FullName") = queryEmployee.GetValue("FullName")
            query.Field("HRPosition") = queryEmployee.GetValue("HRPosition")
            query.Field("HRDepartment") = queryEmployee.GetValue("HRDeparment")
            query.Field("FromDate") = CDate(param("FFFromDate"))
            query.Field("ToDate") = CDate(param("FFToDate"))
            query.Field("ReasonForOT") = param("FFReasonOT")
            query.Field("PersonApprove") = ""
            query.Field("PostingDate") = DateTime.Now
            query.Field("Status") = 0
            query.Field("LoginID") = sender.UserName
            query.Execute()
            TQuery.EndTransaction()
            sender.Messager = "Thành công"

        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()

        End Try
    End Sub
    Public Sub ApproveOT(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim param As Hashtable = sender.Parameters
            Dim query As New TQuery
            Dim checkStrirng As String
            checkStrirng = param("FFReasonNotApprove")
            If (sender.UserName = "Admin") Then
                query.Update("HR Overtime Form")
                query.Field("PersonApprove") = sender.UserName
                If checkStrirng = "" Then
                    query.Field("ReasonNotApprove") = ""
                End If
                'query.Field("ReasonNotApprove") = param("FFReasonNotApprove")
                query.Field("Status") = 1
                query.Where("EmployeeCode").Is(currentRow("EmployeeCode"))
                query.Execute()
                TQuery.EndTransaction()
                sender.Messager = "Thành công"
            Else
                sender.Messager = "Bạn không có thẩm quyền thực hiện chức năng này"
            End If
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()

        End Try
    End Sub



#End Region


#Region "Tuyển dụng"
    'Quy trình hoạt động: Khi thêm nhân viên mới, truy cập "Danh mục nhân sự" --> "Hồ sơ nhân viên" --> Điền thông tin vào ấn nút thêm nhân viên mới
    'Toàn bộ thông tin nhân viên sẽ được điền vào những bảng có liên quan, có thể xem thông tin chi tiết bằng cách chuyển đổi giữa các tab phía dưới
    Public Sub InsertEmployeeDetailInfo(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim queryInsert As New TQuery
            Dim queryInsertContact As New TQuery


            'Insert thông tin nhân viên vào bảng Thông tin chi tiết
            queryInsert.Insert("HR Employee Detail Info")
            queryInsert.Field("EmployeeCode") = currentRow("EmployeeCode")
            queryInsert.Field("FullName") = currentRow("FullName")
            queryInsert.Field("Gender") = currentRow("Gender")
            queryInsert.Field("DateOfBirth") = currentRow("BirthDate")
            queryInsert.Field("Address") = currentRow("Address")
            queryInsert.Field("HRPosition") = currentRow("HRPosition")
            queryInsert.Field("HRDepartment") = currentRow("HRDeparment")
            queryInsert.Field("PersonalID") = currentRow("PersonalID")
            queryInsert.Field("PermissionDate") = currentRow("PermissionDate")
            queryInsert.Field("PermissionPlace") = currentRow("PermissionPlace")
            queryInsert.Field("MaritalStatus") = currentRow("MaritalStatus")
            queryInsert.Execute()

            'Insert thông tin nhân viên vào bảng Thông tin liên lạc
            queryInsertContact.Insert("HR Employee Contact Info")
            queryInsertContact.Field("EmployeeCode") = currentRow("EmployeeCode")
            queryInsertContact.Field("Address") = currentRow("Address")
            queryInsertContact.Field("PhoneNumber") = currentRow("PhoneNumber")
            queryInsertContact.Field("Email") = currentRow("Email")
            queryInsertContact.Execute()

            TQuery.EndTransaction()
            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()
        End Try
    End Sub

    ''' <summary>
    ''' Tự động nối chuỗi họ và tên
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub AutoConcatFullName(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            Select Case sender.ColumnName
                Case "HRPosition"
                    Dim query As New TQuery
                    Dim str As String
                    str = "select NumberOfDayOff from [HR Position] where Code = '" & currentRow("HRPosition") & "'"
                    query.SQL(str, "DayOffList")
                    currentRow("DaysOff") = query.GetValue("NumberOfDayOff")
            End Select
            currentRow("FullName") = String.Concat(currentRow("FirstName"), " ", currentRow("LastName"))

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Thay đổi thông tin nhân viên
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub EditEmployeeInfo(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim queryInsert As New TQuery
            Dim queryInsertContact As New TQuery


            'Insert thông tin nhân viên vào bảng Thông tin chi tiết
            queryInsert.Update("HR Employee Detail Info")
            'queryInsert.Field("EmployeeCode") = currentRow("EmployeeCode")
            queryInsert.Field("FullName") = currentRow("FullName")
            queryInsert.Field("Gender") = currentRow("Gender")
            queryInsert.Field("DateOfBirth") = currentRow("BirthDate")
            queryInsert.Field("Address") = currentRow("Address")
            queryInsert.Field("HRPosition") = currentRow("HRPosition")
            queryInsert.Field("HRDepartment") = currentRow("HRDeparment")
            queryInsert.Field("PersonalID") = currentRow("PersonalID")
            queryInsert.Field("PermissionDate") = currentRow("PermissionDate")
            queryInsert.Field("PermissionPlace") = currentRow("PermissionPlace")
            queryInsert.Field("MaritalStatus") = currentRow("MaritalStatus")
            queryInsert.Where("EmployeeCode").Is(currentRow("EmployeeCode"))
            queryInsert.Execute()

            'Insert thông tin nhân viên vào bảng Thông tin liên lạc
            queryInsertContact.Update("HR Employee Contact Info")
            'queryInsertContact.Field("EmployeeCode") = currentRow("EmployeeCode")
            queryInsertContact.Field("Address") = currentRow("Address")
            queryInsertContact.Field("PhoneNumber") = currentRow("PhoneNumber")
            queryInsertContact.Field("Email") = currentRow("Email")
            queryInsertContact.Where("EmployeeCode").Is(currentRow("EmployeeCode"))
            queryInsertContact.Execute()

            TQuery.EndTransaction()
            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()
        End Try
    End Sub

    Public Sub InviteInterview1(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim query As New TQuery
            query.Update("HR Candidate Info Header")
            query.Field("Status") = 1
            query.Where("CandidateCode").Is(currentRow("CandidateCode"))
            'Phần này để trống, sau này tạo được email server thì thêm code vào đây để tự động gửi email cho ứng viên
            '...
            query.Execute()
            TQuery.EndTransaction()
            sender.Messager = "Đã mời phỏng vấn lần 1. Cập nhật trạng thái ứng viên ở cột status"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()

        End Try
    End Sub

    Public Sub InviteInterview2(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim query As New TQuery
            query.Update("HR Candidate Info Header")
            query.Field("Status") = 2
            query.Where("CandidateCode").Is(currentRow("CandidateCode"))
            'Phần này để trống, sau này tạo được email server thì thêm code vào đây để tự động gửi email cho ứng viên
            '...
            query.Execute()
            TQuery.EndTransaction()
            sender.Messager = "Đã mời phỏng vấn lần 2. Cập nhật trạng thái ứng viên ở cột status"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()

        End Try
    End Sub

    Public Sub ApproveCandidate(ByRef sender As TMethodSource, ByRef e As TMethodArgs)
        Dim currentRow As Hashtable = sender.CurrentRow
        Try
            TQuery.BeginTransaction()
            Dim query As New TQuery
            query.Update("HR Candidate Info Header")
            query.Field("Status") = 3
            query.Where("CandidateCode").Is(currentRow("CandidateCode"))
            query.Execute()


            Dim str As String = "select a.CandidateCode, a.FullName, a.RecruitmentPeriod,a.HRPosition,a.Department from [HR Candidate Info Header] a where a.Status = 3"
            Dim queryInsert As New TQuery
            Dim query1 As New TQuery
            query1.SQL(str, "CandidateInfo")
            queryInsert.Insert("HR Recruit History")
            queryInsert.Field("CandidateCode") = query1.GetValue("CandidateCode")
            queryInsert.Field("FullName") = query1.GetValue("FullName")
            queryInsert.Field("RecruitmentPeriod") = query1.GetValue("RecruitmentPeriod")
            queryInsert.Field("Department") = query1.GetValue("Department")
            queryInsert.Field("HRPosition") = query1.GetValue("HRPosition")
            queryInsert.Execute()
            TQuery.EndTransaction()
            sender.Messager = "Thành công"
        Catch ex As Exception
            sender.Messager = ex.ToString
            TQuery.RollBack()
        End Try
    End Sub
#End Region

End Class
