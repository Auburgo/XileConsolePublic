using Newtonsoft.Json;

static class Util
{
    public static string JsonPrettify(string json)
    {
        using (var stringReader = new StringReader(json))
        using (var stringWriter = new StringWriter())
        {
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }
    }

    static Dictionary<ItemType, string> map = new Dictionary<ItemType, string>()
    {
        {ItemType.Currency, @"https://poe.ninja/api/data/currencyoverview?league=$&type=Currency"},
        {ItemType.Fragment, @"https://poe.ninja/api/data/currencyoverview?league=$&type=Fragment"},
        {ItemType.Oil, @"https://poe.ninja/api/data/itemoverview?league=$&type=Oil"},
        {ItemType.Incubator, @"https://poe.ninja/api/data/itemoverview?league=$&type=Incubator"},
        {ItemType.Scarab, @"https://poe.ninja/api/data/itemoverview?league=$&type=Scarab"},
        {ItemType.Fossil, @"https://poe.ninja/api/data/itemoverview?league=$&type=Fossil"},
        {ItemType.Resonator, @"https://poe.ninja/api/data/itemoverview?league=$&type=Resonator"},
        {ItemType.Essence, @"https://poe.ninja/api/data/itemoverview?league=$&type=Essence"},
        {ItemType.DivCard, @"https://poe.ninja/api/data/itemoverview?league=$&type=DivinationCard"},
        {ItemType.SkillGem, @"https://poe.ninja/api/data/itemoverview?league=$&type=SkillGem"},
        {ItemType.DeliriumOrb, @"https://poe.ninja/api/data/itemoverview?league=$&type=DeliriumOrb"},
        {ItemType.UniqueMap, @"	https://poe.ninja/api/data/itemoverview?league=$&type=UniqueMap"},
        {ItemType.UniqueJewel, @"https://poe.ninja/api/data/itemoverview?league=$&type=UniqueJewel"},
        {ItemType.UniqueFlask, @"https://poe.ninja/api/data/itemoverview?league=$&type=UniqueFlask"},
        {ItemType.UniqueWeapon, @"https://poe.ninja/api/data/itemoverview?league=$&type=UniqueWeapon"},
        {ItemType.UniqueArmour, @"https://poe.ninja/api/data/itemoverview?league=$&type=UniqueArmour"},
        {ItemType.UniqueAccessory, @"https://poe.ninja/api/data/itemoverview?league=$&type=UniqueAccessory"},
        {ItemType.Invitation, @"https://poe.ninja/api/data/itemoverview?league=$&type=Invitation"},
        {ItemType.Beasts, @"https://poe.ninja/api/data/itemoverview?league=$&type=Beast"},
    };


    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }


    public static string GetLink(ItemType type, string league)
    {
        return map[type].Replace("$", league);
    }

    public static float Truncate(this float value, int digits)
    {
        double mult = Math.Pow(10.0, digits);
        double result = Math.Truncate(mult * value) / mult;
        return (float)result;
    }
}


