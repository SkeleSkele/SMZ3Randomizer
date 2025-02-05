﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Accessibility;

using Randomizer.SMZ3;
using Randomizer.SMZ3.Tracking.Configuration;

namespace Randomizer.App.ViewModels
{
    public class MarkedLocationViewModel
    {
        private readonly Location _location;
        private readonly ItemData _itemData;
        private readonly TrackerLocationSyncer _syncer;

        public MarkedLocationViewModel(Location location, ItemData itemData, TrackerLocationSyncer syncer)
        {
            _location = location;
            _itemData = itemData;
            _syncer = syncer;
            var fileName = TrackerWindow.GetItemSpriteFileName(itemData);
            ItemSprite = fileName != null ? new BitmapImage(new Uri(fileName)) : null;
        }

        public ImageSource ItemSprite { get; }

        public double Opacity => _syncer.IsLocationClearable(_location) ? 1.0 : 0.33;

        public string Item => _itemData.Name;

        public string Location => _syncer.GetName(_location);

        public string Area => _syncer.GetName(_location.Region);
    }
}
