using System;

namespace LessonsSamples.Lesson6.NetCore
{
    class EntityReader : IEntityReader
    {
        private readonly IServiceProvider serviceLocator;

        public EntityReader(IServiceProvider serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public IEntityFieldsReader<TEntity> BeginEntityRead<TEntity>()
        {
            return (IEntityFieldsReader<TEntity>)serviceLocator.GetService(typeof(IEntityFieldsReader<TEntity>));
        }
    }
}