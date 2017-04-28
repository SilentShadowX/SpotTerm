using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotTerm.Utils;

namespace SpotTerm.Model
{
    public class Card : BindableBase
    {
        #region Fields

        private String _clientName;
        private String _placeName;
        private String _description;
        private PriorityMeet _priority;
        private PriorityStatus _status;
        private DateTime? _timeEnd;

        #endregion

        #region Property

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

        public PriorityMeet Priority
        {
            get { return _priority; }
            set
            {
                SetProperty(ref _priority, value);
                OnPropertyChanged("Priority");
            }
        }

        public PriorityStatus Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
                OnPropertyChanged("Status");
            }
        }

        public DateTime? TimeEnd
        {
            get { return _timeEnd; }
            set {
                SetProperty(ref _timeEnd, value);
                OnPropertyChanged("TimeEnd");
            }
        }

        #endregion

        #region Constructor

        public Card(string clientName, string placeName, string description, PriorityMeet priority, PriorityStatus status)
        {
            _clientName = clientName;
            _placeName = placeName;
            _description = description;
            _priority = priority;
            _status = status;
        }

        #endregion

    }
}
