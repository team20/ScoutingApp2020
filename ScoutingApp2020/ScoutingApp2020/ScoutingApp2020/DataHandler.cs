using Android.Bluetooth;
using Mono.Data.Sqlite;
using System.IO;

namespace ScoutingApp2020
{
    public class DataHandler
    {
        //START
        public string ScoutName { get; set; } = "";
        public int MatchNumber { get; set; } = 0;
        public bool ReplayMatch { get; set; } = false;
        public int TeamNumber { get; set; } = 0;
        public string AllianceColor { get; set; } = "";
        public int StartPosition { get; set; } = 0;
        public int Preloaded { get; set; } = 0;
        //AUTO
        public bool InitCross { get; set; } = false;
        public int AutoCollected { get; set; } = 0;
        public int AutoMissed { get; set; } = 0;
        public int AutoDropped { get; set; } = 0;
        public int AutoInner { get; set; } = 0;
        public int AutoOuter { get; set; } = 0;
        public int AutoLower { get; set; } = 0;
        public int AutoBottom { get; set; } = 0;
        //AUTO & TELEOP
        public int Fouls { get; set; } = 0;
        //This may be moved to "HeadScout App"
        //TELEOP
        public int TeleBottom { get; set; } = 0;
        public int TeleOuter { get; set; } = 0;
        public int TeleInner { get; set; } = 0;
        public int TeleCollected { get; set; } = 0;
        public int TeleMissed { get; set; } = 0;
        public int TeleDropped { get; set; } = 0;
        public bool PositionControl { get; set; } = false;
        public bool RotationControl { get; set; } = false;
        //ENDGAME
        public bool Park { get; set; } = false;
        public bool ClimbAttempt { get; set; } = false;
        public int ClimbZone { get; set; } = 0;
        public bool ClimbSuccess { get; set; } = false;
        public bool ClimbBalanced { get; set; } = false;
        public bool HadAssistance { get; set; } = false;
        public bool AssistedOthers { get; set; } = false;
        public int DefensePlay { get; set; } = 0;
        public int DefensePlayStrength { get; set; } = 0;
        public int DefenseAgainst { get; set; } = 0;
        public int DefenseAgainstStrength { get; set; } = 0;
        public string Breakdown { get; set; } = "";
        public string Comments { get; set; } = "";

        private readonly string _filePath;
        private readonly string _fileName;

        private int _partialDataNum;
        private string _dataString;
        private string _query;

        public DataHandler(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName + "_" + BluetoothAdapter.DefaultAdapter.Name.Replace(' ', '_');
            if (!Directory.Exists("/storage/emulated/0/Download/ScoutingData"))
                Directory.CreateDirectory("/storage/emulated/0/Download/ScoutingData");
            if (!File.Exists(_filePath + _fileName + ".sqlite"))
            {
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

        /*  public void BuildString(string separator)
      {
            dataString =
                ScoutName + separator
MatchNumber + separator
ReplayMatch + separator
TeamNumber + separator
AllianceColor + separator
StartPosition + separator
Preloaded + separator
InitLine + separator
AutoBottom + separator
AutoOuter + separator
AutoInner + separator
AutoMissed + separator
AutoDropped + separator
AutoCollected + separator
TeleBottom + separator
TeleOuter + separator
TeleMissed + separator
TeleCollected + separator
TeleInner + separator
TeleDropped + separator
RotationControl + separator
PositionControl + separator
Park + separator
ClimbAttempt + separator
ClimbZone + separator
ClimbSuccess + separator
ClimbBalanced + separator
HadAssistance + separator
AssistedOthers + separator
DefensePlay + separator
DefensePlayStrength + separator
DefenseAgainst + separator
DefenseAgainstStrength + separator
Fouls + separator
Breakdown + separator
Comments;
        }

        public void WriteToTextFile(bool newFile)
        {
            bool hasNumber = false;
            for (int i = 0; !hasNumber; i++)
                if (!File.Exists(filePath + partialDataPrefix + i + ".txt"))
                {
                    if (newFile || (!newFile && i == 0))
                        partialDataNum = i;
                    else
                        partialDataNum = i - 1;
                    hasNumber = true;
                }
            StreamWriter fullDataStreamWriter = new StreamWriter(filePath + fullDataName + ".txt", true);
            StreamWriter partialDataStreamWriter = new StreamWriter(filePath + partialDataPrefix + partialDataNum + ".txt", true);
            fullDataStreamWriter.WriteLineAsync(dataString);
            partialDataStreamWriter.WriteLineAsync(dataString);
            fullDataStreamWriter.Close();
            partialDataStreamWriter.Close();
            fullDataStreamWriter.Dispose();
            partialDataStreamWriter.Dispose();
        } */
    } 
    }