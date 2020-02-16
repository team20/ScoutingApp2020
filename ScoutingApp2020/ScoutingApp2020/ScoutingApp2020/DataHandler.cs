    using System.IO;

    namespace ScoutingApp2020
    {
        public class DataHandler
        {
            //START
            public string scoutNameEntry { get; set; }
            public int matchNoEntry { get; set; }
            public int replayToggle { get; set; }
            public int teamNoEntry { get; set; }
            public string allianceColor { get; set; }
            public int StartPosEntry { get; set; }
            public int numPreloadsEntry { get; set; }
            //SANDSTORM
            public int initCross { get; set; }
            public int autoCollected { get; set; } = 0;
            public int autoMissed { get; set; } = 0;
            public int autoDropped { get; set; } = 0;
            public int autoInner { get; set; } = 0;
            public int autoOuter { get; set; } = 0;
            public int SandPanelShip { get; set; } = 0;
            public int SandPanelRocket1 { get; set; } = 0;
            public int SandPanelRocket2 { get; set; } = 0;
            public int SandPanelRocket3 { get; set; } = 0;
            public int SandPanelDrop { get; set; } = 0;
            //SANDSTORM & TELEOP
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

            private readonly string filePath;
            private readonly string fullDataName;
            private readonly string partialDataPrefix;

            private int partialDataNum;
            private string dataString;

            public DataHandler(string filePath, string fullDataName, string partialDataPrefix)
            {
                this.filePath = filePath;
                this.fullDataName = fullDataName;
                this.partialDataPrefix = partialDataPrefix;
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