using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigationControl
{
    public partial class NavigationRootItemControl : UserControl
    {
        public delegate void NavigationItemClicked(object sender, NavigationItem args);
        public event NavigationItemClicked NavigationItemClickedEvent;

        public NavigationItem NavigationItem { get; set; }

        private Panel panel;
        private NavigationItemControl rootItem;

        public NavigationRootItemControl(NavigationItem navigationItem, bool rtl = false)
        {
            InitializeComponent();
            NavigationItem = navigationItem;


            int panelHeight = NavigationItem.Childs.Count * 45;


            rootItem = new NavigationItemControl(NavigationItem, rtl);
            rootItem.Dock = DockStyle.Top;
            this.Size = new Size(this.Width, rootItem.Height);
            
            

            if (NavigationItem.Childs!=null &&  NavigationItem.Childs.Count>0)
            {
                panel= new Panel();
                panel.Dock = DockStyle.Top;
                panel.Margin = new Padding(0, 0, 0, 0);
                panel.Size = new Size(this.Width, 0);
                this.Controls.Add(panel);

                foreach(var item in NavigationItem.Childs)
                {
                    var navItem = new NavigationItemControl(item,rtl);
                    if(rtl)
                        navItem.Padding = new Padding(0, 0, 15, 0);
                    else
                        navItem.Padding = new Padding(15, 0, 0, 0);
                    navItem.Margin = new Padding(0, 0, 0, 0);
                    navItem.Dock = DockStyle.Top;
                    panel.Controls.Add(navItem);
                }
            }

            this.Controls.Add(rootItem);
            rootItem.NavigationItemClickedEvent += NavigationRootItemControl_Click;
        }

        private void NavigationRootItemControl_Click(object sender, NavigationItem item)
        {
            if (panel.Height == 0)
            {
                int panelHeight = NavigationItem.Childs.Count * 45;
                panel.Size = new Size(this.Width, panelHeight);
                this.Size = new Size(this.Width, panelHeight + 45);
            }
            else
                CloseRootItem();

            NavigationItemClickedEvent?.Invoke(this, rootItem.NavigationItem);
        }

        public void CloseRootItem()
        {
            panel.Size = new Size(this.Width, 0);
            this.Size = new Size(rootItem.Width, rootItem.Height);
        }
    }
}
