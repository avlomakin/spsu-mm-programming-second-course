using System;
using UltraTT.ViewModel;

namespace UltraTT.Game.ViewModel
{
    public class ViewModelCell : BaseViewModel
    {


        private string _pictSource;
        public string PictSource
        {
            get
            {
                return _pictSource;
            }
            set
            {
                _pictSource = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Big cell id, position
        /// </summary>
        public Tuple<int, int> Coords { get; set; }
    }
}