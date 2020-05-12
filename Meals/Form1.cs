using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//練習用 物件屬性宣告  get set




namespace Meals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Create();
            label8.Text = "歡迎光臨！";
            label7.Visible = false;
            rdBtn1.Checked = false;
            rdBtn2.Checked = false;
        }
        int sum,n;
        private void button1_Click(object sender, EventArgs e)
        {
            sum = 0;
            for(int i =0;i<Chbox.Length; i++)
            {
                if (Chbox[i].Checked == true)
                {
                    sum += DrinkPrice[i] * Convert.ToInt32(Tbox[i].Text);
                }
            }
            label8.Text = "計：" + sum + "元";
        }
        private void button2_Click(object sender, EventArgs e)
        {//清除所有勾選、數字
            for (int i = 0; i < 6; i++)
            {
                Tbox[i].Text = "";
                Chbox[i].Checked=false;
            }
            rdBtn1.Checked = false;
            rdBtn2.Checked = false;
        }
        //選到內用時
        private void rdBtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtn2.Checked == true)
            {
                Chbox[6].Visible = true;
                Tbox[6].Visible = true;
                label7.Visible = true;
                Tbox[6].Text = "1";
                Chbox[6].Checked = true;
            }
            else
            {
                Chbox[6].Visible = false;
                Tbox[6].Visible = false;
                label7.Visible = false;
                Tbox[6].Text = "";
                Chbox[6].Checked = false;
            }
        }
        CheckBox[] Chbox = new CheckBox[7];
        TextBox[] Tbox = new TextBox[7];
        Drinks Drink = new Drinks();
        string[] DrinkName = new string[7] { "泡沫紅茶 ", "珍珠奶茶 ", "木瓜牛奶 ", "柳橙汁   ", "漢堡A餐 ", "麥克雞塊", "內用每人 " };
        int[] DrinkPrice = new int[7] { 30, 35, 40, 40, 100, 120, 10 };
        private void Create()
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i =0;i<7;i++) {
                Chbox[i] = new CheckBox();
                Chbox[i].Name = string.Format("cbox_{0}",i);
                Chbox[i].SetBounds(18,23 +35*i,190,25);
                Chbox[i].Text = DrinkName[i] + "  " + DrinkPrice[i]+"元";
                Chbox[i].CheckedChanged += Chbox_CheckedChanged;

                Tbox[i] = new TextBox();
                Tbox[i].Name = string.Format("tbox_{0}", i);
                Tbox[i].SetBounds(219, 23 + 35 * i, 50, 35);
                Tbox[i].TextChanged += Tbox_TextChanged;
                Tbox[i].TextAlign= HorizontalAlignment.Right;       //**增

                groupBox2.Controls.Add(Chbox[i]);
                groupBox2.Controls.Add(Tbox[i]);
                
            }
            
            Chbox[6].Visible = false;
            Tbox[6].Visible = false;
        }

        private void Tbox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Tbox.Length; i++)
            {
                if (int.TryParse(Tbox[i].Text, out n) == true && n > 0)
                {
                     Chbox[i].Checked = true;
                }
                else 
                {
                    Chbox[i].Checked = false;
                    if (int.TryParse(Tbox[i].Text, out n) == false && Tbox[i].Text != "")
                        Tbox[i].Text = "";
                }
            }
           
        }

        private void Chbox_CheckedChanged(object sender, EventArgs e)
        {
            string s=((CheckBox)sender).Name;
            int x = int.Parse(s.Substring(s.Length - 1, 1));
            if (Chbox[x].Checked == false)
                Tbox[x].Text = "";
            else
                if (Tbox[x].Text.Trim() == "")
                    Tbox[x].Text = "1";


            //**以上段替代下段，可免使用迴圈
            //for (int i = 0; i < Chbox.Length; i++) 
            //    if (Chbox[i].Checked ==false)
            //        Tbox[i].Text = "";
        }

    }


    public class Drinks
    {
        public string DrinkName { set; get; }
        public int DrinkPrice { set; get; }

    }

    
}
