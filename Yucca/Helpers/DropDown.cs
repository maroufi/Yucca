using System.Collections.Generic;
using System.Web.Mvc;

namespace Yucca.Helpers
{
    public class DropDown
    {

        public static SelectList GetShowTranstionSlide(string showTranstion)
        {

            var list = new List<SelectListItem>
            {
                 new SelectListItem {Text = "--انتخاب--", Value = ""},
                new SelectListItem {Text = "بالا", Value = "up"},
                new SelectListItem {Text = "پایین", Value = "down"},
                new SelectListItem {Text = "چپ", Value = "left"},
                new SelectListItem {Text = "راست", Value = "right"}
            };

            return new SelectList(list, "Value", "Text", showTranstion);
        }
        public static SelectList GetHideTranstionSlide(string hideTranstion)
        {

            var list = new List<SelectListItem>
            {
                new SelectListItem {Text = "--انتخاب--", Value = ""},
                new SelectListItem {Text = "بالا", Value = "up"},
                new SelectListItem {Text = "پایین", Value = "down"},
                new SelectListItem {Text = "چپ", Value = "left"},
                new SelectListItem {Text = "راست", Value = "right"}
            };

            return new SelectList(list, "Value", "Text", hideTranstion);
        }
        public static SelectList GetPositonSlide(string position)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem {Text = "--انتخاب--", Value = ""},
                new SelectListItem {Text = "پایین سمت جپ", Value = "bottomLeft"},
                new SelectListItem {Text = "پایین سمت راست", Value = "bottomRight"},
                new SelectListItem {Text = "بالا سمت چپ", Value = "topLeft"},
                new SelectListItem {Text = "بالا سمت راست", Value = "topRight"},
                new SelectListItem {Text = "وسط وسط", Value = "centerCenter"},
                new SelectListItem {Text = "وسط بالا ", Value = "centerTop"},
                new SelectListItem {Text = "وسط پایین", Value = "centerBottom"}
            };

            return new SelectList(list, "Value", "Text", position);
        }

        public static SelectList GetSearchPageCount(int seleted)
        {

            var list = new List<SelectListItem>
            {
                 new SelectListItem {Text = "12", Value = "12"},
                new SelectListItem {Text = "24", Value = "24"},
                new SelectListItem {Text = "36", Value = "36"},
                new SelectListItem {Text = "48", Value = "48"}
            };

            return new SelectList(list, "Value", "Text", seleted);
        }
    }
}