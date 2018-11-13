﻿// XAML Map Control - https://github.com/ClemensFischer/XAML-Map-Control
// © 2018 Clemens Fischer
// Licensed under the Microsoft Public License (Ms-PL)

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MapControl
{
    /// <summary>
    /// Container class for an item in a MapItemsControl.
    /// </summary>
    public class MapItem : ListBoxItem
    {
        public MapItem()
        {
            DefaultStyleKey = typeof(MapItem);

            MapPanel.InitMapElement(this);
        }

        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            e.Handled = true;

            (ItemsControl.ItemsControlFromItemContainer(this) as MapItemsControl)?.MapItemClicked(
                this, e.KeyModifiers.HasFlag(VirtualKeyModifiers.Control), e.KeyModifiers.HasFlag(VirtualKeyModifiers.Shift));
        }
    }

    public partial class MapItemsControl
    {
        public MapItem MapItemFromItem(object item)
        {
            return (MapItem)ContainerFromItem(item);
        }

        public object ItemFromMapItem(MapItem mapItem)
        {
            return ItemFromContainer(mapItem);
        }
    }
}
