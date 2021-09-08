using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NavigationControl
{
    public class NavigationItem
    {
        public string Text { get; set; }
        public Bitmap Icon { get; set; }
        public int Id { get; set; }
        public List<NavigationItem> Childs { get; set; }
    }
}
