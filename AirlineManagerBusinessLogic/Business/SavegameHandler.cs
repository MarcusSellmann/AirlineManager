using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AirlineManager.Business {
	public class SavegameHandler {
		const string SAVEGAME_SUBPATH = @"\AirlineManager\Savegames\";
		const string SAVEGAME_FILE_EXTENSION = ".dat";

        #region Attributes
        #endregion

        #region Properties
        public static string FullSavegameFolderPath {
            get {
                return string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), SAVEGAME_SUBPATH);
            }
        }
		#endregion

		public static void SaveGame(MainGameController mgc, string savegameName) {
            if (!Directory.Exists(FullSavegameFolderPath)) {
                Directory.CreateDirectory(FullSavegameFolderPath);
            }
			
			using (FileStream fs = File.Create(CreateFullSavegamePath(savegameName))) {
				byte[] info = BinarySerializer.Serialize(mgc);
                fs.Write(info, 0, info.Length);
			}
		}

		public static bool LoadGame(string savegameName) {
			if (DoesSavegameExist(savegameName)) {
                byte[] sg = File.ReadAllBytes(CreateFullSavegamePath(savegameName));
                MainGameController.Instance = BinarySerializer.Deserialize<MainGameController>(sg);

                return true;
			}

			return false;
		}

        public static bool DoesSavegameExist(string savegameName) {
            return File.Exists(CreateFullSavegamePath(savegameName));
        }

        public static bool DoesAnySavegameExist() {
            return GetAvailableSavegames().Count > 0;
        }

        public static List<string> GetAvailableSavegames() {
            List<string> sg = new List<string>();

            sg.AddRange(Directory.GetFiles(FullSavegameFolderPath));

            return sg;
        }

        private static string CreateFullSavegamePath(string savegameName) {
            return string.Concat(FullSavegameFolderPath, savegameName, SAVEGAME_FILE_EXTENSION);
        }
    }
}
