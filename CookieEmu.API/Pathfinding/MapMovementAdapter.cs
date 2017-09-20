using System;
using System.Collections.Generic;
using CookieEmu.API.Pathfinding.Positions;

namespace CookieEmu.API.Pathfinding
{
    public class MapMovementAdapter
    {
        public enum MovementTypeEnum
        {
            Mounted,
            Parable,
            Running,
            Slide,
            Walking
        }

        // Methods
        public static MovementPath GetClientMovement(List<uint> Keys)
        {
            var path = new MovementPath();
            PathElement element = null;
            var num = 0;
            var num2 = 0;
            foreach (int num2_loopVariable in Keys)
            {
                num2 = num2_loopVariable;
                var point = new MapPoint(num2 & 4095);
                var item = new PathElement {Cell = point};
                if (num == 0)
                    path.CellStart = point;
                else
                    element.Orientation = element.Cell.OrientationTo(item.Cell);
                if (num == Keys.Count - 1)
                    path.CellEnd = point;
                path.Cells.Add(item);
                element = item;
                num += 1;
            }
            return path;
        }

        public static List<uint> GetServerMovement(MovementPath Path)
        {
            var list = new List<uint>();
            var orientation = 0;
            foreach (var element in Path.Cells)
            {
                orientation = element.Orientation;
                list.Add(Convert.ToUInt32(((orientation & 7) << 12) | (element.Cell.CellId & 4095)));
            }
            list.Add(Convert.ToUInt32(((orientation & 7) << 12) | (Path.CellEnd.CellId & 4095)));
            return list;
        }
    }
}