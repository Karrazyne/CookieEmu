// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using D2OSync.D2o;

namespace D2OSync.Datacenter
{
    [D2oClass("Pets")]
    public class Pet : IDataObject
    {
        public const string MODULE = "Pets";
        public List<int> FoodItems;
        public List<int> FoodTypes;
        public int Id;
        public int MaxDurationBeforeMeal;
        public int MinDurationBeforeMeal;
        public List<EffectInstance> PossibleEffects;
    }
}