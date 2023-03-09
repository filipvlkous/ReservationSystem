
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC2nd.Models
{
	public class RoomsTimesModel
    {
        public string Name { get; set; }

        public int Open { get; set; }

        public int Close { get; set; }

        private Dictionary<DateTime, List<DateTime>> _times = new Dictionary<DateTime, List<DateTime>>();
        public Dictionary<DateTime, List<DateTime>> Times
        {
            get => _times;
            set => _times = value;
        }

        public RoomsTimesModel(string name,int open,int close)
        {
            Name = name;
            Open = open;
            Close = close;
                
        }

    }
}

