using SpotTerm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotTerm.Utils
{
    class EventHelper
    {
        public static TimeSpan? calculateDuration(DateTime date, DateTime? finalDate)
        {
            return finalDate - date;
        }

        public static void DeleteCardEvent(ObservableCollection<StackEvent> EventList,
            Card card)
        {
            //foreach (var current in ToDelete)
            //{
                //if (current.ClientName == card.ClientName)
                //{
                //    ToDelete.Remove(current);
                //}

            
                foreach (var eventCurrent in EventList)
                {
                    if (eventCurrent.Card.ClientName == card.ClientName)
                    {
                        EventList.Remove(eventCurrent);
                        break;
                    }
                }
                
            }
        }
    }

