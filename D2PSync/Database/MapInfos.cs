using System.Collections.Generic;
using D2PSync.Data;

namespace D2PSync.Database
{
    public class MapInfos
    {
        public int MapId { get; set; }
        public int RelativeId { get; set; }
        public int SubAreaId { get; set; }
        public int TopNeighbourId { get; set; }
        public int BottomNeighbourId { get; set; }
        public int LeftNeighbourId { get; set; }
        public int RightNeighbourId { get; set; }
        public List<uint> BluePlacement { get; set; }
        public List<uint> RedPlacement { get; set; }

        private Map Map { get; }

        public MapInfos(Map map)
        {
            Map = map;
            BluePlacement = new List<uint>();
            RedPlacement = new List<uint>();
        }

        public void SetMap()
        {
            MapId = Map.Id;
            RelativeId = Map.RelativeId;
            SubAreaId = Map.SubAreaId;
            TopNeighbourId = Map.TopNeighbourId;
            BottomNeighbourId = Map.BottomNeighbourId;
            LeftNeighbourId = Map.LeftNeighbourId;
            RightNeighbourId = Map.RightNeighbourId;
            foreach (var cell in Map.Cells)
            {
                if (cell.Blue)
                    BluePlacement.Add(cell.Id);
                else if (cell.Red)
                    RedPlacement.Add(cell.Id);
            }
        }

        public string GenerateQuery()
        {
            return
                $"INSERT INTO world_maps SET MapId = '{MapId}', RelativeId = '{RelativeId}', SubAreaId = '{SubAreaId}', TopNeighbourId = '{TopNeighbourId}', BottomNeighbourId = '{BottomNeighbourId}', LeftNeighbourId = '{LeftNeighbourId}', RightNeighbourId = '{RightNeighbourId}', BluePlacement = '{string.Join(",", BluePlacement)}', RedPlacement = '{string.Join(",", RedPlacement)}'";
        }
    }
}
