//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.MVM.View
{
    public partial class NewRecipeBitch : UserControl
    {
        List<RecipeClass> RecipeList = new List<RecipeClass>();
        private RecipeClass recipe;  // Member variable to store the RecipeClass instance
        private bool isRecipeInProgress = false;
        //------------------------------------------Default Constructor------------------------------------------//
        public NewRecipeBitch()
        {
            InitializeComponent();

            // Create an instance of RecipeClass and set it as the DataContext
            DataContext = new RecipeClass();
        }
        //------------------------------------------Recipe Name Save Button------------------------------------------//
        private void RecipeNameSaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is already in progress
            if (isRecipeInProgress)
            {
                MessageBox.Show("Please finish the current recipe before starting a new one.");
                return;
            }

            string recipeName = RecipeNameTextBox.Text;

            // Create a new instance of RecipeClass
            recipe = new RecipeClass() { RecipeName = recipeName };

            // Set the RecipeClass instance as the DataContext
            DataContext = recipe;

            RecipeNameTextBox.IsEnabled = false;
            isRecipeInProgress = true;
        }
        //------------------------------------------Save Ingredient Button------------------------------------------//
        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Access the Recipe object from the DataContext
            RecipeClass recipe = (RecipeClass)DataContext;

            // Check if the recipe object is null or not in progress
            if (recipe == null || !isRecipeInProgress)
            {
                MessageBox.Show("No recipe in progress.");
                return;
            }

            // Retrieve the ingredient information entered by the user
            string ingredientName = IngredientNameTextBox.Text;

            if (!int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Invalid quantity. Please enter a valid integer value.");
                return;
            }

            string unitOfMeasurement = UnitMeasurementTextBox.Text;

            if (!int.TryParse(CaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Invalid calories. Please enter a valid integer value.");
                return;
            }

            string foodGroup = FoodGroupTextBox.Text;

            // Create an instance of the IngredientClass with the data
            IngredientClass ingredient = new IngredientClass()
            {
                IngredientName = ingredientName,
                Quantity = quantity,
                UnitOfMeasurement = unitOfMeasurement,
                Calories = calories,
                FoodGroup = foodGroup
            };

            // Add the ingredient to the IngredientsList of the current recipe
            recipe.IngredientsList.Add(ingredient);

            // Show a success message
            MessageBox.Show("Ingredient saved successfully.");

            // Clear the ingredient input fields
            IngredientNameTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            UnitMeasurementTextBox.Text = string.Empty;
            CaloriesTextBox.Text = string.Empty;
            FoodGroupTextBox.Text = string.Empty;
        }
        //------------------------------------------Save Recipe Button------------------------------------------//
        private void StepSaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Access the Recipe object from the DataContext
            RecipeClass recipe = (RecipeClass)DataContext;

            // Check if the recipe object is null or not in progress
            if (recipe == null || !isRecipeInProgress)
            {
                MessageBox.Show("No recipe in progress.");
                return;
            }

            // Retrieve the step description entered by the user
            string stepDescription = StepDescriptionTextBox.Text;

            // Create an instance of the StepClass with the data
            StepClass step = new StepClass()
            {
                Description = stepDescription
            };

            // Add the step to the StepsList of the current recipe
            recipe.StepsList.Add(step);

            // Show a success message
            MessageBox.Show("Step saved successfully.");

            // Clear the step input field
            StepDescriptionTextBox.Text = string.Empty;
        }
        //------------------------------------------Button to save user input to recipe object------------------------------------------//
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Access the Recipe object from the DataContext
            recipe = (RecipeClass)DataContext;

            // Check if the recipe object is null or not in progress
            if (recipe == null || !isRecipeInProgress)
            {
                MessageBox.Show("No recipe in progress.");
                return;
            }

            // Construct the recipe information string
            StringBuilder recipeInfo = new StringBuilder();
            recipeInfo.AppendLine($"Recipe Name: {recipe.RecipeName}");

            // Check if the IngredientsList property is not null
            if (recipe.IngredientsList != null && recipe.IngredientsList.Count > 0)
            {
                recipeInfo.AppendLine("Ingredients:");
                foreach (IngredientClass ingredient in recipe.IngredientsList)
                {
                    recipeInfo.AppendLine($"- {ingredient.IngredientName}, " +
                        $"Quantity: {ingredient.Quantity}, " +
                        $"Unit: {ingredient.UnitOfMeasurement}, " +
                        $"Calories: {ingredient.Calories}, " +
                        $"Food Group: {ingredient.FoodGroup}");
                }
            }

            // Check if the StepsList property is not null
            if (recipe.StepsList != null && recipe.StepsList.Count > 0)
            {
                recipeInfo.AppendLine("Steps:");
                int stepNumber = 1;
                foreach (StepClass step in recipe.StepsList)
                {
                    recipeInfo.AppendLine($"Step {stepNumber}: {step.Description}");
                    stepNumber++;
                }
            }

            // Display the recipe information in a message box
            MessageBox.Show(recipeInfo.ToString(), "Recipe Information");

            // Enable the recipe name input field
            RecipeNameTextBox.IsEnabled = true;

            // Clear the recipe name input field
            RecipeNameTextBox.Text = string.Empty;

            // Set the flag to indicate that the recipe is no longer in progress
            isRecipeInProgress = false;
        }

    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//