using System;
using System.IO;
using Xamarin.Forms;

namespace ScoutingApp2020 {
	public partial class MainPage : TabbedPage {
		#region Main
		private readonly DataHandler _data;

		private readonly string[] _teams;

		public MainPage() {
			InitializeComponent();

			_data = new DataHandler("/storage/emulated/0/Download/ScoutingData/", "2020_test");
			StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("Teams.txt"));
			_teams = streamReader.ReadLine().ToString().Split(',');
			streamReader.Close();
			streamReader.Dispose();
			ResetAll();
		}

		private void MainTabbedPage_CurrentPageChanged(object sender, EventArgs e) {
			BarBackgroundColor = MainTabbedPage.CurrentPage.TabIndex switch
			{
				0 => new Color(0.0, 0.6, 0.0),
				1 => new Color(0.5, 0.3, 0.0),
				2 => new Color(0.7, 0.0, 0.0),
				3 => new Color(0.0, 0.0, 0.6),
				_ => new Color(0.0, 0.0, 0.0),
			};
		}

		private void ResetAll() {

		}

		#endregion

		private void teamNoEntry_Unfocused(object sender, FocusEventArgs e) {
			bool valid = false;
			foreach (string team in _teams)
				if (teamNoEntry.Text == team || teamNoEntry.Text == "") {
					valid = true;
					break;
				}
			if (!valid) {
				DisplayAlert("Invalid Team Number", "The team number you entered does not match any of the teams at this event", "OK");
				teamNoEntry.Focus();
			}
		}
	}
}