using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieEmu.Game.SQL.Breeds
{
    [Table("cookieemu.breeds_heads")]
    public class Head
    {
        public int Id { get; set; }

        public int Skins { get; set; }

        public static int GetHeadSkin(int headId)
        {
            using (var context = new HeadModel())
            {
                return (from h in context.heads
                    where h.Id == headId
                    select h).ToList().FirstOrDefault().Skins;
            }
        }
    }
}
