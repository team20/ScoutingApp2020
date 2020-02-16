using Android.Content;
using System;
using System.IO;
using Xamarin.Forms;

namespace ScoutingApp2020 {
	public partial class MainPage : TabbedPage {
		#region Main
		private readonly DataHandler _data;
		private const int MAX = 99;
		private const int MIN = 0;
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
			// start
			ScoutName.Text = "";
			MatchNumber.Text = "";
			ReplayMatch.IsToggled = false;
			TeamNumber.Text = "";
			AllianceColorPicker.SelectedIndex = -1;
			StartPosition.Text= "";
			Preloaded.Text = "";
			// auto
			InitLine.IsToggled = false;
			AutoLower.Text = "0";
			AutoOuter.Text = "0";
			AutoInner.Text = "0";
			AutoMissed.Text = "0";
			AutoDropped.Text = "0";
			AutoCollected.Text = "0";
			// teleop
			TeleLower.Text = "0";
			TeleOuter.Text = "0";
			TeleInner.Text = "0";
			TeleMissed.Text = "0";
			TeleDropped.Text = "0";
			TeleCollected.Text = "0";
			RotationControl.IsToggled = false;
			PositionControl.IsToggled = false;
			// endgame
			// TODO: fix climb pickers
			EndHelped.IsToggled = false;
			EndAssist.IsToggled = false;
			DefenseAmountPicker.SelectedIndex = -1;
			DefenseSkillPicker.SelectedIndex = -1;
			DefendedAmountPicker.SelectedIndex = -1;
			DefendedSkillPicker.SelectedIndex = -1;
			BreakdownPicker.SelectedIndex = -1;
			CommentsEntry.Text = "";
		}

		#endregion

		private void teamNoEntry_Unfocused(object sender, FocusEventArgs e) {
			bool valid = false;
			foreach (string team in _teams)
				if (TeamNumber.Text == team || TeamNumber.Text == "") {
					valid = true;
					break;
				}
			if (!valid) {
				DisplayAlert("Invalid Team Number", "The team number you entered does not match any of the teams at this event", "OK");
				TeamNumber.Focus();
			}
		}

		//AUTO INNER MINUS
		private void AutoInnerMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoInner > MIN) {
				AutoInner.Text = (--_data.AutoInner).ToString();
			}
		}

		//AUTO INNER PLUS
		private void AutoInnerPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoInner < MAX) {
				AutoInner.Text = (++_data.AutoInner).ToString();
			}
		}

		//AUTO OUTER MINUS
		private void AutoOuterMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoOuter < MAX) {
				AutoInner.Text = (--_data.AutoOuter).ToString();
			}
		}

		//AUTO OUTER PLUS
		private void AutoOuterPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoOuter < MAX) {
				AutoInner.Text = (++_data.AutoOuter).ToString();
			}
		}

		//AUTO LOWER 
		private void AutoLowerMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoLower < MAX) {
				AutoLower.Text = (--_data.AutoLower).ToString();
			}
		}

		private void AutoLowerPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoLower < MAX) {
				AutoLower.Text = (++_data.AutoLower).ToString();
			}
		}

		private async void Button_Clicked(object sender, EventArgs e) {
			if (ScoutName.Text == "" ||
				MatchNumber.Text == "" ||
				TeamNumber.Text == "" ||
				AllianceColorPicker.SelectedIndex == -1||
				StartPosition.Text == "" || 
				Preloaded.Text==""||
				ClimbZoneAttemptedPicker.SelectedIndex == -1 ||
				ClimbZoneAchievedPicker.SelectedIndex == -1 ||
				BreakdownPicker.SelectedIndex == -1 ||
				NewFilePicker.SelectedIndex == -1)
				await DisplayAlert("Error", "Not all data entries are filled", "OK");
			else {
				_data.ScoutName = ScoutName.Text;
				_data.MatchNumber = int.Parse(MatchNumber.Text);
				_data.TeamNumber = int.Parse(TeamNumber.Text);
				_data.AllianceColor = (string)AllianceColorPicker.SelectedItem;
				_data.StartPosition = int.Parse(StartPosition.Text);
				_data.Preloaded = int.Parse(Preloaded.Text);
				// TODO: fix climb options
				_data.Breakdown = (string)BreakdownPicker.SelectedItem;
				_data.Comments = CommentsEntry.Text;

				_data.BuildQuery();
				_data.BuildString("\t");
				try {
					_data.WriteToDatabase();
					_data.WriteToTextFile(NewFilePicker.SelectedIndex == 0);
					ResetAll();
					CurrentPage = new MainPage();
					await DisplayAlert("Saved", "The data you entered has been saved to a file", "OK");
				} catch (UnauthorizedAccessException) {
					if (await DisplayAlert("Error", "App does not have permission to access device storage. To fix this, go to \"Settings > Apps > ScoutingApp2019.Android > Permissions\" and turn on the switch for \"Storage\".", "Settings", "Cancel"))
						Android.App.Application.Context.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName)));
				}
			}
		}
	}
}