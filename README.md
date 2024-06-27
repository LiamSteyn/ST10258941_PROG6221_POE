# ST10258941_PROG6221

# Recipe Management Application

# Overview
This WPF application allows users to manage recipes by adding new recipes, displaying existing recipes, and performing various operations on them, such as scaling ingredients and resetting recipes.

# Features

Add Recipe: Users can add new recipes with a name, description, ingredients, and steps.
Display Recipes: Recipes are displayed alphabetically with their names and number of steps.
Tools Page: Provides functionalities to scale recipe ingredients, reset ingredients, and delete recipes.

# Updates from Console Application

Initial Features Developed in Console App:
Recipe CRUD Operations: Implemented basic functionality for adding, displaying, updating, and deleting recipes via console input/output.
Sorting and Filtering: Allowed sorting recipes alphabetically and displaying specific recipes based on user input.
Data Persistence: Used file handling (text files) to store recipe data persistently.

Transition to WPF Application:
Migration to WPF: Refactored the application to use WPF for a more interactive and visually appealing user interface.
MVVM Pattern Implementation: Adopted the MVVM (Model-View-ViewModel) architectural pattern for improved separation of concerns and testability.
Enhanced User Experience: Introduced features such as popup windows for recipe details, tools page for additional functionalities, and improved data binding for seamless UI updates.

# Technologies Used

C#: Backend logic and data management.
WPF (Windows Presentation Foundation): User interface design.
MVVM (Model-View-ViewModel): Architecture for separation of concerns.
LINQ: Sorting recipes alphabetically.
Visual Studio: IDE for development and debugging.

# Getting Started

Prerequisites:
Visual Studio (or any compatible IDE with WPF support)
.NET Framework

Installation:
Clone the repository:
https://github.com/LiamSteyn/ST10258941_PROG6221_POE

Open the solution in Visual Studio.

Build and run the application.

# Usage

Adding a Recipe:
Click on the "Add Recipe" button.
Fill in the details (name, description, ingredients, steps) in the popup window.
Click "Save" to add the recipe.

Displaying Recipes:
Click on the "Display Recipes" button.
Recipes are displayed in alphabetical order with their names.

Tools Page:
Click on the "Tools" button in the main window to access the tools page.
Scale ingredients: Adjust quantities of ingredients proportionally.
Reset ingredients: Reset ingredient quantities to default values.
Delete recipe: Remove a recipe from the list.

