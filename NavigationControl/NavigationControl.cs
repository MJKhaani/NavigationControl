using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigationControl
{
    public partial class NavigationControl : UserControl
    {
        public delegate void NavigationItemClicked(object sender, NavigationItem args);
        public event NavigationItemClicked NavigationItemClickedEvent;


        public List<NavigationItem> Items { get; set; }
        public List<NavigationRootItemControl> rootItemControls { get; set; }= new List<NavigationRootItemControl>();
        public NavigationControl(List<NavigationItem> items, bool rtl = false)
        {
            InitializeComponent();
            Items = items;

            if(items != null && items.Count>0)
            {
                foreach(NavigationItem item in items)
                {
                    var rootItem = new NavigationRootItemControl(item,rtl);
                    rootItem.NavigationItemClickedEvent += RootItem_NavigationItemClickedEvent;
                    //rootItem.Dock = DockStyle.Top;
                    flowLayoutPanel.Controls.Add(rootItem);
                    rootItemControls.Add(rootItem);
                }
            }
        }

        private void RootItem_NavigationItemClickedEvent(object sender, NavigationItem args)
        {
            if(Items.Contains(args))
            {
                foreach (NavigationRootItemControl itemControl in rootItemControls)
                    if (itemControl.NavigationItem != args)
                        itemControl.CloseRootItem();
            }
            else
                NavigationItemClickedEvent?.Invoke(this, args);
        }
    }
}
