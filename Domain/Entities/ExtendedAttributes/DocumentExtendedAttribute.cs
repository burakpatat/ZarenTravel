using WordyWellHero.Domain.Contracts;
using WordyWellHero.Domain.Entities.Misc;

namespace WordyWellHero.Domain.Entities.ExtendedAttributes
{
    public class DocumentExtendedAttribute : AuditableEntityExtendedAttribute<int, int, Document>
    {
    }
    public class AccountBlockedPostsExtendedAttribute : AuditableEntityExtendedAttribute<long, long, AccountBlockedPosts>
    {
    }



}

