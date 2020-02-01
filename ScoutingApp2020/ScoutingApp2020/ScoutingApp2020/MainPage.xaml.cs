using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoutingApp2020
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void MainTabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            switch (MainTabbedPage.CurrentPage.TabIndex)
            {
                case 0:
                    BarBackgroundColor = new Color(0.0, 0.6, 0.0);
                    break;
                case 1:
                    BarBackgroundColor = new Color(0.5, 0.3, 0.0);
                    break;
                case 2:
                    BarBackgroundColor = new Color(0.7, 0.0, 0.0);
                    break;
                case 3:
                    BarBackgroundColor = new Color(0.0, 0.0, 0.6);
                    break;
                default:
                    BarBackgroundColor = new Color(0.0, 0.0, 0.0);
                    break;
            }
        }


    }
}
