using LernASP.data.Interface;
using LernASP.data.Internal_models;
using Microsoft.EntityFrameworkCore;

namespace LernASP.data.Repository
{
    public class DetailRepository : IAllDetails
    {
        private readonly AppDBContent addDBContent;

        public DetailRepository(AppDBContent addDBContent)
        {
            this.addDBContent = addDBContent;
        }

        public IEnumerable<Detail> details => addDBContent.Details.Include(c => c.Category);

        public IEnumerable<Detail> getFavDetails => addDBContent.Details.Where(p => p.IsFavorite).Include(c => c.Category);

        public Detail getObjectDetail(int detailId) => addDBContent.Details.FirstOrDefault(p => p.Id == detailId);
    }
}
