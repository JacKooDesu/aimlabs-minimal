using System.Linq;
using Realms;

namespace ALM.Util
{
    public static class RealmWrapper
    {
        public static void AddPropertyFor(
            this Realm realm,
            string model,
            string propertyName,
            RealmValue value)
        {
            realm.DynamicApi.All(model)
                .ToList()
                .ForEach(x => x.DynamicApi.Set(propertyName, value));
        }

        public static IRealmObject[] AllAsArr(
            this Realm realm, string model) =>
            realm.DynamicApi.All(model).ToArray();

        public static RealmValue Object(object value) => (RealmValue)value;
        public static RealmValue Bool(bool value) => value;
    }
}