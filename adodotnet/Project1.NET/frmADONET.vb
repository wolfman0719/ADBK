Imports Microsoft.Data.Odbc

Public Class frmADONET
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents txtDOB As System.Windows.Forms.TextBox
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblIDValue As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtTELO As System.Windows.Forms.TextBox
    Friend WithEvents txtADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtTELH As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnMoveLast = New System.Windows.Forms.Button
        Me.btnMoveNext = New System.Windows.Forms.Button
        Me.btnMovePrevious = New System.Windows.Forms.Button
        Me.btnMoveFirst = New System.Windows.Forms.Button
        Me.txtTELO = New System.Windows.Forms.TextBox
        Me.lblState = New System.Windows.Forms.Label
        Me.txtTELH = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.txtADDRESS = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.txtDOB = New System.Windows.Forms.TextBox
        Me.lblDOB = New System.Windows.Forms.Label
        Me.lblIDValue = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(305, 170)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(104, 21)
        Me.btnDelete.TabIndex = 50
        Me.btnDelete.Text = "削除"
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(201, 170)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(104, 21)
        Me.btnUpdate.TabIndex = 49
        Me.btnUpdate.Text = "更新"
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(97, 170)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(104, 21)
        Me.btnAddNew.TabIndex = 48
        Me.btnAddNew.Text = "追加"
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Location = New System.Drawing.Point(361, 140)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(104, 22)
        Me.btnMoveLast.TabIndex = 47
        Me.btnMoveLast.Text = "最後のレコード"
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Location = New System.Drawing.Point(257, 140)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(104, 22)
        Me.btnMoveNext.TabIndex = 46
        Me.btnMoveNext.Text = "次に移動"
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Location = New System.Drawing.Point(153, 140)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(104, 22)
        Me.btnMovePrevious.TabIndex = 45
        Me.btnMovePrevious.Text = "１つ前に移動"
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Location = New System.Drawing.Point(49, 140)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(104, 22)
        Me.btnMoveFirst.TabIndex = 44
        Me.btnMoveFirst.Text = "最初のレコード"
        '
        'txtTELO
        '
        Me.txtTELO.Location = New System.Drawing.Point(369, 96)
        Me.txtTELO.Name = "txtTELO"
        Me.txtTELO.Size = New System.Drawing.Size(120, 19)
        Me.txtTELO.TabIndex = 43
        Me.txtTELO.Text = ""
        '
        'lblState
        '
        Me.lblState.Location = New System.Drawing.Point(257, 96)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(100, 21)
        Me.lblState.TabIndex = 35
        Me.lblState.Text = "その他電話番号:"
        '
        'txtTELH
        '
        Me.txtTELH.Location = New System.Drawing.Point(369, 66)
        Me.txtTELH.Name = "txtTELH"
        Me.txtTELH.Size = New System.Drawing.Size(120, 19)
        Me.txtTELH.TabIndex = 42
        Me.txtTELH.Text = ""
        '
        'lblCity
        '
        Me.lblCity.Location = New System.Drawing.Point(257, 66)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(100, 22)
        Me.lblCity.TabIndex = 34
        Me.lblCity.Text = "自宅電話番号:"
        '
        'txtADDRESS
        '
        Me.txtADDRESS.Location = New System.Drawing.Point(312, 37)
        Me.txtADDRESS.Name = "txtADDRESS"
        Me.txtADDRESS.Size = New System.Drawing.Size(264, 19)
        Me.txtADDRESS.TabIndex = 41
        Me.txtADDRESS.Text = ""
        '
        'lbl
        '
        Me.lbl.Location = New System.Drawing.Point(257, 37)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(47, 21)
        Me.lbl.TabIndex = 32
        Me.lbl.Text = "住所:"
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(129, 96)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(120, 19)
        Me.txtDOB.TabIndex = 40
        Me.txtDOB.Text = ""
        '
        'lblDOB
        '
        Me.lblDOB.Location = New System.Drawing.Point(17, 96)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(100, 21)
        Me.lblDOB.TabIndex = 33
        Me.lblDOB.Text = "誕生日:"
        '
        'lblIDValue
        '
        Me.lblIDValue.Location = New System.Drawing.Point(129, 37)
        Me.lblIDValue.Name = "lblIDValue"
        Me.lblIDValue.Size = New System.Drawing.Size(100, 21)
        Me.lblIDValue.TabIndex = 39
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(17, 37)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(100, 21)
        Me.lblID.TabIndex = 38
        Me.lblID.Text = "ID:"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(17, 66)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(100, 22)
        Me.lblName.TabIndex = 36
        Me.lblName.Text = "名前:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(129, 66)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(120, 19)
        Me.txtName.TabIndex = 37
        Me.txtName.Text = ""
        '
        'frmADONET
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(592, 245)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnMoveLast)
        Me.Controls.Add(Me.btnMoveNext)
        Me.Controls.Add(Me.btnMovePrevious)
        Me.Controls.Add(Me.btnMoveFirst)
        Me.Controls.Add(Me.txtTELO)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.txtTELH)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.txtADDRESS)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.txtDOB)
        Me.Controls.Add(Me.lblDOB)
        Me.Controls.Add(Me.lblIDValue)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Name = "frmADONET"
        Me.Text = "ADBK ADO.NET"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim cnCache As OdbcConnection
    Dim spCache As OdbcCommand
    Dim daCache As OdbcDataAdapter
    Dim txCache As OdbcTransaction
    Dim dsCache As DataSet
    Dim dtCache As DataTable
    Dim drCache As DataRow
    Dim drIndex As Integer

    Private Sub frmADONET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cnCache = New OdbcConnection("DSN=CacheISJSAMPLES")
            cnCache.Open()

            txCache = cnCache.BeginTransaction(IsolationLevel.ReadCommitted)

            dsCache = New DataSet()
            daCache = New OdbcDataAdapter()
            daCache.SelectCommand = New OdbcCommand("Select AID, ANAME, ABTHDAY, ASTREET , APHHOME , APHOTH1, AAGE, AZIP from ADBK", cnCache, txCache)
            daCache.Fill(dsCache, "ADBK")

            dtCache = dsCache.Tables("ADBK")

            If (dtCache.Rows.Count > 0) Then
                drIndex = 0
                drCache = dtCache.Rows(drIndex)

                lblIDValue.Text = drCache.Item("AID")
                txtName.Text = drCache.Item("ANAME")
                txtDOB.Text = drCache.Item("ABTHDAY")
                txtADDRESS.Text = drCache.Item("ASTREET")
                txtTELH.Text = drCache.Item("APHHOME")
                txtTELO.Text = drCache.Item("APHOTH1")

                btnUpdate.Enabled = True
                btnDelete.Enabled = True

                txCache.Commit()
            End If
        Catch eLoad As Exception
            MessageBox.Show("An error has occurred:  " + eLoad.Message)

            txCache.Rollback()

            Application.Exit()
        End Try
    End Sub

    Private Sub btnMoveFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveFirst.Click
        Try
            If (dtCache.Rows.Count = 0) Then
                Exit Sub
            End If

            drIndex = 0
            drCache = dtCache.Rows(drIndex)

            lblIDValue.Text = drCache.Item("AID")
            txtName.Text = drCache.Item("ANAME")
            txtDOB.Text = drCache.Item("ABTHDAY")
            txtADDRESS.Text = drCache.Item("ASTREET")
            txtTELH.Text = drCache.Item("APHHOME")
            txtTELO.Text = drCache.Item("APHOTH1")
        Catch eFirst As Exception
            MessageBox.Show("An error has occurred:  " + eFirst.Message)
        End Try
    End Sub

    Private Sub btnMovePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovePrevious.Click
        Try
            If (drIndex > 0) Then
                drIndex -= 1
            Else
                Exit Sub
            End If

            drCache = dtCache.Rows(drIndex)

            lblIDValue.Text = drCache.Item("AID")
            txtName.Text = drCache.Item("ANAME")
            txtDOB.Text = drCache.Item("ABTHDAY")
            txtADDRESS.Text = drCache.Item("ASTREET")
            txtTELH.Text = drCache.Item("APHHOME")
            txtTELO.Text = drCache.Item("APHOTH1")
        Catch ePrevious As Exception
            MessageBox.Show("An error has occurred:  " + ePrevious.Message)
        End Try
    End Sub

    Private Sub btnMoveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveNext.Click
        Try
            If (drIndex < (dtCache.Rows.Count - 1)) Then
                drIndex += 1
            Else
                Exit Sub
            End If

            drCache = dtCache.Rows(drIndex)

            lblIDValue.Text = drCache.Item("AID")
            txtName.Text = drCache.Item("ANAME")
            txtDOB.Text = drCache.Item("ABTHDAY")
            txtADDRESS.Text = drCache.Item("ASTREET")
            txtTELH.Text = drCache.Item("APHHOME")
            txtTELO.Text = drCache.Item("APHOTH1")
        Catch eNext As Exception
            MessageBox.Show("An error has occurred:  " + eNext.Message)
        End Try
    End Sub

    Private Sub btnMoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveLast.Click
        Try
            If (dtCache.Rows.Count = 0) Then
                Exit Sub
            End If

            drIndex = dtCache.Rows.Count - 1
            drCache = dtCache.Rows(drIndex)

            lblIDValue.Text = drCache.Item("AID")
            txtName.Text = drCache.Item("ANAME")
            txtDOB.Text = drCache.Item("ABTHDAY")
            txtADDRESS.Text = drCache.Item("ASTREET")
            txtTELH.Text = drCache.Item("APHHOME")
            txtTELO.Text = drCache.Item("APHOTH1")
        Catch eLast As Exception
            MessageBox.Show("An error has occurred:  " + eLast.Message)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Try
            txCache = cnCache.BeginTransaction(System.Data.IsolationLevel.Unspecified)
            spCache = New OdbcCommand("Insert into ADBK(ANAME, ABTHDAY, ASTREET, APHHOME, APHOTH1) Values(?, ?, ?, ?, ?)", cnCache, txCache)

            Dim pName As New OdbcParameter()
            pName.ParameterName = "ANAME"
            pName.OdbcType = OdbcType.VarChar
            pName.Direction = ParameterDirection.Input
            pName.Value = txtName.Text

            Dim pDOB As New OdbcParameter()
            pDOB.ParameterName = "ABTHDAY"
            pDOB.OdbcType = OdbcType.Date
            pDOB.Direction = ParameterDirection.Input
            pDOB.Value = txtDOB.Text

            Dim pSTREET As New OdbcParameter
            pSTREET.ParameterName = "ASTREET"
            pSTREET.OdbcType = OdbcType.VarChar
            pSTREET.Direction = ParameterDirection.Input
            pSTREET.Value = txtADDRESS.Text

            Dim pPHHOME As New OdbcParameter
            pPHHOME.ParameterName = "APHHOME"
            pPHHOME.OdbcType = OdbcType.VarChar
            pPHHOME.Direction = ParameterDirection.Input
            pPHHOME.Value = txtTELH.Text

            Dim pPHOTH1 As New OdbcParameter
            pPHOTH1.ParameterName = "APHOTH1"
            pPHOTH1.OdbcType = OdbcType.VarChar
            pPHOTH1.Direction = ParameterDirection.Input
            pPHOTH1.Value = txtTELO.Text

            spCache.Parameters.Add(pName)
            spCache.Parameters.Add(pDOB)
            spCache.Parameters.Add(pSTREET)
            spCache.Parameters.Add(pPHHOME)
            spCache.Parameters.Add(pPHOTH1)

            spCache.ExecuteNonQuery()

            txCache.Commit()

            dsCache.Clear()
            daCache.Fill(dsCache, "ADBK")

            btnMoveLast_Click(Nothing, Nothing)
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Catch eAdd As Exception
            MessageBox.Show("An error has occurred:  " + eAdd.Message)

            txCache.Rollback()
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            txCache = cnCache.BeginTransaction(System.Data.IsolationLevel.Unspecified)
            spCache = New OdbcCommand("Update ADBK Set ANAME = ?, ABTHDAY = ?, ASTREET = ?, APHHOME = ?, APHOTH1 = ? where AID = ?", cnCache, txCache)

            Dim pName As New OdbcParameter()
            pName.ParameterName = "ANAME"
            pName.OdbcType = OdbcType.VarChar
            pName.Direction = ParameterDirection.Input
            pName.Value = txtName.Text

            Dim pDOB As New OdbcParameter()
            pDOB.ParameterName = "ABTHDAY"
            pDOB.OdbcType = OdbcType.Date
            pDOB.Direction = ParameterDirection.Input
            pDOB.Value = txtDOB.Text

            Dim pSTREET As New OdbcParameter
            pSTREET.ParameterName = "ASTREET"
            pSTREET.OdbcType = OdbcType.VarChar
            pSTREET.Direction = ParameterDirection.Input
            pSTREET.Value = txtADDRESS.Text

            Dim pPHHOME As New OdbcParameter
            pPHHOME.ParameterName = "APHHOME"
            pPHHOME.OdbcType = OdbcType.VarChar
            pPHHOME.Direction = ParameterDirection.Input
            pPHHOME.Value = txtTELH.Text

            Dim pPHOTH1 As New OdbcParameter
            pPHOTH1.ParameterName = "APHOTH1"
            pPHOTH1.OdbcType = OdbcType.VarChar
            pPHOTH1.Direction = ParameterDirection.Input
            pPHOTH1.Value = txtTELO.Text

            Dim pID As New OdbcParameter()
            pID.ParameterName = "AID"
            pID.OdbcType = OdbcType.Int
            pID.Direction = ParameterDirection.Input
            pID.Value = lblIDValue.Text

            spCache.Parameters.Add(pName)
            spCache.Parameters.Add(pDOB)
            spCache.Parameters.Add(pSTREET)
            spCache.Parameters.Add(pPHHOME)
            spCache.Parameters.Add(pPHOTH1)
            spCache.Parameters.Add(pID)

            spCache.ExecuteNonQuery()

            txCache.Commit()

            drCache = dtCache.Rows(drIndex)
            drCache("AID") = lblIDValue.Text
            drCache("ANAME") = txtName.Text
            drCache("ABTHDAY") = txtDOB.Text
            drCache("APHHOME") = txtTELH.Text
            drCache("APHOTH1") = txtTELO.Text
            drCache("ASTREET") = txtADDRESS.Text
        Catch eUpdate As Exception
            MessageBox.Show("An error has occurred:  " + eUpdate.Message)

            txCache.Rollback()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            txCache = cnCache.BeginTransaction(System.Data.IsolationLevel.Unspecified)
            spCache = New OdbcCommand("Delete from ADBK where AID = ?", cnCache, txCache)

            Dim pID As New OdbcParameter()
            pID.ParameterName = "AID"
            pID.OdbcType = OdbcType.Int
            pID.Direction = ParameterDirection.Input
            pID.Value = lblIDValue.Text

            spCache.Parameters.Add(pID)
            spCache.ExecuteNonQuery()

            txCache.Commit()

            dtCache.Rows.Remove(drCache)

            If (dtCache.Rows.Count > 0) Then
                If (drIndex > 0) Then
                    drIndex -= 1
                End If

                drCache = dtCache.Rows(drIndex)
                lblIDValue.Text = drCache.Item("AID")
                txtName.Text = drCache.Item("ANAME")
                txtDOB.Text = drCache.Item("ABTHDAY")
                txtADDRESS.Text = drCache.Item("ASTREET")
                txtTELH.Text = drCache.Item("APHHOME")
                txtTELO.Text = drCache.Item("APHOTH1")
            Else
                lblIDValue.Text = ""
                txtName.Text = ""
                txtDOB.Text = ""
                txtADDRESS.Text = ""
                txtTELH.Text = ""
                txtTELO.Text = ""

                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        Catch eDelete As Exception
            MessageBox.Show("An error has occurred:  " + eDelete.Message)

            txCache.Rollback()
        End Try
    End Sub
End Class
