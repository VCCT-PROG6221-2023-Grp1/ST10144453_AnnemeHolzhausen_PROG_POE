//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.MVM.View
{
    public partial class ViewAllRecipesUserControl : UserControl
    {
        private ICollectionView recipesView;

        public List<RecipeClass> Recipes { get; set; }

        public ViewAllRecipesUserControl()
        {
            InitializeComponent();

            // Assuming RecipeManager is a separate class where RecipeList is stored
            Recipes = RecipeManager.RecipeList;

            // Set the DataContext of the UserControl to itself
            DataContext = this;
        }

        private void LoadRecipes()
        {
            // Assuming RecipeManager is a separate class where RecipeList is stored
            List<RecipeClass> recipes = RecipeManager.RecipeList;

            // Sort the recipes by recipe name
            recipes = recipes.OrderBy(recipe => recipe.RecipeName).ToList();

            // Create a CollectionViewSource and set its Source to the sorted recipes list
            CollectionViewSource sortedRecipes = new CollectionViewSource
            {
                Source = recipes
            };

            // Set the SortDescriptions to sort by RecipeName
            sortedRecipes.SortDescriptions.Add(new SortDescription("RecipeName", ListSortDirection.Ascending));

            // Set the ItemsSource of the ListView to the CollectionViewSource View
            RecipeListView.ItemsSource = sortedRecipes.View;
            recipesView = sortedRecipes.View;

            // Set the ItemsSource of the SavedRecipesListBox to the RecipeList
            SavedRecipesListBox.ItemsSource = null;
            SavedRecipesListBox.ItemsSource = RecipeManager.RecipeList;
        }

    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//