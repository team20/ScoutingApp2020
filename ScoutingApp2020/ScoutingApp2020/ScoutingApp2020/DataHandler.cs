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
        public int initCross { get; set; }
        public int autoCollected { get; set; } = 0;
        public int autoMissed { get; set; } = 0;
        public int autoDropped { get; set; } = 0;
        public int autoInner { get; set; } = 0;
        public int autoOuter { get; set; } = 0;
        public int autoLower { get; set; } = 0;
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

        /*   public void BuildString(string separator)
           {
               dataString =
                   ScoutName + separator +
                   MatchNumber + separator +
                   ReplayMatch + separator +
                   TeamNumber + separator +
                   AllianceColor + separator +
                   StartPosition + separator +
                   PreloadedItem + separator +
                   CrossHabLine + separator +
                   SandCargoShip + separator +
                   SandCargoRocket1 + separator +
                   SandCargoRocket2 + separator +
                   SandCargoRocket3 + separator +
                   SandCargoDrop + separator +
                   SandPanelShip + separator +
                   SandPanelRocket1 + separator +
                   SandPanelRocket2 + separator +
                   SandPanelRocket3 + separator +
                   SandPanelDrop + separator +
                   TeleCargoShip + separator +
                   TeleCargoRocket1 + separator +
                   TeleCargoRocket2 + separator +
                   TeleCargoRocket3 + separator +
                   TeleCargoDrop + separator +
                   TelePanelShip + separator +
                   TelePanelRocket1 + separator +
                   TelePanelRocket2 + separator +
                   TelePanelRocket3 + separator +
                   TelePanelDrop + separator +
                   HabLevelAchieved + separator +
                   HabLevelAttempted + separator +
                   HadAssistance + separator +
                   AssistedOthers + separator +
                   DefenseAmount + separator +
                   DefenseSkill + separator +
                   DefendedAmount + separator +
                   DefendedSkill + separator +
                   Fouls + separator +
                   Breakdown + separator +
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