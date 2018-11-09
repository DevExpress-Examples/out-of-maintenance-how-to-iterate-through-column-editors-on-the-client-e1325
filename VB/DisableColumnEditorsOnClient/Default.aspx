<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DisableColumnEditorsOnClient._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>How to iterate through column editors on the client</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientInstanceName="grid" KeyFieldName="ID" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize" OnRowUpdating="ASPxGridView1_RowUpdating" Width="390px">
			<Columns>
				<dxwgv:GridViewCommandColumn VisibleIndex="0">
					<EditButton Visible="True">
					</EditButton>
				</dxwgv:GridViewCommandColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataDateColumn FieldName="Date" VisibleIndex="2">
				</dxwgv:GridViewDataDateColumn>
				<dxwgv:GridViewDataCheckColumn FieldName="Editable" VisibleIndex="3">
					<PropertiesCheckEdit>
						<ClientSideEvents CheckedChanged="function(s, e) {
	for(i = 0; i &lt; grid.GetColumnsCount(); i++) {
		var editor = grid.GetEditor(i);
		if(editor != null &amp;&amp; editor != s)
			editor.SetEnabled(s.GetChecked());
	}
}" />
					</PropertiesCheckEdit>
				</dxwgv:GridViewDataCheckColumn>
			</Columns>
		</dxwgv:ASPxGridView>
	</div>
	</form>
</body>
</html>
