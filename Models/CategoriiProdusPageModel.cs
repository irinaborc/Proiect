using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;

namespace Proiect.Models
{
    public class CategoriiProdusPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectContext context,
        Produs produs)
        {
            var allCategories = context.Categorie;
            var produsCategorii = new HashSet<int>(
            produs.CategoriiProdus.Select(c => c.ProdusID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribuit = produsCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiProdus(ProiectContext context,
        string[] selectedCategories, Produs produsToUpdate)
        {
            if (selectedCategories == null)
            {
                produsToUpdate.CategoriiProdus = new List<CategorieProdus>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var produsCategorii = new HashSet<int>
            (produsToUpdate.CategoriiProdus.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategorii.Contains(cat.ID))
                    {
                        produsToUpdate.CategoriiProdus.Add(
                        new CategorieProdus
                        {
                            ProdusID = produsToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (produsCategorii.Contains(cat.ID))
                    {
                        CategorieProdus courseToRemove
                        = produsToUpdate
                        .CategoriiProdus
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    
    }
}
