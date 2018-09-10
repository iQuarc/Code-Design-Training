using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    internal interface IEntityFieldsReader<T>
    {
        IEnumerable<string> GetFields();
        void StoreFieldValue(string value);

        T GetEntity();
    }
}