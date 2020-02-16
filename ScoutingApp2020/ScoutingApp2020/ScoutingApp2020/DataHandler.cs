using Android.Bluetooth;
using Mono.Data.Sqlite;
using System.IO;

namespace ScoutingApp2020 {
	public class DataHandler {
		//START
		public string ScoutName { get; set; } = "";
		public int MatchNumber { get; set; } = 0;
		public bool ReplayMatch { get; set; } = false;
		public int TeamNumber { get; set; } = 0;
		public string AllianceColor { get; set; } = "";
		public int StartPosition { get; set; } = 0;
		public int Preloaded { get; set; } = 0;
		//AUTO
		public bool InitLine { get; set; } = false;
		public int AutoInner { get; set; } = 0;
		public int AutoOuter { get; set; } = 0;
		public int AutoLower { get; set; } = 0;
		public int AutoBottom { get; set; } = 0;
		public int AutoMissed { get; set; } = 0;
		public int AutoDropped { get; set; } = 0;
		public int AutoCollected { get; set; } = 0;
		//AUTO & TELEOP
		public int Fouls { get; set; } = 0;
		//This may be moved to "HeadScout App"
		//TELEOP
		public int TeleBottom { get; set; } = 0;
		public int TeleOuter { get; set; } = 0;
		public int TeleInner { get; set; } = 0;
		public int TeleMissed { get; set; } = 0;
		public int TeleDropped { get; set; } = 0;
		public int TeleCollected { get; set; } = 0;
		public bool PositionControl { get; set; } = false;
		public bool RotationControl { get; set; } = false;
		//ENDGAME
		public int Zone { get; set; } = 0;
		public bool Park { get; set; } = false;
		public bool ClimbAttempt { get; set; } = false;
		public bool ClimbSuccess { get; set; } = false;
		public bool ClimbBalanced { get; set; } = false;
		public bool HadAssistance { get; set; } = false;
		public bool AssistedOthers { get; set; } = false;
		public int DefensePlay { get; set; } = 0;
		public int DefensePlayStrength { get; set; } = 0;
		public int DefenseAgainst { get; set; } = 0;
		public int DefenseAgainstStrength { get; set; } = 0;
		public int Role { get; set; } = 0;
		public string Breakdown { get; set; } = "";
		public string Comments { get; set; } = "";

		private readonly string _filePath;
		private readonly string _fileName;

		private int _partialDataNum;
		private string _dataString;
		private string _query;

		/// <summary>
		/// Initializes a new instance of the DataHandler class.
		/// </summary>
		/// <param name="filePath">Folder to store files in.</param>
		/// <param name="fileName">Name of Full Data text file.</param>
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
		/// Builds string to be apended to text file.
		/// </summary>
		/// <param name="separator">String to separate fields with (comma, tab, space, etc.).</param>
		public void BuildString(string separator) {
			_dataString =
				ScoutName + separator +
				MatchNumber + separator +
				ReplayMatch + separator +
				TeamNumber + separator +
				AllianceColor + separator +
				StartPosition + separator +
				Preloaded + separator +
				InitLine + separator +
				AutoBottom + separator +
				AutoOuter + separator +
				AutoInner + separator +
				AutoMissed + separator +
				AutoDropped + separator +
				AutoCollected + separator +
				TeleBottom + separator +
				TeleOuter + separator +
				TeleInner + separator +
				TeleMissed + separator +
				TeleDropped + separator +
				TeleCollected + separator +
				RotationControl + separator +
				PositionControl + separator +
				Park + separator +
				ClimbAttempt + separator +
				Zone + separator +
				ClimbSuccess + separator +
				ClimbBalanced + separator +
				HadAssistance + separator +
				AssistedOthers + separator +
				DefensePlay + separator +
				DefensePlayStrength + separator +
				DefenseAgainst + separator +
				DefenseAgainstStrength + separator +
				Role + separator +
				Fouls + separator +
				Breakdown + separator +
				Comments;
		}

		/// <summary>
		/// Writes data to a text file.
		/// </summary>
		/// <param name="newFile">True if a new Partial Data file should be created.</param>
		public void WriteToTextFile(bool newFile) {
			bool hasNumber = false;
			for (int i = 0; !hasNumber; i++)
				if (!File.Exists(_filePath + _fileName + "_" + i + ".txt")) {
					if (newFile || (!newFile && i == 0))
						_partialDataNum = i;
					else
						_partialDataNum = i - 1;
					hasNumber = true;
				}
			StreamWriter fullDataStreamWriter = new StreamWriter(_filePath + _fileName + ".txt", true);
			StreamWriter partialDataStreamWriter = new StreamWriter(_filePath + _fileName + "_" + _partialDataNum + ".txt", true);
			fullDataStreamWriter.WriteLineAsync(_dataString);
			partialDataStreamWriter.WriteLineAsync(_dataString);
			fullDataStreamWriter.Close();
			partialDataStreamWriter.Close();
			fullDataStreamWriter.Dispose();
			partialDataStreamWriter.Dispose();
		}

		/// <summary>
		/// Builds query for inserting data into SQLite database.
		/// </summary>
		public void BuildQuery() {
			_query = "INSERT INTO RawData(" +
				nameof(ScoutName) + ", " +
				nameof(MatchNumber) + ", " +
				nameof(ReplayMatch) + ", " +
				nameof(TeamNumber) + ", " +
				nameof(AllianceColor) + ", " +
				nameof(StartPosition) + ", " +
				nameof(Preloaded) + ", " +
				nameof(InitLine) + ", " +
				nameof(AutoBottom) + ", " +
				nameof(AutoOuter) + ", " +
				nameof(AutoInner) + ", " +
				nameof(AutoMissed) + ", " +
				nameof(AutoDropped) + ", " +
				nameof(AutoCollected) + ", " +
				nameof(TeleBottom) + ", " +
				nameof(TeleOuter) + ", " +
				nameof(TeleInner) + ", " +
				nameof(TeleMissed) + ", " +
				nameof(TeleDropped) + ", " +
				nameof(TeleCollected) + ", " +
				nameof(RotationControl) + ", " +
				nameof(PositionControl) + ", " +
				nameof(Park) + ", " +
				nameof(ClimbAttempt) + ", " +
				nameof(Zone) + ", " +
				nameof(ClimbSuccess) + ", " +
				nameof(ClimbBalanced) + ", " +
				nameof(HadAssistance) + ", " +
				nameof(AssistedOthers) + ", " +
				nameof(DefensePlay) + ", " +
				nameof(DefensePlayStrength) + ", " +
				nameof(DefenseAgainst) + ", " +
				nameof(DefenseAgainstStrength) + ", " +
				nameof(Fouls) + ", " +
				nameof(Role) + ", " +
				nameof(Breakdown) + ", " +
				nameof(Comments) +
			") " +
			"VALUES (" +
				"'" + ScoutName + "', " +
				MatchNumber + ", " +
				(ReplayMatch ? 1 : 0) + ", " +
				TeamNumber + ", " +
				"'" + AllianceColor + "', " +
				StartPosition + ", " +
				Preloaded + ", " +
				(InitLine ? 1 : 0) + ", " +
				AutoBottom + ", " +
				AutoOuter + ", " +
				AutoInner + ", " +
				AutoMissed + ", " +
				AutoDropped + ", " +
				AutoCollected + ", " +
				TeleBottom + ", " +
				TeleOuter + ", " +
				TeleInner + ", " +
				TeleMissed + ", " +
				TeleDropped + ", " +
				TeleCollected + ", " +
				RotationControl + ", " +
				PositionControl + ", " +
				Park + ", " +
				(ClimbAttempt ? 1 : 0) + ", " +
				Zone + ", " +
				(ClimbSuccess ? 1 : 0) + ", " +
				(ClimbBalanced ? 1 : 0) + ", " +
				(HadAssistance ? 1 : 0) + ", " +
				(AssistedOthers ? 1 : 0) + ", " +
				DefensePlay + ", " +
				DefensePlayStrength + ", " +
				DefenseAgainst + ", " +
				DefenseAgainstStrength + ", " +
				Fouls + ", " +
				Role + ", " +
				Breakdown + ", " +
				"'" + Comments + "'" +
			");";
		}

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