using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1.Entities
{
    public class MixOption
    {
        public MixOption(string option1, string option2, string option3, string option4)
        {
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
        }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

    }
}
