using System;
using System.IO;
using System.Text;

namespace AirlineManager.Business {
	public class SavegameHandler {
		const string SAVEGAME_SUBPATH = @"\AirlineManager\Savegames\";
		const string SAVEGAME_FILENAME = "save";
		const string SAVEGAME_FILE_EXTENSION = ".dat";

        #region Attributes
        #endregion

        #region Properties
        public static string FullSavegameFolderPath { get => string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), SAVEGAME_SUBPATH); }

        public static string FullSavegamePath { get => string.Concat(FullSavegameFolderPath, SAVEGAME_FILENAME, SAVEGAME_FILE_EXTENSION); }

		public static bool DoesSavegameExists { get => File.Exists(FullSavegamePath); }
		#endregion

		public static void SaveGame(MainGameController mgc) {
            if (!Directory.Exists(FullSavegameFolderPath)) {
                Directory.CreateDirectory(FullSavegameFolderPath);
            }
			
			using (FileStream fs = File.Create(FullSavegamePath)) {
				byte[] info = BinarySerializer.Serialize(mgc);
                fs.Write(info, 0, info.Length);
			}
		}

		public static bool LoadGame() {
			if (DoesSavegameExists) {
                byte[] sg = File.ReadAllBytes(FullSavegamePath);
                MainGameController.Instance = BinarySerializer.Deserialize<MainGameController>(sg);

                return true;
			}

			return false;
		}
	}
}
