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
        private DataTable _dt = new DataTable();
            /*
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
            //frmImport.UpdateDataGridView += new Form1.UpdateDGVHandler(PopulateDataGridView);

            frmImport.ShowDialog();
        }
        /*
        private void PopulateDataGridView(object sender, UpdateDataGridViewEventArgs e)
        {
            _dt = e.GetDataSet.Tables[0];
            this.RemoveLeadingTrailingSpaces();

            this.grdData.DataSource = _dt = ProcessDataSet(_dt);

            this.lblTotal.Text = _dt.Rows.Count.ToString();

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
            this.grdData.EnableHeadersVisualStyles = false;
            this.grdData.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            this.grdData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.grdData.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Arial"), 12, FontStyle.Bold);

            this.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FormatDataGridViewColumns()
        {
            this.grdData.Columns["Expiry"].DefaultCellStyle.Format = String.Format("d");
            this.grdData.Columns["Expiry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Format = String.Format("C");
            this.grdData.Columns["InsuredValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }*/
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

    }
}
