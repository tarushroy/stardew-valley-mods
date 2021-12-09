using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace SalmenceChecklistMod
{
    public class ChecklistMenu : IClickableMenu
    {
        private ClickableTextureComponent OkButton;
        private Dictionary<ClickableComponent, bool> Buttons = new Dictionary<ClickableComponent, bool>();

        private ModData data = new();

        public static IModHelper ModHelper;

        private readonly int box_size = 40;

        public ChecklistMenu() : base(Game1.viewport.Width / 2, Game1.viewport.Height / 2, 1, 1)
        {
            this.Display();
        }

        private void Display()
        {
            this.OkButton = new ClickableTextureComponent("OK", new Rectangle(1656, 946, Game1.tileSize, Game1.tileSize), "", null, Game1.mouseCursors, Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 46), 1f);

            // Spring
            // Farming
            this.Buttons.Add(new ClickableComponent(new Rectangle(198, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(238, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(276, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(318, 406, box_size, box_size), ""), false);

            // Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(365, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(405, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(445, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(485, 406, box_size, box_size), ""), false);

            // Quality Crop
            this.Buttons.Add(new ClickableComponent(new Rectangle(323, 446, box_size, box_size), ""), false);

            // Fishing
            this.Buttons.Add(new ClickableComponent(new Rectangle(232, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(288, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(342, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(396, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(448, 534, box_size, box_size), ""), false);

            // Other
            this.Buttons.Add(new ClickableComponent(new Rectangle(220, 622, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(290, 622, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(392, 622, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(472, 622, box_size, box_size), ""), false);


            // Summer
            // Farming
            this.Buttons.Add(new ClickableComponent(new Rectangle(582, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(622, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(662, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(702, 406, box_size, box_size), ""), false);

            // Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(773, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(824, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(870, 404, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(909, 403, box_size, box_size), ""), false);

            // Other Farming/Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(674, 451, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(717, 447, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(799, 451, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(840, 451, box_size, box_size), ""), false);

            // Fishing
            this.Buttons.Add(new ClickableComponent(new Rectangle(613, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(672, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(733, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(800, 534, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(862, 534, box_size, box_size), ""), false);

            // Other
            this.Buttons.Add(new ClickableComponent(new Rectangle(580, 625, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(644, 625, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(702, 625, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(767, 625, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(831, 625, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(900, 625, box_size, box_size), ""), false);

            // Fall
            // Farming
            this.Buttons.Add(new ClickableComponent(new Rectangle(971, 404, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1009, 405, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1046, 405, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1085, 405, box_size, box_size), ""), false);

            // Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(1162, 405, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1201, 405, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1240, 406, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1276, 406, box_size, box_size), ""), false);

            // Quality Crop
            this.Buttons.Add(new ClickableComponent(new Rectangle(1108, 450, box_size, box_size), ""), false);

            // Fishing
            this.Buttons.Add(new ClickableComponent(new Rectangle(1080, 535, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1159, 534, box_size, box_size), ""), false);

            // Other
            this.Buttons.Add(new ClickableComponent(new Rectangle(994, 624, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1074, 622, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1145, 623, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1203, 621, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1259, 619, box_size, box_size), ""), false);


            // Winter
            // Farming / Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(1358, 423, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1425, 423, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1482, 425, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1541, 426, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1600, 427, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1668, 427, box_size, box_size), ""), false);

            // Other
            this.Buttons.Add(new ClickableComponent(new Rectangle(1430, 624, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1518, 624, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1602, 624, box_size, box_size), ""), false);


            // Anytime
            // Mining
            this.Buttons.Add(new ClickableComponent(new Rectangle(277, 759, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(345, 758, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(418, 758, box_size, box_size), ""), false);

            this.Buttons.Add(new ClickableComponent(new Rectangle(222, 801, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(267, 802, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(316, 801, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(374, 801, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(428, 802, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(476, 801, box_size, box_size), ""), false);

            this.Buttons.Add(new ClickableComponent(new Rectangle(254, 846, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(333, 846, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(404, 846, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(452, 845, box_size, box_size), ""), false);

            // Crab Pot
            this.Buttons.Add(new ClickableComponent(new Rectangle(249, 962, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(297, 962, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(348, 962, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(404, 961, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(450, 960, box_size, box_size), ""), false);

            // Fishing
            this.Buttons.Add(new ClickableComponent(new Rectangle(569, 758, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(626, 758, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(682, 758, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(733, 758, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(590, 807, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(646, 806, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(704, 804, box_size, box_size), ""), false);

            // Exotic Foraging
            this.Buttons.Add(new ClickableComponent(new Rectangle(570, 915, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(647, 914, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(728, 916, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(609, 967, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(689, 964, box_size, box_size), ""), false);

            // Construction
            this.Buttons.Add(new ClickableComponent(new Rectangle(832, 783, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(931, 782, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1029, 783, box_size, box_size), ""), false);

            // Animals
            this.Buttons.Add(new ClickableComponent(new Rectangle(810, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(849, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(893, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(943, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(988, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1036, 888, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1097, 887, box_size, box_size), ""), false);

            // Artisan
            this.Buttons.Add(new ClickableComponent(new Rectangle(840, 972, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(880, 972, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(919, 972, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(963, 972, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1005, 972, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1042, 972, box_size, box_size), ""), false);

            // Bulletin Board
            this.Buttons.Add(new ClickableComponent(new Rectangle(1196, 804, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1271, 804, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1323, 803, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1418, 801, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1556, 800, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1632, 803, box_size, box_size), ""), false);

            // Vault
            this.Buttons.Add(new ClickableComponent(new Rectangle(1220, 952, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1336, 955, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1463, 955, box_size, box_size), ""), false);
            this.Buttons.Add(new ClickableComponent(new Rectangle(1584, 955, box_size, box_size), ""), false);
        }

        private void CopyToData()
        {
            List<bool> temp = new();

            foreach(KeyValuePair<ClickableComponent, bool> button in Buttons)
            {
                temp.Add(button.Value);
            }

            data.Data = temp;
        }

        private void CopyToButtons()
        {
            int i = 0;
            foreach (KeyValuePair<ClickableComponent, bool> button in Buttons)
            {
                Buttons[button.Key] = data.Data[i];
                i++;
            }
        }

        public override void performHoverAction(int x, int y)
        {
            this.OkButton.scale = this.OkButton.containsPoint(x, y)
                ? Math.Min(this.OkButton.scale + 0.02f, this.OkButton.baseScale + 0.1f)
                : Math.Max(this.OkButton.scale - 0.02f, this.OkButton.baseScale);
        }

        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            if(this.OkButton.containsPoint(x, y))
            {
                this.OkButton.scale -= 0.25f;
                this.OkButton.scale = Math.Max(0.75f, this.OkButton.scale);

                Game1.exitActiveMenu();
                ModEntry.isOpen = false;
            }

            foreach(KeyValuePair<ClickableComponent, bool> button in Buttons)
            {
                if (button.Key.containsPoint(x, y))
                    Buttons[button.Key] = button.Value ? false : true;
            }

            if(Context.IsMainPlayer)
            {
                CopyToData();
                ModHelper.Data.WriteSaveData<ModData>("checklist-key", this.data);
            }
        }

        public override void draw(SpriteBatch b)
        {
            Game1.drawDialogueBox(this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, false, true);
            b.Draw(ModEntry.checklist, new Vector2(0, 0), Color.White);

            if(Context.IsMainPlayer)
            {
                var readData = ModHelper.Data.ReadSaveData<ModData>("checklist-key");
                if (readData is not null)
                {
                    this.data = readData;
                    CopyToButtons();
                }
            }

            foreach (KeyValuePair<ClickableComponent, bool> button in Buttons)
            {
                if(button.Value)
                    b.Draw(ModEntry.cross, new Vector2(button.Key.bounds.X, button.Key.bounds.Y), Color.White);
            }

            this.OkButton.draw(b);
            this.drawMouse(b);
        }
    }
}
