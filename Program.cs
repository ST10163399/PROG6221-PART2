using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class Step
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<Step> steps;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
        }

        //This method is for when you want to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the name of the recipe: ");
            Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Ingredient ingredient = new Ingredient();

                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();

                Console.Write("Quantity: ");
                ingredient.Quantity = Convert.ToDouble(Console.ReadLine());

                Console.Write("Unit: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write("Calories: ");
                ingredient.Calories = Convert.ToInt32(Console.ReadLine());

                Console.Write("Food Group: ");
                ingredient.FoodGroup = Console.ReadLine();

                ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter description for step #{i + 1}: ");
                Step step = new Step();
                step.Description = Console.ReadLine();

                steps.Add(step);
            }
        }

        //This method is for when you want to display the recipes
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step #{i + 1}: {steps[i].Description}");
            }
        }

        //This method is to calculate total calories of the recepies and to also warn you if calories are above 300
        public int CalculateTotalCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            return totalCalories;
        }
    }
    //This is where I wrote the basic funtions of the App
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("\n===== Recipe App =====");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Choose Recipe to Display");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Recipe recipe = new Recipe();
                        recipe.EnterRecipeDetails();
                        recipes.Add(recipe);
                        break;
                    case 2:
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes found.");
                        }
                        else
                        {
                            Console.WriteLine("All Recipes:");
                            foreach (Recipe r in recipes.OrderBy(r => r.Name))
                            {
                                Console.WriteLine(r.Name);
                            }
                        }
                        break;
                    case 3:
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("No recipes found.");
                        }
                        else
                        {
                            Console.Write("Enter the name of the recipe: ");
                            string recipeName = Console.ReadLine();
                            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                            if (selectedRecipe == null)
                            {
                                Console.WriteLine("Recipe not found.");
                            }
                            else
                            {
                                selectedRecipe.DisplayRecipe();
                                int totalCalories = selectedRecipe.CalculateTotalCalories();
                                Console.WriteLine($"\nTotal Calories: {totalCalories}");

                                if (totalCalories > 300)
                                {
                                    Console.WriteLine("Warning: This recipe exceeds 300 calories.");
                                }
                            }
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}