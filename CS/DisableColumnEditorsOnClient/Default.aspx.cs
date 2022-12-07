using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DisableColumnEditorsOnClient {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetDataSource();
        }

        private DataTable GetDataSource() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Editable", typeof(bool));
            table.Rows.Add(1, "Item A", DateTime.Today, true);
            table.Rows.Add(2, "Item B", DateTime.Today.AddDays(-1), false);
            return table;
        }
        protected void Page_Load(object sender, EventArgs e) {
            ASPxGridView1.DataBind();
        }

        // value saving is halted
        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e) {
            if(e.Column.FieldName != "Editable") {
                bool editable = (bool)ASPxGridView1.GetRowValues(e.VisibleIndex, "Editable");
                e.Editor.ClientEnabled = editable;
            }
        }
    }
}
