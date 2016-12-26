using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakIn
{
  public partial class ExportDialog : Form
  {
    public ExportDialog()
    {
      InitializeComponent();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      Database db = new Database();
      db.ConnectToDb();
      if ((radExcel.Checked) & (radCurrent.Checked))
        db.ExportLogsToExcel();
      else if ((radExcel.Checked) & (radArchive.Checked))
        db.ExportArchiveToExcel();
      else if ((radCSV.Checked) & (radCurrent.Checked))
        db.ExportLogsToCsv();
      else if ((radCSV.Checked) & (radArchive.Checked))
        db.ExportArchiveToCsv();
        db = null;
        Cursor = Cursors.Default;
        Close();

    }
  }
}
