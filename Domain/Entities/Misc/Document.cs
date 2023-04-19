using System;
using WordyWellHero.Domain.Contracts;
using WordyWellHero.Domain.Entities.ExtendedAttributes;

namespace WordyWellHero.Domain.Entities.Misc
{
    public class Document : AuditableEntityWithExtendedAttributes<int, int, Document, DocumentExtendedAttribute>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; } = false;
        public string URL { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }

    public class AccountBlockedPosts : AuditableEntityWithExtendedAttributes<long, long, AccountBlockedPosts, AccountBlockedPostsExtendedAttribute>
    {

        public long PostId { get; set; }
        public long AccountId { get; set; }
        public bool? IsBlockedAllready { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? AuthorId { get; set; }
    }
}