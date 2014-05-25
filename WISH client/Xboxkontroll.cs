/* 
 * Programmerare:
 * Robin Holmbom
 * Tore Landen
 * Herman Molinder
 * 
 * Datum: 2014-05-25
 * Version 1.0
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WISH_client
{
    class Xboxkontroll
    {
        private PlayerIndex _player;
        private GamePadState _kontroll;

        public Xboxkontroll(PlayerIndex player)
        {
            _player = player;
        }

        //Läser av kontrollen
        public void TickUpdate()
        {
            _kontroll = GamePad.GetState(_player);
            if (!_kontroll.IsConnected)
                throw new ArgumentException("Kontrollen är inte ansluten!");
        }

        /// <summary>
        /// Metod som läser av kontrollens X koordinat på vänstra spaken.
        /// Omvandlar sedan detta värde till något värde i intervallet [-30 -5] eller 0 eller [5 30] som int.
        /// </summary>
        /// <returns>Översatt värde av vänstra spakens X värde</returns>
        public SByte GetLeftX()
        {
            SByte temp = (SByte)(-(_kontroll.ThumbSticks.Left.X * 30));

            if (Math.Abs(temp) < 5)
                return 0;
            else
                return temp;
        }

        /// <summary>
        /// Metod som läser av kontrollens Y koordinat på vänstra spaken.
        /// Omvandlar sedan detta värde till något värde i intervallet [-40 -5] eller 0 eller [5 40] som int.
        /// </summary>
        /// <returns>Översatt värde av vänstra spakens Y värde</returns>
        public SByte GetLeftY()
        {
            SByte temp = (SByte)(_kontroll.ThumbSticks.Left.Y * 40);

            if (Math.Abs(temp) < 5)
                return 0;
            else
                return temp;
        }

        /// <summary>
        /// Metod som läser av kontrollens X koordinat på högra spaken.
        /// Omvandlar sedan detta värde till något värde i intervallet [-100 -10] eller 0 eller [10 -100] som int.
        /// </summary>
        /// <returns>Översatt värde av högra spakens X värde</returns>
        public SByte GetRightX()
        {
            SByte temp = (SByte)(_kontroll.ThumbSticks.Right.X * (100 - 65*Math.Abs(_kontroll.ThumbSticks.Left.Y))); //Lite osäker här om det verkligen var 0->100 på rotationen.

            if (Math.Abs(_kontroll.ThumbSticks.Right.X) < 0.1)
                return 0;
            else
                return temp;
        }

        /// <summary>
        /// Metod som läser av kontrollens Y koordinat på högra spaken.
        /// Omvandlar sedan detta värde till något värde i intervallet [-100 -10] eller 0 eller [10 -100] som int.
        /// </summary>
        /// <returns>Översatt värde av högra spakens Y värde</returns>
        public int GetRightY()
        {
            int temp = (int)(_kontroll.ThumbSticks.Right.Y * 100);

            if (Math.Abs(temp) < 10)
                return 0;
            else
                return temp;
        }

        /// <summary>
        /// Kontrollerar om X är nedtryckt.
        /// </summary>
        /// <returns>True om X är nedtryckt, False annars.</returns>
        public bool XPressedDown()
        {
            return _kontroll.Buttons.X == ButtonState.Pressed;
        }

        /// <summary>
        /// Kontrollerar om Y är nedtryckt.
        /// </summary>
        /// <returns>True om Y är nedtryckt, False annars.</returns>
        public bool YPressedDown()
        {
            return _kontroll.Buttons.Y == ButtonState.Pressed;
        }

        /// <summary>
        /// Kontrollerar om A är nedtryckt.
        /// </summary>
        /// <returns>True om A är nedtryckt, False annars.</returns>
        public bool APressedDown()
        {
            return _kontroll.Buttons.A == ButtonState.Pressed;
        }

        /// <summary>
        /// Kontrollerar om B är nedtryckt.
        /// </summary>
        /// <returns>True om B är nedtryckt, False annars.</returns>
        public bool BPressedDown()
        {
            return _kontroll.Buttons.B == ButtonState.Pressed;
        }
    }
}
