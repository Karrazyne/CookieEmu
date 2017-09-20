﻿#region License GNU GPL
// BoundingBoxGraphicalElementData.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion

using System.ComponentModel;
using CookieEmu.API.IO;

namespace EleReader.Datas
{
    public class BoundingBoxGraphicalElementData : NormalGraphicalElementData, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BoundingBoxGraphicalElementData(EleInstance instance, int id) : base(instance, id)
        {
        }

        public override EleGraphicalElementTypes Type => EleGraphicalElementTypes.BOUNDING_BOX;

        public static BoundingBoxGraphicalElementData ReadFromStream(EleInstance instance, int id, BigEndianReader reader)
        {
            var data = new BoundingBoxGraphicalElementData(instance, id)
            {
                Gfx = reader.ReadInt(),
                Height = reader.ReadByte(),
                HorizontalSymmetry = reader.ReadBoolean(),
                Origin = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort()),
                Size = new System.Drawing.Point(reader.ReadShort(), reader.ReadShort())
            };


            return data;
        }
    }
}