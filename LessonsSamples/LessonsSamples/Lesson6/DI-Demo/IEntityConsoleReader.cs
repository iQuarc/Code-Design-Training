namespace LessonsSamples.Lesson6
{
    interface IEntityConsoleReader
    {
        IEntityFieldsReader<T> BeginEntityRead<T>();
    }
}