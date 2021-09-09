using NavigationControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bool rtl = false;
            if(rtl)
                panel1.RightToLeft = RightToLeft.Yes;

            List<NavigationItem> allItems = new List<NavigationItem>()
            {
                new NavigationItem()
                {
                    Text = "Table",
                    Id = 1,
                    Icon = new Bitmap(NavigationDemo.Resources.directors_chair_icon),
                    Childs = new List<NavigationItem>()
                    {
                        new NavigationItem() {Text = "Table 1",Id = 11,Icon = new Bitmap(NavigationDemo.Resources.Home_icon) },
                        new NavigationItem() {Text = "Table 2",Id = 12,Icon = new Bitmap(NavigationDemo.Resources.Line_chart_icon) },
                        new NavigationItem() {Text = "Table 3",Id = 13,Icon = new Bitmap(NavigationDemo.Resources.Location_icon) },
                        new NavigationItem() {Text = "Table 4",Id = 14,Icon = new Bitmap(NavigationDemo.Resources.Question_type_one_correct_icon) },
                        new NavigationItem() {Text = "Table 5",Id = 15,Icon = new Bitmap(NavigationDemo.Resources.reports_icon) }
                    }
                },
                    new NavigationItem()
                {
                    Text = "Reports",
                    Id = 2,
                    Icon = new Bitmap(NavigationDemo.Resources.directors_chair_icon),
                    Childs = new List<NavigationItem>()
                    {
                        new NavigationItem() {Text = "Table 1",Id = 21,Icon = new Bitmap(NavigationDemo.Resources.Home_icon) },
                        new NavigationItem() {Text = "Table 2",Id = 22,Icon = new Bitmap(NavigationDemo.Resources.Line_chart_icon) },
                        new NavigationItem() {Text = "Table 3",Id = 23,Icon = new Bitmap(NavigationDemo.Resources.Location_icon) },
                        new NavigationItem() {Text = "Table 4",Id = 24,Icon = new Bitmap(NavigationDemo.Resources.Question_type_one_correct_icon) },
                        new NavigationItem() {Text = "Table 5",Id = 25,Icon = new Bitmap(NavigationDemo.Resources.reports_icon) }
                    }
                }
            };

            NavigationControl.NavigationControl root = new NavigationControl.NavigationControl(allItems, rtl);
            root.Dock = DockStyle.Fill;
            panel1.Controls.Add(root);
        }

    }
}
