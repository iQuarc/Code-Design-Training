using System;

namespace LessonsSamples.Lesson6
{
    public interface ICommand
    {
        void Execute();
        char KeyChar { get; }
        string MenuEntry { get; }
    }
}