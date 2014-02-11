using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPG;

namespace MapBuilder
{
    public class UI
    {
        public List<Button> Buttons { get; set; }
        public UI()
        {

        }
        public void addButon(Button btn)
        {
            Buttons.Add(btn);
        }
        public void removeButton(Button btn)
        {
            Buttons.Remove(btn);
        }
    }
}
