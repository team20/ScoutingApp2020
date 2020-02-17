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

		}

		

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

		#region Tele
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

		#region End

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
	}
}