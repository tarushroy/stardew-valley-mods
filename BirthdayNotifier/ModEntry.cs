using System;
using System.Collections.Generic;
using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;

namespace SimpleBirthdayNotifications
{
    class ModEntry : Mod
    {
        private Dictionary<string, string> Birthdays = new();

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;

            Dictionary<string, string> NPCData = helper.Content.Load<Dictionary<string, string>>("Data/NPCDispositions", ContentSource.GameContent);
            GetBirthdays(NPCData);
        }

        private void GetBirthdays(Dictionary<string, string> NPCData)
        {
            foreach(KeyValuePair<string, string> npcdata in NPCData)
            {
                string[] values = npcdata.Value.Split('/');
                Birthdays.Add(values[11], values[8]);
            }
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            string date = SDate.Now().Season + " " + SDate.Now().Day.ToString();

            foreach(KeyValuePair<string, string> birthday in Birthdays)
            {
                if (date == birthday.Value)
                    Game1.addHUDMessage(new HUDMessage("It is " + birthday.Key + "'s birthday today!", 2));
            }
        }
    }
}
