using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SpotTerm.Model;
using SpotTerm.Utils;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace SpotTerm.ViewModel
{
    class MainPageViewModel : BindableBase
    {
        MetroWindow metroWindow = ((MetroWindow) App.Current.MainWindow as MetroWindow);

        #region Commands

        public ICommand AddCardCommand { get; set; }
        public ICommand DeleteCardCommand { get; set; }

        public ICommand ShowInfoCommand { get; set; }
        public ICommand CompleteCardCommand { get; set; }

        public ICommand LoadFromFile { get; set; }
        public ICommand SaveFromFile { get; set; }

        #endregion

        #region Fields

        private String _clientName;
        private String _placeName;
        private String _description;
        private PriorityMeet _priorityMeet;

        private ObservableCollection<Card> _cardList;
        private Card _selectedCard;
        private ObservableCollection<Card> _cardListCompleted;

        #endregion

        #region Properties

        public ObservableCollection<Card> CardList
        {
            get { return _cardList; }
            set { _cardList = value; }
        }

        public Card SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                SetProperty(ref _selectedCard, value);
                OnPropertyChanged("SelectedCard");
            }
        }

        public ObservableCollection<Card> CardListCompleted
        {
            get { return _cardListCompleted; }
            set { _cardListCompleted = value; }
        }

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                SetProperty(ref _clientName, value);
                OnPropertyChanged("ClientName");
            }
        }

        public string PlaceName
        {
            get { return _placeName; }
            set
            {
                SetProperty(ref _placeName, value);
                OnPropertyChanged("PlaceName");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged("Description");
            }
        }

        public PriorityMeet PriorityMeet
        {
            get { return _priorityMeet; }
            set
            {
                SetProperty(ref _priorityMeet, value);
                OnPropertyChanged("PriorityMeet");
            }
        }

        #endregion

        #region Constructors

        public MainPageViewModel(ObservableCollection<Card> cardList)
        {
            _cardList = cardList;
            _cardListCompleted = new ObservableCollection<Card>();
            AddCardCommand = new RelayCommand(action => AddCardToList());
            DeleteCardCommand = new RelayCommand(action => DeleteCardFromList(action));
            CompleteCardCommand = new RelayCommand(action => SetCardAsCompleted(action), action => isCompleted(action));
            ShowInfoCommand = new RelayCommand(action => ShowInfoCard(action));
            LoadFromFile = new RelayCommand(action => LoadData(action));
            SaveFromFile = new RelayCommand(action => SaveData(action));
        }

        private async void SaveData(object action)
        {
            ProgressDialogController controller = null;

            if (metroWindow != null)
            {
                try
                {
                    var dialog = new SaveFileDialog();
                    var result = dialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        controller = await metroWindow.ShowProgressAsync("Zapis wpisów",
                            "Trwa zapsiywanie wpisów do pliku..",
                            false,
                            new MetroDialogSettings() {AnimateShow = true, ColorScheme = MetroDialogColorScheme.Theme});
                        await Task.Delay(500);
                        var listToSave = new ObservableCollection<Card>();

                        foreach (var card in CardList)
                        {
                            listToSave.Add(card);
                        }
                        foreach (var card in CardListCompleted)
                        {
                            listToSave.Add(card);
                        }

                        DataParser.WriteToJsonFile(dialog.FileName, listToSave, false);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    if (controller != null)
                        await controller.CloseAsync();
                }
            }
        }

        private async void LoadData(object action)
        {
            ProgressDialogController controller = null;

            if (metroWindow != null)
            {
                try
                {
                    var dialog = new OpenFileDialog();
                    bool? result = dialog.ShowDialog();
                    if (result.HasValue)
                    {
                        String fileName = dialog.FileName;
                        controller = await metroWindow.ShowProgressAsync("Ładowanie wpisów",
                            "Trwa ładowanie wpisów z pliku..",
                            false,
                            new MetroDialogSettings() {AnimateShow = true, ColorScheme = MetroDialogColorScheme.Theme});
                        await Task.Delay(1100);
                        var loadedList = DataParser.ReadFromJsonFile<List<Card>>(fileName);
                        CardList.Clear();
                        CardListCompleted.Clear();
                        foreach (var card in loadedList)
                        {
                            if (card.Status == PriorityStatus.Completed)
                            {
                                CardListCompleted.Add(card);
                            }
                            else
                            {
                                CardList.Add(card);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    if (controller != null)
                        await controller.CloseAsync();
                }
            }
        }

        public bool isCompleted(object obj)
        {
            Card card = (Card) obj;
            return card.Status != PriorityStatus.Completed;
        }

        #endregion

        #region Methods

        private async void ShowInfoCard(object itemObj)
        {
            if (itemObj != null)
            {
                Card selectedCardItem = ((Card) itemObj);

                StringBuilder builder = new StringBuilder()
                    .Append("Opis wydarzenia: ")
                    .Append(selectedCardItem.Description)
                    .Append("\n")
                    .Append("Priorytet: ")
                    .Append(DisplayText.ToDescription(selectedCardItem.Priority))
                    .Append("\n")
                    .Append("Status: ")
                    .Append(DisplayText.ToDescription(selectedCardItem.Status));

                if (selectedCardItem.TimeEnd != null)
                {
                    builder
                        .Append("\n")
                        .Append("Data zakończenia: ")
                        .Append(selectedCardItem.TimeEnd);
                }


                await DialogManager.ShowMessageAsync(
                    (MetroWindow) App.Current.MainWindow,
                    "Informacje dodatkowe",
                    builder.ToString());
            }
        }

        private async void AddCardToList()
        {
            if (ClientName != null && PlaceName != null && Description != null)
            {
                ProgressDialogController controller = null;

                if (metroWindow != null)
                {
                    controller = await metroWindow.ShowProgressAsync("Nowy wpis", "Trwa dodawanie nowego wpisu..",
                        false,
                        new MetroDialogSettings() {AnimateShow = true, ColorScheme = MetroDialogColorScheme.Theme});
                    await Task.Delay(1100);

                    CardList.Add(new Card(ClientName, PlaceName, Description, PriorityMeet, PriorityStatus.Progress));
                    ClientName = null;
                    PlaceName = null;
                    Description = null;
                    PriorityMeet = PriorityMeet.Low;

                    if (controller != null)
                        await controller.CloseAsync();
                }
            }
            else
            {
                await DialogManager.ShowMessageAsync(
                    (MetroWindow) App.Current.MainWindow,
                    "Błąd",
                    "Sprawdź spójność danych."
                );
            }
        }


        private async void DeleteCardFromList(object itemObj)
        {
            if (itemObj != null)
            {
                ProgressDialogController controller = null;

                if (metroWindow != null)
                {
                    controller = await metroWindow.ShowProgressAsync("Usuwanie wpisu", "Trwa usuwanie wpisu..",
                        false,
                        new MetroDialogSettings() {AnimateShow = true, ColorScheme = MetroDialogColorScheme.Theme});
                    await Task.Delay(1100);

                    CardList.Remove((Card) itemObj);

                    if (controller != null)
                        await controller.CloseAsync();
                }
            }
        }

        private async void SetCardAsCompleted(object itemObj)
        {
            if (itemObj != null)
            {
                ProgressDialogController controller = null;
                if (metroWindow != null)
                {
                    controller = await metroWindow.ShowProgressAsync("Zakończono",
                        "Trwa przenoszenie wpisu do zakończonych..",
                        false,
                        new MetroDialogSettings() {AnimateShow = true, ColorScheme = MetroDialogColorScheme.Theme});
                    await Task.Delay(1100);

                    Card card = (Card) itemObj;
                    card.Status = PriorityStatus.Completed;
                    card.TimeEnd = DateTime.Now.ToLocalTime();

                    CardListCompleted.Add(card);
                    CardList.Remove(card);

                    if (controller != null)
                        await controller.CloseAsync();
                }
            }
        }

        #endregion
    }
}
