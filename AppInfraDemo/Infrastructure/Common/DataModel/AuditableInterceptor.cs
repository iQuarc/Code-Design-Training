using System;
using Common.DataModel.Abstractions;
using iQuarc.AppBoot;
using iQuarc.DataAccess;

namespace Common.DataModel
{
    [Service(nameof(AuditableInterceptor), typeof(IEntityInterceptor))]
    sealed class AuditableInterceptor : GlobalEntityInterceptor<IAuditable>
    {
        public override void OnSave(IEntityEntry<IAuditable> entry, IUnitOfWork repository)
        {
            var systemDate = DateTime.Now;
            entry.Entity.ModifiedDate = systemDate;
        }

        public override void OnLoad(IEntityEntry<IAuditable> entry, IRepository repository)
        {
        }

        public override void OnDelete(IEntityEntry<IAuditable> entry, IUnitOfWork repository)
        {
        }
    }
}
