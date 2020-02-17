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
			StartPosition.Text = "";
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
			ZoneAttemptedPicker.SelectedIndex = -1;
			ClimbAttemptedSwitch.IsToggled = false;
			ClimbSuccessSwitch.IsToggled = false;
			ClimbBalancedSwitch.IsToggled = false;
			EndHelped.IsToggled = false;
			EndAssist.IsToggled = false;
			DefenseAmountPicker.SelectedIndex = -1;
			DefenseSkillPicker.SelectedIndex = -1;
			DefendedAmountPicker.SelectedIndex = -1;
			DefendedSkillPicker.SelectedIndex = -1;
			Fouls.Text = "0";
			BreakdownPicker.SelectedIndex = -1;
			RolePicker.SelectedIndex = -1;
			CommentsEntry.Text = "";
			NewFilePicker.SelectedIndex = 1;
			// data handler variables
			_data.AutoLower = 0;
			_data.AutoOuter = 0;
			_data.AutoInner = 0;
			_data.AutoMissed = 0;
			_data.AutoDropped = 0;
			_data.AutoCollected = 0;
			_data.TeleLower = 0;
			_data.TeleOuter = 0;
			_data.TeleInner = 0;
			_data.TeleMissed = 0;
			_data.TeleDropped = 0;
			_data.TeleCollected = 0;
			_data.Fouls = 0;
		}

		#endregion

		#region Start

		private void TeamNumber_Unfocused(object sender, FocusEventArgs e) {
			bool valid = false;
			foreach (string team in _teams)
				if (TeamNumber.Text == team || string.IsNullOrWhiteSpace(TeamNumber.Text)) {
					valid = true;
					break;
				}
			if (!valid) {
				DisplayAlert("Invalid Team Number", "The team number you entered does not match any of the teams at this event", "OK");
				TeamNumber.Focus();
			}
		}

		#endregion

		#region Auto

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
			if (_data.AutoOuter > MIN) {
				AutoOuter.Text = (--_data.AutoOuter).ToString();
			}
		}

		//AUTO OUTER PLUS
		private void AutoOuterPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoOuter < MAX) {
				AutoOuter.Text = (++_data.AutoOuter).ToString();
			}
		}

		//AUTO LOWER MINUS
		private void AutoLowerMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoLower > MIN) {
				AutoLower.Text = (--_data.AutoLower).ToString();
			}
		}

		//AUTO LOWER PLUS
		private void AutoLowerPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoLower < MAX) {
				AutoLower.Text = (++_data.AutoLower).ToString();
			}
		}

		//AUTO MISSED MINUS
		private void AutoMissedMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoMissed > MIN) {
				AutoMissed.Text = (--_data.AutoMissed).ToString();
			}
		}

		//AUTO MISSED PLUS
		private void AutoMissedPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoMissed < MAX) {
				AutoMissed.Text = (++_data.AutoMissed).ToString();
			}
		}

		//AUTO DROPPED MINUS
		private void AutoDroppedMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoDropped > MIN) {
				AutoDropped.Text = (--_data.AutoDropped).ToString();
			}
		}

		//AUTO DROPPED PLUS
		private void AutoDroppedPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoDropped < MAX) {
				AutoDropped.Text = (++_data.AutoDropped).ToString();
			}
		}

		//AUTO COLLECTED MINUS
		private void AutoCollectedMinus_Clicked(object sender, EventArgs e) {
			if (_data.AutoCollected > MIN) {
				AutoCollected.Text = (--_data.AutoCollected).ToString();
			}
		}

		//AUTO COLLECTED PLUS
		private void AutoCollectedPlus_Clicked(object sender, EventArgs e) {
			if (_data.AutoCollected < MAX) {
				AutoCollected.Text = (++_data.AutoCollected).ToString();
			}
		}

		#endregion

		#region Teleop

		//Tele INNER MINUS
		private void TeleInnerMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleInner > MIN) {
				TeleInner.Text = (--_data.TeleInner).ToString();
			}
		}

		//Tele INNER PLUS
		private void TeleInnerPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleInner < MAX) {
				TeleInner.Text = (++_data.TeleInner).ToString();
			}
		}

		//Tele OUTER MINUS
		private void TeleOuterMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleOuter > MIN) {
				TeleOuter.Text = (--_data.TeleOuter).ToString();
			}
		}

		//Tele OUTER PLUS
		private void TeleOuterPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleOuter < MAX) {
				TeleOuter.Text = (++_data.TeleOuter).ToString();
			}
		}

		//Tele LOWER MINUS
		private void TeleLowerMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleLower > MIN) {
				TeleLower.Text = (--_data.TeleLower).ToString();
			}
		}

		//Tele LOWER PLUS
		private void TeleLowerPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleLower < MAX) {
				TeleLower.Text = (++_data.TeleLower).ToString();
			}
		}

		//Tele MISSED MINUS
		private void TeleMissedMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleMissed > MIN) {
				TeleMissed.Text = (--_data.TeleMissed).ToString();
			}
		}

		//Tele MISSED PLUS
		private void TeleMissedPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleMissed < MAX) {
				TeleMissed.Text = (++_data.TeleMissed).ToString();
			}
		}

		//Tele DROPPED MINUS
		private void TeleDroppedMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleDropped > MIN) {
				TeleDropped.Text = (--_data.TeleDropped).ToString();
			}
		}

		//Tele DROPPED PLUS
		private void TeleDroppedPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleDropped < MAX) {
				TeleDropped.Text = (++_data.TeleDropped).ToString();
			}
		}

		//Tele COLLECTED MINUS
		private void TeleCollectedMinus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCollected > MIN) {
				TeleCollected.Text = (--_data.TeleCollected).ToString();
			}
		}

		//Tele COLLECTED PLUS
		private void TeleCollectedPlus_Clicked(object sender, EventArgs e) {
			if (_data.TeleCollected < MAX) {
				TeleCollected.Text = (++_data.TeleCollected).ToString();
			}
		}

		#endregion

		#region Endgame

		private void FoulsMinus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls > MIN) {
				Fouls.Text = (--_data.Fouls).ToString();
			}
		}

		private void FoulsPlus_Clicked(object sender, EventArgs e) {
			if (_data.Fouls < MAX) {
				Fouls.Text = (++_data.Fouls).ToString();
			}
		}

		#endregion

		private async void SubmitButton_Clicked(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(ScoutName.Text) ||
				string.IsNullOrWhiteSpace(MatchNumber.Text) ||
				string.IsNullOrWhiteSpace(TeamNumber.Text) ||
				AllianceColorPicker.SelectedIndex == -1 ||
				string.IsNullOrWhiteSpace(StartPosition.Text) ||
				string.IsNullOrWhiteSpace(Preloaded.Text) ||
				ZoneAttemptedPicker.SelectedIndex == -1 ||
				BreakdownPicker.SelectedIndex == -1 ||
				RolePicker.SelectedIndex == -1 ||
				DefenseAmountPicker.SelectedIndex == -1 ||
				DefenseSkillPicker.SelectedIndex == -1 ||
				DefendedAmountPicker.SelectedIndex == -1 ||
				DefendedSkillPicker.SelectedIndex == -1 ||
				NewFilePicker.SelectedIndex == -1)
				await DisplayAlert("Error", "Not all data entries are filled", "OK");
			else {
				_data.ScoutName = ScoutName.Text;
				_data.MatchNumber = int.Parse(MatchNumber.Text);
				_data.ReplayMatch = ReplayMatch.IsToggled;
				_data.TeamNumber = int.Parse(TeamNumber.Text);
				_data.AllianceColor = (string)AllianceColorPicker.SelectedItem;
				_data.StartPosition = int.Parse(StartPosition.Text);
				_data.Preloaded = int.Parse(Preloaded.Text);
				_data.InitLine = InitLine.IsToggled;
				_data.RotationControl = RotationControl.IsToggled;
				_data.PositionControl = PositionControl.IsToggled;
				_data.Zone = ZoneAttemptedPicker.SelectedIndex;
				_data.ClimbAttempt = ClimbAttemptedSwitch.IsToggled;
				_data.ClimbSuccess = ClimbSuccessSwitch.IsToggled;
				_data.ClimbBalanced = ClimbBalancedSwitch.IsToggled;
				_data.Breakdown = (string)BreakdownPicker.SelectedItem;
				_data.Role = (string)RolePicker.SelectedItem;
				_data.DefensePlay = DefenseAmountPicker.SelectedIndex;
				_data.DefensePlayStrength = DefenseSkillPicker.SelectedIndex;
				_data.DefenseAgainst = DefendedAmountPicker.SelectedIndex;
				_data.DefenseAgainstStrength = DefendedSkillPicker.SelectedIndex;
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