using Anneme_Holzhausen_ST10144453_Prog_POE.Core;
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model;
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.View;
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.MVM.View_Model
{
    internal class MainViewModelClass : ObservableObjectClass
    {
        public ObservableCollection<RecipeClass> Recipes { get; set; }
        public string StepDescription { get; set; }
        public string RecipeName { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string IngredientName { get; set; }
        public string Calories { get; set; }
        public string FoodGroup { get; set; }
        public RelayCommandClass HomeViewCommand { get; set; }
        public RelayCommandClass RecipeNewCommand { get; set; }

        public RelayCommandClass ViewAllRecipesCommand { get; set; }

        public object _currentView; 
        public HomeViewModelClass HomeVM { get; set; }

        public NewRecipeBitch NewRecipeVM { get; set; }

        public ViewAllRecipesUserControl ViewAllVM { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModelClass() 
        {
            Recipes = new ObservableCollection<RecipeClass>();
            HomeVM = new HomeViewModelClass();
            NewRecipeVM = new NewRecipeBitch();
            ViewAllVM = new ViewAllRecipesUserControl();
            CurrentView = HomeVM;
            HomeViewCommand = new RelayCommandClass(o => 
            {
                CurrentView = HomeVM;
            });

            RecipeNewCommand = new RelayCommandClass(o =>
            {
                CurrentView = NewRecipeVM;
            });

            ViewAllRecipesCommand = new RelayCommandClass(o =>
            {
                CurrentView = ViewAllVM;
            });
        }


    }
}
