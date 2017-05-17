using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SpotTerm.Utils;

namespace SpotTerm.Model
{
    class StackEvent : BindableBase
    {
        private Card _card;
        private string _eventInfo;
        private bool _status;

        public Card Card
        {
            get { return _card; }
            set
            {
                SetProperty(ref _card, value);
                OnPropertyChanged("Card");
            }
        }

        public bool Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
                OnPropertyChanged("Status");
            }
        }

        public string EventInfo
        {
            get { return _eventInfo; }
            set
            {
                SetProperty(ref _eventInfo, value);
                OnPropertyChanged("EventInfo");
            }
        }

        public StackEvent(Card card)
        {
            _card = card;
            TimeSpan? duration = EventHelper.calculateDuration(DateTime.Now, card.PropTime);
            if (duration != null)
            {
                if (duration?.Minutes < 30)
                {
                    Status = true;
                }
                else
                {
                    Status = false;
                }
            }
            
            
            _eventInfo = card.ClientName + " " + card.PropTime;
        }
    }
}
