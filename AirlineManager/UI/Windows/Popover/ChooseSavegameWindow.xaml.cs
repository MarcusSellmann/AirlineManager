using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

using AirlineManager.Business;
using AirlineManager.UI.Interfaces;

namespace AirlineManager.UI.Windows.Popover {
    /// <summary>
    /// Interaktionslogik für ChooseSavegameWindow.xaml
    /// </summary>
    public partial class ChooseSavegameWindow : MetroWindow, ISavegameOverrideInteractionListener {
        public enum SavegameProcess {
            Save,
            Load
        }

        private class Savegame {
            public string FullPath { get; private set; }
            public string Name { get; private set; }
            public DateTime LastModified { get; private set; }

            public Savegame(string fullPath, string name, DateTime lastModified) {
                FullPath = fullPath;
                Name = name;
                LastModified = lastModified;
            }
        }

        ISavegameChosenListener m_listener = null;
        SavegameProcess m_process;

        ObservableCollection<Savegame> m_savegames = new ObservableCollection<Savegame>();

        public ChooseSavegameWindow(ISavegameChosenListener listener, SavegameProcess process) {
            m_listener = listener;
            m_process = process;

            InitializeComponent();

            lvSavegames.ItemsSource = m_savegames;

            List<string> sgs = SavegameHandler.GetAvailableSavegames();

            foreach (string sg in sgs) {
                m_savegames.Add(new Savegame(sg, Path.GetFileNameWithoutExtension(sg), File.GetLastWriteTime(sg)));
            }

            btnOk.IsEnabled = false;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e) {
            if (m_process == SavegameProcess.Save) {
                if (SavegameHandler.DoesSavegameExist(tbSavegameName.Text)) {
                    new SavegameAlreadyExistsWindow(this).Show();
                } else {
                    m_listener.SavegameChosenSuccessful(m_process, tbSavegameName.Text);
                    Close();
                }
            } else if (m_process == SavegameProcess.Load) {
                m_listener.SavegameChosenSuccessful(m_process, tbSavegameName.Text);
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            m_listener.SavegameChooseAborted();
            Close();
        }

        private void tbSavegameName_TextChanged(object sender, TextChangedEventArgs e) {
            if (tbSavegameName.Text.Length > 0) {
                btnOk.IsEnabled = true;
            }
        }

        public void overrideConfirmed() {
            m_listener.SavegameChosenSuccessful(m_process, tbSavegameName.Text);
            Close();
        }

        public void overrideAborted() {
        }

        private void lvSavegames_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            tbSavegameName.Text = ((Savegame)lvSavegames.SelectedItem).Name;
        }
    }
}
