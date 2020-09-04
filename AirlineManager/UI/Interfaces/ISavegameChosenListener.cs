using AirlineManager.UI.Windows.Popover;

namespace AirlineManager.UI.Interfaces {
    public interface ISavegameChosenListener {
        void SavegameChosenSuccessful(ChooseSavegameWindow.SavegameProcess process, string savegameName);
        void SavegameChooseAborted();
    }
}
