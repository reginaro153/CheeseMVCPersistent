﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

       [Required]
       [Display (Name ="Category")]
       public int CategoryID { get; set; }
       public List<SelectListItem> Categories { get; set; }


        public AddCheeseViewModel()
        {

        }
       

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories){

            Categories= new List<SelectListItem>();

            /*// <option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem {
                Value = ((int) CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });*/
            foreach(var value in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.Name
                });
            }

        }
    }
}
