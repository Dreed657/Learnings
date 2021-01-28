namespace AquaShop.Repositories.Models
{
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models = new List<IDecoration>();

        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)this.models;

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(d => d.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }
    }
}
