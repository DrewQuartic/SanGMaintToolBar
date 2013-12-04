Imports System.Windows.Forms
Imports System.Drawing
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ExportToExcel

    Shared Sub ExportDGVtoExcel(ByVal dgv As DataGridView)
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim xlRange As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer
            Dim ji As Integer
            'get excel
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            ' add the field headers 
            ji = 1
            For j = 1 To dgv.ColumnCount - 1
                xlWorkSheet.Cells(1, ji) = _
                   dgv.Columns(j).Name
                ji = ji + 1
            Next
            xlRange = xlWorkSheet.Range("A1", "A1").Resize(ColumnSize:=ji)
            xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Silver)
            xlRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White)
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12

            'add data 
            For i = 0 To dgv.RowCount - 1
                ji = 1
                For j = 1 To dgv.ColumnCount - 1
                    xlWorkSheet.Cells(i + 2, ji) = _
                       dgv(j, i).Value.ToString()
                    ji = ji + 1
                Next
            Next
            'fit the cells to the data and show
            xlApp.Columns.AutoFit()
            xlApp.Visible = True
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

            'drop the objects
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(xlRange)

        Catch ex As Exception
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
            Windows.Forms.MessageBox.Show(ex.Source + " " + ex.Message + " " + ex.StackTrace + " ")
        End Try
    End Sub

    Shared Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class
