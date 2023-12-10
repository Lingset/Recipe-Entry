using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Finals
{
    public partial class RecipeEntryPage : Page
    {
        private List<Recipe> recipes = new List<Recipe>(); // Assuming Recipe is a class to hold recipe details

        public RecipeEntryPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // Ensure the recipe name is not empty
            if (string.IsNullOrEmpty(textRecipeName.Text))
            {
                ShowToast("Please enter a recipe name.");
                return;
            }

            // Create a new recipe and add it to the list
            Recipe newRecipe = new Recipe
            {
                RecipeName = textRecipeName.Text,
                Ingredients = textIngredients.Text,
                Instructions = textInstructions.Text
            };

            recipes.Add(newRecipe);
            UpdateRecipeList();

            // Show a toast indicating successful creation
            ShowToast("Recipe created successfully!");

            // Clear input fields
            ClearInputs();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected item from the ListBox
            Recipe selectedRecipe = (Recipe)lstRecipes.SelectedItem;

            if (selectedRecipe != null)
            {
                // Show the selected recipe content in a MessageBox
                string recipeDetails = $"Recipe Name: {selectedRecipe.RecipeName}\nIngredients: {selectedRecipe.Ingredients}\nInstructions: {selectedRecipe.Instructions}";
                MessageBox.Show(recipeDetails, "Recipe Details", MessageBoxButton.OK);
            }
            else
            {
                // Show a message if no recipe is selected
                MessageBox.Show("Please select a recipe to read.", "No Recipe Selected", MessageBoxButton.OK);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Update a selected recipe in the list
            if (lstRecipes.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)lstRecipes.SelectedItem;
                selectedRecipe.RecipeName = textRecipeName.Text;
                selectedRecipe.Ingredients = textIngredients.Text;
                selectedRecipe.Instructions = textInstructions.Text;
                UpdateRecipeList();

                // Show a toast indicating successful update
                ShowToast("Recipe updated successfully!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Delete a selected recipe from the list
            if (lstRecipes.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)lstRecipes.SelectedItem;
                recipes.Remove(selectedRecipe);
                ClearInputs();
                UpdateRecipeList();

                // Show a toast indicating successful deletion
                ShowToast("Recipe deleted successfully!");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Search for a recipe
            string searchText = textRecipeName.Text.ToLower();

            List<Recipe> searchResults = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.RecipeName.ToLower().Contains(searchText))
                {
                    searchResults.Add(recipe);
                }
            }

            lstRecipes.ItemsSource = searchResults;
        }

        private void UpdateRecipeList()
        {
            // Update the ListBox with the list of recipes
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipes;
        }

        private void ClearInputs()
        {
            // Clear input fields
            textRecipeName.Text = "";
            textIngredients.Text = "";
            textInstructions.Text = "";
        }

        private void textRecipeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lstRecipes.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)lstRecipes.SelectedItem;
                selectedRecipe.RecipeName = textRecipeName.Text;
                UpdateRecipeList();
            }
        }


        private void ShowToast(string message)
        {
            // Replace this with your toast implementation
            MessageBox.Show(message, "Toast Notification", MessageBoxButton.OK);
        }
    }

    // Sample Recipe class, replace this with your actual Recipe class
    public class Recipe
    {
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
