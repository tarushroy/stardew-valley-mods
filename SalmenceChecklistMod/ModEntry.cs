using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace SalmenceChecklistMod
{
    // the mod entry point
    public class ModEntry : Mod
    {
        // mod assets
        public static Texture2D checklist;
        public static Texture2D cross;

        // is the checklist display active?
        public static bool isOpen = false;

        // the mod configuration from the player
        private ModConfig Config;

        // mod entry point, called after mod is first loaded
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;

            this.Config = this.Helper.ReadConfig<ModConfig>();

            // load mod assets
            checklist = helper.Content.Load<Texture2D>("assets/checklist.png", ContentSource.ModFolder);
            cross = helper.Content.Load<Texture2D>("assets/cross.png", ContentSource.ModFolder);

            ChecklistMenu.ModHelper = this.Helper;
        }

        // raised after the game is launched. right before the first update tick
        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu is null)
                return;

            // register mod
            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.Config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.Config)
            );

            // add some config options
            configMenu.AddKeybindList(
                mod: this.ModManifest,
                getValue: () => this.Config.Key,
                setValue: value => this.Config.Key = value,
                name: () => "Checklist Key Binding"
            );
        }

        // raised after the player presses a button on the keyboard, controller or mouse
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            if (this.Config.Key.JustPressed())
            {
                if (isOpen)
                {
                    Game1.exitActiveMenu();
                    isOpen = false;
                }
                else
                {
                    Game1.activeClickableMenu = new ChecklistMenu();
                    isOpen = true;
                }
            }

            if (e.Button == SButton.E)
            {
                if (isOpen)
                    isOpen = false;
            }

            if (e.Button == SButton.Escape)
            {
                if (isOpen)
                    isOpen = false;
            }
        }
    }
}
