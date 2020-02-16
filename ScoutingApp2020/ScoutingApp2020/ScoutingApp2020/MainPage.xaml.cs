
using System;
using System.IO;
using Android;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScoutingApp2020
{   
    public partial class MainPage : TabbedPage
    {
        private DataHandler data;

        private string[] teams;
        public MainPage()    
        {
            InitializeComponent();

            data = new DataHandler("/storage/emulated/0/Download/", "2019_detroit_curie_full_data", "2019_detroit_curie_partial_data_");
            StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("2019_detroit_curie_teams.txt"));
            teams = streamReader.ReadLine().ToString().Split(',');
            streamReader.Close();
            streamReader.Dispose();
            ResetAll();
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

        private void ResetAll()
        {

        }
            private void autoInnerPlus_Clicked(object sender, EventArgs e)
        {
            
                
        }
    }

   
}

