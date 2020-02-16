using Android.Bluetooth;
using Mono.Data.Sqlite;
using System.IO;

namespace ScoutingApp2020 {
	public class DataHandler {
		//START
		public string ScoutName { get; set; }
		public int MatchNumber { get; set; }
		public bool ReplayMatch { get; set; }
		public int TeamNumber { get; set; }
		public string AllianceColor { get; set; }
		public int StartPosition { get; set; }
		public int Preloaded { get; set; }
		//AUTO
		public int InitCross { get; set; }
		public int AutoCollected { get; set; } = 0;
		public int AutoMissed { get; set; } = 0;
		public int AutoDropped { get; set; } = 0;
		public int AutoInner { get; set; } = 0;
		public int AutoOuter { get; set; } = 0;
		public int AutoLower { get; set; } = 0;
		//AUTO & TELEOP
		public int Fouls { get; set; } = 0;
		//TELEOP
		public int TeleCargoShip { get; set; } = 0;
		public int TeleCargoRocket1 { get; set; } = 0;
		public int TeleCargoRocket2 { get; set; } = 0;
		public int TeleCargoRocket3 { get; set; } = 0;
		public int TeleCargoDrop { get; set; } = 0;
		public int TelePanelShip { get; set; } = 0;
		public int TelePanelRocket1 { get; set; } = 0;
		public int TelePanelRocket2 { get; set; } = 0;
		public int TelePanelRocket3 { get; set; } = 0;
		public int TelePanelDrop { get; set; } = 0;
		//ENDGAME
		public int HabLevelAchieved { get; set; }
		public int HabLevelAttempted { get; set; }
		public int HadAssistance { get; set; }
		public int AssistedOthers { get; set; }
		public int DefenseAmount { get; set; }
		public int DefenseSkill { get; set; }
		public int DefendedAmount { get; set; }
		public int DefendedSkill { get; set; }
		public string Breakdown { get; set; }
		public string Comments { get; set; }

		private readonly string _filePath;
		private readonly string _fileName;

		private int _partialDataNum;
		private string _dataString;
		private string _query;

		/// <summary>
		/// Initializes a new instance of the DataHandler class.
		/// </summary>
		/// <param name="filePath">Folder to stare files in.</param>
		/// <param name="fileName">Name of SQLite file.</param>
		public DataHandler(string filePath, string fileName) {
			_filePath = filePath;
			_fileName = fileName + "_" + BluetoothAdapter.DefaultAdapter.Name.Replace(' ', '_');
			if (!Directory.Exists("/storage/emulated/0/Download/ScoutingData"))
				Directory.CreateDirectory("/storage/emulated/0/Download/ScoutingData");
			if (!File.Exists(_filePath + _fileName + ".sqlite")) {
				File.Create(_filePath + _fileName + ".sqlite");
				SqliteConnection connection = new SqliteConnection("Data Source = " + _filePath + _fileName + ".sqlite");
				connection.Open();
				StreamReader streamReader = new StreamReader(Android.App.Application.Context.Assets.Open("CreateStatement.txt"));
				string createStatement = streamReader.ReadToEnd();
				streamReader.Close();
				streamReader.Dispose();
				SqliteCommand command = new SqliteCommand(createStatement, connection);
				command.ExecuteNonQuery();
				command.Dispose();
				connection.Close();
				connection.Dispose();
			}
		}

		/// <summary>
		/// Builds query for inserting data into SQLite database.
		/// </summary>
		/// <returns>Query for inserting data into SQLite database.</returns>
		public string BuildQuery() =>
			"INSERT INTO RawData(" +
				"ScoutName, " +
				"MatchNumber," +
				"ReplayMatch, " +
				"TeamNumber, " +
				"AllianceColor, " +
				"StartPosition, " +
				"PreloadedItem, " +
				"CrossHabLine, " +
				"SandCargoShip, " +
				"SandCargoRocket1, " +
				"SandCargoRocket2, " +
				"SandCargoRocket3, " +
				"SandCargoDrop, " +
				"SandPanelShip, " +
				"SandPanelRocket1, " +
				"SandPanelRocket2, " +
				"SandPanelRocket3, " +
				"SandPanelDrop, " +
				"TeleCargoShip, " +
				"TeleCargoRocket1, " +
				"TeleCargoRocket2, " +
				"TeleCargoRocket3, " +
				"TeleCargoDrop, " +
				"TelePanelShip, " +
				"TelePanelRocket1, " +
				"TelePanelRocket2, " +
				"TelePanelRocket3, " +
				"TelePanelDrop, " +
				"HabLevelAchieved, " +
				"HabLevelAttempted, " +
				"HadAssistance, " +
				"AssistedOthers, " +
				"DefenseAmount, " +
				"DefenseSkill, " +
				"DefendedAmount, " +
				"DefendedSkill, " +
				"Fouls, " +
				"Breakdown, " +
				"Comments" +
			") " +
			"VALUES (" +
				"'" + ScoutName + "', " +
				MatchNumber + ", " +
				ReplayMatch + ", " +
				TeamNumber + ", " +
				"'" + AllianceColor + "', " +
				StartPosition + ", " +
				PreloadedItem + ", " +
				CrossHabLine + ", " +
				SandCargoShip + ", " +
				SandCargoRocket1 + ", " +
				SandCargoRocket2 + ", " +
				SandCargoRocket3 + ", " +
				SandCargoDrop + ", " +
				SandPanelShip + ", " +
				SandPanelRocket1 + ", " +
				SandPanelRocket2 + ", " +
				SandPanelRocket3 + ", " +
				SandPanelDrop + ", " +
				TeleCargoShip + ", " +
				TeleCargoRocket1 + ", " +
				TeleCargoRocket2 + ", " +
				TeleCargoRocket3 + ", " +
				TeleCargoDrop + ", " +
				TelePanelShip + ", " +
				TelePanelRocket1 + ", " +
				TelePanelRocket2 + ", " +
				TelePanelRocket3 + ", " +
				TelePanelDrop + ", " +
				HabLevelAchieved + ", " +
				HabLevelAttempted + ", " +
				HadAssistance + ", " +
				AssistedOthers + ", " +
				DefenseAmount + ", " +
				DefenseSkill + ", " +
				DefendedAmount + ", " +
				DefendedSkill + ", " +
				Fouls + ", " +
				"'" + Breakdown + "', " +
				"'" + Comments + "'" +
			");";

		/// <summary>
		/// Inserts data into SQLite database.
		/// </summary>
		public void WriteToDatabase() {
			SqliteConnection connection = new SqliteConnection("Data Source = " + _filePath + _fileName + ".sqlite");
			connection.Open();
			SqliteCommand command = new SqliteCommand(_query, connection);
			command.ExecuteNonQuery();
			connection.Close();
			connection.Dispose();
		}
	}
}