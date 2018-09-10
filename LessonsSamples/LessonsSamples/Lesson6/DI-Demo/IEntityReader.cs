namespace LessonsSamples.Lesson6
{
    interface IEntityReader
    {
        IEntityFieldsReader<TEntity> BeginEntityRead<TEntity>();
    }
}