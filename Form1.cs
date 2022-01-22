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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

---

import math 

def correlation_matrix(matrix):
  num_companies = len(matrix)
  num_days = len(matrix[0])
  std_dev = math.sqrt(num_days)
  result = [[0 for _ in range(num_companies)] for _ in range(num_companies)]

  for i in range(0, num_companies):
    for j in range(i+1, num_companies):
      print(f"{i}, {j} = {result}")
      #print(f"Processing pair {i}, {j}")
      #print(f"company {i} = {matrix[i]}")
      #print(f"company {j} = {matrix[j]}")
      net_moves = 0
      for k in range(0,num_days-1):
          if matrix[i][k] < matrix[i][k+1] and matrix[j][k] < matrix[j][k+1]:
              net_moves = net_moves + 1
          elif matrix[i][k] > matrix[i][k+1] and matrix[j][k] > matrix[j][k+1]:
              net_moves = net_moves + 1
          elif matrix[i][k] == matrix[i][k+1] or matrix[j][k] == matrix[j][k+1]:
              net_moves = net_moves
          else:
              net_moves = net_moves - 1
      if abs(net_moves) > std_dev:
          print(f"Correlated Stocks {i}, {j} = {net_moves}")
          result[i][j] = 1

  return result

A = [1,2,3,4,5,6]
B = [1,2,3,3,2,1]
C = [1,2,1,2,1,2]
D = [2,4,6,8,10,12]
E = [6,5,4,3,2,1]

test_matrix = [A,B,C,D,E]

result = correlation_matrix(test_matrix)
print(result)
