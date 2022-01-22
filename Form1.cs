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
        //TODO: finish translating this to c# (was originally in python)
using System.math;

def correlation_matrix(matrix):
  num_companies = len(matrix)
  num_days = len(matrix[0])
  std_dev = math.sqrt(num_days)
  result = [[0 for _ in range(num_companies)] for _ in range(num_companies)]

  for (int i = 0; i < num_companies; i++) {
    for (j = i+1; j < num_companies; j++) {
      print("{i}, {j} = {result}")
      //print("Processing pair {i}, {j}")
      //print("company {i} = {matrix[i]}")
      //print("company {j} = {matrix[j]}")
      //^^^All stuff I used for testing it 
      net_moves = 0
      for k in range(0,num_days-1) {
          if matrix[i][k] < matrix[i][k+1] and matrix[j][k] < matrix[j][k+1]:
              net_moves = net_moves + 1
          else if matrix[i][k] > matrix[i][k+1] and matrix[j][k] > matrix[j][k+1]:
              net_moves = net_moves + 1
          else if matrix[i][k] == matrix[i][k+1] or matrix[j][k] == matrix[j][k+1]:
              net_moves = net_moves
          else:
              net_moves = net_moves - 1
       }
      if abs(net_moves) > std_dev: {
          print(f"Correlated Stocks {i}, {j} = {net_moves}")
          result[i][j] = 1
          }
       }
   }

  return result
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
            this.SetControls();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            //Create Instance of the Import Excel Form
            ImportExcelData frmImport = new ImportExcelData();

            //Access the Event which is used by the Delegate
            //Pass in a method on THIS FORM to the ImportExcelData Form
            //This will cause the Deletegate on the ImportExcelData Form
            //To access the method on this Form
            frmImport.UpdateDataGridView += new ImportExcelData.UpdateDGVHandler(PopulateDataGridView);
            
            //Show the form
            frmImport.ShowDialog();
        }
        //TODO: Add method that makes the excel data a matrix
    }
}

---
