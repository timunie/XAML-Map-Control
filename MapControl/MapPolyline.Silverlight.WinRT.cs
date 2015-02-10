﻿// XAML Map Control - http://xamlmapcontrol.codeplex.com/
// © 2015 Clemens Fischer
// Licensed under the Microsoft Public License (Ms-PL)

using System.Linq;
#if WINDOWS_RUNTIME
using Windows.UI.Xaml.Media;
#else
using System.Windows.Media;
#endif

namespace MapControl
{
    public partial class MapPolyline
    {
        public MapPolyline()
        {
            Data = new PathGeometry();
        }

        protected override void UpdateData()
        {
            var geometry = (PathGeometry)Data;
            geometry.Figures.Clear();

            if (ParentMap != null && Locations != null && Locations.Any())
            {
                var points = Locations.Select(l => ParentMap.MapTransform.Transform(l));

                var figure = new PathFigure
                {
                    StartPoint = points.First(),
                    IsClosed = IsClosed,
                    IsFilled = IsClosed
                };

                var segment = new PolyLineSegment();

                foreach (var point in points.Skip(1))
                {
                    segment.Points.Add(point);
                }

                figure.Segments.Add(segment);
                geometry.Figures.Add(figure);
                geometry.Transform = ParentMap.ViewportTransform;
            }
            else
            {
                geometry.ClearValue(Geometry.TransformProperty);
            }
        }
    }
}
