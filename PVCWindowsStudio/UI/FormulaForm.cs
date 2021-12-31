using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BO;
using PVCWindowsStudio.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.UI
{
    public partial class FormulaForm : Telerik.WinControls.UI.RadForm
    {
        private Formula formula;
        private readonly FormulaBLL formulaBLL;
        private readonly ProductItemsBLL productBll;
        public FormulaForm()
        {
            productBll = new ProductItemsBLL();
            formula = new Formula();
            formulaBLL = new FormulaBLL();
            InitializeComponent();
        }
        private void NumClick(string number)
        {
            if (String.IsNullOrEmpty(txtValue.Text))
                txtValue.Text += number;
            else
            {
                var value = txtValue.Text.Substring((txtValue.Text.Length-1),1);
                if (value == "t" || value == "e" || value == "h" || value == "y")
                    return;
                else
                    txtValue.Text += number;
            }
        }

        private void InitiateData()
        {
            var list = formulaBLL.GetAll();
            radGridView3.DataSource = list;
        }
        private void OpClick(string operand)
        {
            var value = "";
            if (!String.IsNullOrEmpty(txtValue.Text))
            {
                value = txtValue.Text.Substring((txtValue.Text.Length - 1), 1);


                if (value == "+" || value == "-" || value == "*" || value == "/" || value == ".")
                    return;
                else
                    txtValue.Text += operand;
            }
            
        }

        private void WordClick(string word)
        {
            if (String.IsNullOrEmpty(txtValue.Text))
                txtValue.Text += word;
            else
            {
                var value = txtValue.Text.Substring((txtValue.Text.Length - 1), 1);
                if (value == "0" || value == "1" || value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9" || value == "t" || value == "h" || value == "e" || value == "y")
                    return;
                else
                    txtValue.Text += word;
            }
        }

        private void BraceClick(string brace)
        {
            if (String.IsNullOrEmpty(txtValue.Text))
                txtValue.Text += brace;
            else
            {
                var value = txtValue.Text.Substring((txtValue.Text.Length - 1), 1);
                if (brace == "(" && (value == "0" || value == "1" || value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9" || value == ")" || value == "t" || value == "h" || value == "e" || value == "y"))
                    return;
                else if (brace == ")" && (value == "("))
                    return;
                else
                    txtValue.Text += brace;

            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            NumClick("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            NumClick("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            NumClick("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            NumClick("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            NumClick("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            NumClick("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            NumClick("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            NumClick("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            NumClick("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            NumClick("0");
        }

        private void btnWidth_Click(object sender, EventArgs e)
        {
            WordClick("Width");
        }

        private void btnHeight_Click(object sender, EventArgs e)
        {
            WordClick("Height");
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            WordClick("Price");
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            WordClick("Quantity");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            OpClick("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            OpClick("-");
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            OpClick("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            OpClick("/");
        }

        private void btnLeftBracket_Click(object sender, EventArgs e)
        {
            BraceClick("(");
        }

        private void btnRightBracket_Click(object sender, EventArgs e)
        {
            BraceClick(")");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            OpClick(".");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtValue.Text = "";
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValue.Text))
            {
                txtValue.Text = txtValue.Text.Substring(0, (txtValue.Text.Length - 1));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtValue.Text))
            {
                formula.FormulaType = txtValue.Text;
                formula.InsertBy = 1;

                if(formulaBLL.Insert(formula))
                {
                    RadMessageBox.Show(MessageTexts.successInsertFormula);
                    InitiateData();
                    Clear();
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);                
            }
            else RadMessageBox.Show(MessageTexts.fillFormulaBox);
        }

        private void FormulaForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtValue.Text))
            {
                formula.FormulaType = txtValue.Text;
                formula.LUB = 1;
                if (formulaBLL.Update(formula))
                {
                    RadMessageBox.Show(MessageTexts.successUpdateFormula);
                    InitiateData();
                    Clear();
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);

            }
            else RadMessageBox.Show(MessageTexts.selectMessageFormula);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                var formulaList = productBll.GetFormula();

                    if (!formulaList.Contains(int.Parse(lblID.Text)))
                    {
                        if (RadMessageBox.Show(MessageTexts.deleteMessage, "",MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                        {
                            if (formulaBLL.Delete(int.Parse(lblID.Text)))
                            {
                                RadMessageBox.Show(MessageTexts.successDeleteFormula);
                                InitiateData();
                                Clear();
                            }
                            else RadMessageBox.Show(MessageTexts.somethingWrong);
                        }                        
                    }
                    else RadMessageBox.Show(MessageTexts.formulaIsUsed);                                       
            }
            else RadMessageBox.Show(MessageTexts.selectMessageFormula);
        }

        private void Clear()
        {
            txtValue.Text = "";
            lblID.Text = "";
        }

        private void radGridView3_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                formula = (Formula)radGridView3.Rows[rowindex].DataBoundItem;
                if (formula != null)
                {
                    lblID.Text = formula.FormulaID.ToString();
                    txtValue.Text = formula.FormulaType;

                }
            }
        }
    }
}
