Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace DisableColumnEditorsOnClient
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetDataSource()
		End Sub

		Private Function GetDataSource() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Name", GetType(String))
			table.Columns.Add("Date", GetType(DateTime))
			table.Columns.Add("Editable", GetType(Boolean))
			table.Rows.Add(1, "Item A", DateTime.Today, True)
			table.Rows.Add(2, "Item B", DateTime.Today.AddDays(-1), False)
			Return table
		End Function
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataBind()
		End Sub

		' value saving is halted
		Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			e.Cancel = True
			ASPxGridView1.CancelEdit()
		End Sub

		Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewEditorEventArgs)
			If e.Column.FieldName <> "Editable" Then
				Dim editable As Boolean = CBool(ASPxGridView1.GetRowValues(e.VisibleIndex, "Editable"))
				e.Editor.ClientEnabled = editable
			End If
		End Sub
	End Class
End Namespace
