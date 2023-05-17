using Microsoft.AspNetCore.Mvc.RazorPages;
using Szilveszter_Levente_Artwork.Data;


namespace Szilveszter_Levente_Artwork.Models
{
    public class ArtworkCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData>? AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Szilveszter_Levente_ArtworkContext context, Artwork artwork)
        {
            var allCategories = context.Category;
            var artworkCategories = new HashSet<int>(
            artwork.ArtworkCategories?.Select(c => c.CategoryID) ?? Enumerable.Empty<int>());
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = artworkCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateArtworkCategories(Szilveszter_Levente_ArtworkContext context,
        string[] selectedCategories, Artwork artworkToUpdate)
        {
            if (selectedCategories == null)
            {
                artworkToUpdate.ArtworkCategories = new List<ArtworkCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var artworkCategories = new HashSet<int>(artworkToUpdate.ArtworkCategories?.Select(c => c.Category.ID) ?? Enumerable.Empty<int>());
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!artworkCategories.Contains(cat.ID))
                    {
                        artworkToUpdate?.ArtworkCategories?.Add(
                            new ArtworkCategory
                            {
                                ArtworkID = artworkToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (artworkCategories.Contains(cat.ID))
                    {
                        ArtworkCategory? courseToRemove
                            = artworkToUpdate?
                                .ArtworkCategories?
                                .SingleOrDefault(i => i.CategoryID == cat.ID);

                        if (courseToRemove != null)
                        {
                            context.Remove(courseToRemove);
                        }
                    }
                }
            }
        }

    }
}
