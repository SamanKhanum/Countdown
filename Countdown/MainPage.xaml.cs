using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Countdown
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Setup();
        }

        private List<Event> AllEvents { get; set; }

        private List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event { EventTitle="Barbeque Party", BgColor="#EB9999", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(7, 23, 45, 59).Ticks)},
                new Event { EventTitle="Interview", BgColor="#0097A7", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(47, 12, 12, 59).Ticks)},
                new Event { EventTitle="Family Dinner", BgColor="#7E57C2", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(32, 31, 13, 59).Ticks)},
                new Event { EventTitle="Vacation", BgColor="#EF5350", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(118, 2, 47, 59).Ticks)},
            };
        }

        private void Setup()
        {
            AllEvents = GetEvents();
            eventsList.ItemsSource = AllEvents;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
               {
                   foreach (var evt in AllEvents)
                   {
                       var timespan = evt.Date - DateTime.Now;
                       evt.TimeSpan = timespan;
                   }

                   eventsList.ItemsSource = null;
                   eventsList.ItemsSource = AllEvents;

                   return true;
               });
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public string EventTitle { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public string Days => TimeSpan.Days.ToString("00");
        public string Hours => TimeSpan.Hours.ToString("00");
        public string Minutes => TimeSpan.Minutes.ToString("00");
        public string Seconds => TimeSpan.Seconds.ToString("00");
        public string BgColor { get; set; }
    }
}
