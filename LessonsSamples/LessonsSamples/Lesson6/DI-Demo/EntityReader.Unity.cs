using System;
using CommonServiceLocator;

namespace LessonsSamples.Lesson6.Unity
{
    class EntityReader : IEntityReader
    {
        private readonly IServiceLocator serviceLocator;

        public EntityReader(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public IEntityFieldsReader<TEntity> BeginEntityRead<TEntity>()
        {
            return (IEntityFieldsReader<TEntity>)serviceLocator.GetService(typeof(IEntityFieldsReader<TEntity>));
        }
    }
}