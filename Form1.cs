using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompsciIA
{
    public partial class Form1 : Form
    {
        //still translating to c#
        public int correlation_matrix(matrix)
        {
            int num_companies = matrix.GetLength(0);
            int num_days = matrix.GetLength(1);
            double std_dev = Math.Sqrt(num_days);
            result = [[0 for _ in range(num_companies)] for _ in range(num_companies)]

            for (int i = 0; i < num_companies; i++) {
                    for (j = i + 1; j < num_companies; j++) {
                        print("{i}, {j} = {result}")
                        //print("Processing pair {i}, {j}")
                        //print("company {i} = {matrix[i]}")
                        //print("company {j} = {matrix[j]}")
                        //^^^All stuff I used for testing it 
                        int net_moves = 0;
                        for (int k = 0; k < num_days - 1; k++) {
                            if (matrix[i][k] < matrix[i][k + 1]) and (matrix[j][k] < matrix[j][k + 1]) 
                                net_moves += 1;
                            else if matrix[i][k] > matrix[i][k + 1] and matrix[j][k] > matrix[j][k + 1]
                                net_moves = net_moves + 1;
                            else if matrix[i][k] == matrix[i][k + 1] or matrix[j][k] == matrix[j][k + 1]
                                net_moves = net_moves;
                            else
                                net_moves = net_moves - 1;
                            }
                            if abs(net_moves) > std_dev: {
                                print("Correlated Stocks {i}, {j} = {net_moves}");
                                result[i][j] = 1;
                            }
                        }
                    }

            return result;

            /* this is all stuff i use for testing
            A = [1,2,3,4,5,6]
            B = [1,2,3,3,2,1]
            C = [1,2,1,2,1,2]
            D = [2,4,6,8,10,12]
            E = [6,5,4,3,2,1]
            test_matrix = [A,B,C,D,E]
            result = correlation_matrix(test_matrix)
            print(result)
            */
            
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 frmImport = new Form1();
            frmImport.ShowDialog();
        }
        private DataTable ProcessDataSet(DataTable dt)
        {
            
            int index = 0;

            foreach (DataColumn dc in dt.Columns)
            {
                dc.ColumnName = dt.Rows[0][index].ToString();
                index++;
            }

            DataRow[] dr = dt.Select();
            dr[0].Delete();
            dt.AcceptChanges();

            return dt;
        }
               private void PopulateDataGridView(object sender, UpdateDataGridViewEventArgs e)
        {
            //*****************************************************
            //This method is accessed from the ImportExcelData or
            //ImportXMLData form via the delegate
            //*****************************************************

            //First we want to store the DataSet from the Import Process
            //_ds = e.GetDataSet;

            //1st Process the DataSet then assign to "_dt"
            _dt = e.GetDataSet.Tables[0];
            this.RemoveLeadingTrailingSpaces();

            //2nd Set the DataSource of the DataGridView to the DataTable "_dt"
            this.grdData.DataSource = _dt = ProcessDataSet(_dt);

            //Set record count
            this.lblTotal.Text = _dt.Rows.Count.ToString();

            //Format columns in the DataGridView
            this.FormatDataGridViewColumns();
            this.FormatDataGridViewColumnHeaders();
        }

        private void RemoveLeadingTrailingSpaces()
        {
            var dataRows = _dt.AsEnumerable();
            foreach (var row in dataRows)
            {
                var cellList = row.ItemArray.ToList();
                row.ItemArray = cellList.Select(x => x.ToString().Trim()).ToArray();
            };

            _dt = dataRows.CopyToDataTable();
            _dt.AcceptChanges();
        }
        
        private void FormatDataGridViewColumnHeaders()
        {
            //Set the Background Color of the Column Header
            this.grdData.EnableHeadersVisualStyles = false;
            this.grdData.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            this.grdData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Set the Font for the Column Header
            this.grdData.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);

            //Autosize the coulumns
            this.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        /*
        private void FormatDataGridViewColumns()
        {
            this.grdData.Columns["Expiry"].DefaultCellStyle.Format = String.Format("d");
            //Align Right
            this.grdData.Columns["Expiry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Format Column as Currency
            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Format = String.Format("C");
            //Align Right
            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        */

    }
}
