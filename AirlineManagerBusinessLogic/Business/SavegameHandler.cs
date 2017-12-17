using System;
using System.IO;
using System.Text;

namespace AirlineManager.Business {
	public class SavegameHandler {
		const string SAVEGAME_SUBPATH = "\\AirlineManager\\Savegames\\";
		const string SAVEGAME_FILENAME = "save";
		const string SAVEGAME_FILE_EXTENSION = ".dat";

		#region Attributes
		#endregion

		#region Properties
		public static string FullSavegamePath {
			get {
				string currUserDocPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
				return currUserDocPath + SAVEGAME_SUBPATH + SAVEGAME_FILENAME + SAVEGAME_FILE_EXTENSION;
			}
		}

		public static bool DoesSavegameExists {
			get {
				return File.Exists(FullSavegamePath);
			}
		}
		#endregion

		public static void SaveGame() {
			// TODO: Adapt this example to the real purpose!
			using (FileStream fs = File.Create(FullSavegamePath)) {
				byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
				fs.Write(info, 0, info.Length);
			}
		}

		public static bool LoadGame() {
			if (DoesSavegameExists) {
				// TODO: Adapt this example to the real purpose!
				using (StreamReader sr = File.OpenText(FullSavegamePath)) {
					string s = "";
					while ((s = sr.ReadLine()) != null) {
						Console.WriteLine(s);
					}
				}

				return true;
			}

			return false;
		}
	}
}
