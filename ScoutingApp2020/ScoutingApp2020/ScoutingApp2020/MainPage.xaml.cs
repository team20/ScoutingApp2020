using System;
using System.IO;
using Xamarin.Forms;

namespace ScoutingApp2020
{
    public partial class MainPage : TabbedPage
    {
        #region Main
        private readonly DataHandler _data;

        private readonly string[] _teams;

        public MainPage()
        {
            InitializeComponent();

            //_data = new DataHandler("/storage/emulated/0/Download/ScoutingData/", "2020_test");
            //StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("2020_detroit_curie_teams.txt"));
            //_teams = streamReader.ReadLine().ToString().Split(',');
            //streamReader.Close();
            //streamReader.Dispose();
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

        #endregion
    }
}