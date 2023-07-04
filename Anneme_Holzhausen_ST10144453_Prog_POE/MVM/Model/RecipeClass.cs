//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model
{
    //Look no static! 
    public class RecipeClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Recipe Name String
        /// </summary>
        public string RecipeName { get; set; }
        /// <summary>
        /// List for Ingredients
        /// </summary>
        public List<IngredientClass> IngredientsList { get; set; }
        /// <summary>
        /// List for steps
        /// </summary>
        public List<StepClass> StepsList { get; set; }
        /// <summary>
        /// The amount of an ingredients unit of measurement 
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Unit of measurement
        /// </summary>
        public string UnitOfMeasurement { get; set; }
        /// <summary>
        /// Name of ingredient
        /// </summary>
        public string IngredientName { get; set; }
        /// <summary>
        /// Calories in an ingredient
        /// </summary>
        public int Calories { get; set; }
        /// <summary>
        /// Food group ingredient belongs in
        /// </summary>
        public string FoodGroup { get; set; }
        /// <summary>
        /// Description of step
        /// </summary>
        public string StepDescription { get; set; }
        //------------------------------------------Default Constructor------------------------------------------//
        public RecipeClass()
        {
            // Initialize the IngredientsList and StepsList
            IngredientsList = new List<IngredientClass>();
            StepsList = new List<StepClass>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
        //------------------------------------------Ingredient Class------------------------------------------//
        /// <summary>
        /// Variables for ingredient object
        /// </summary>
    public class IngredientClass
    {
        public string IngredientName { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
        //------------------------------------------Step Class------------------------------------------//
        /// <summary>
        /// Variables for step object
        /// </summary>
    public class StepClass
    {
        public string Description { get; set; }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//