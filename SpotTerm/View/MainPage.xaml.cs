using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpotTerm.Model;
using SpotTerm.ViewModel;

namespace SpotTerm.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel(new ObservableCollection<Card>());
            this.DataContext = _viewModel;
        }

//        public static ObservableCollection<Card> CreateFakeCard()
//        {
//            ObservableCollection<Card> collectionFake = new ObservableCollection<Card>();
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "KZKGOP",
//                "Warszawska 23/3",
//                "Spotkanie w celu podpisania umowy na sprzedaż autobusów marki MAN",
//                PriorityMeet.High,
//                PriorityStatus.Progress
//                ));
//            collectionFake.Add(new Card(
//                "TOM BUDEX",
//                "Sopocka 11a",
//                "Podpisanie kontraktu na przebudowe odcinka jezdni miedzy Katowicami a Sosnowcem",
//                PriorityMeet.Low,
//                PriorityStatus.Progress
//                ));
//
//            return collectionFake;
//        }
    }
}
