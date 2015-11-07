namespace Snippy.Data.UnitOfWork
{
    using Snippy.Models;
    using Repositories;

    public interface ISnippyData
    {
        IRepository<Snippet> Snippets { get; }

        IRepository<ProgrammingLanguage> ProgrammingLanguages { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Label> Labels { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
