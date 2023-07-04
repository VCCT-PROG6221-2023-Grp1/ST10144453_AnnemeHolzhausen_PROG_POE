//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anneme_Holzhausen_ST10144453_Prog_POE.MVM.Model
{
    internal class RecipeManager
    {
        private static List<RecipeClass> recipeList;

        public static List<RecipeClass> RecipeList
        {
            get
            {
                if (recipeList == null)
                    recipeList = new List<RecipeClass>();

                return recipeList;
            }
        }

        public static void AddRecipe(RecipeClass recipe)
        {
            RecipeList.Add(recipe);
        }

        public static void RemoveRecipe(RecipeClass recipe)
        {
            RecipeList.Remove(recipe);
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//