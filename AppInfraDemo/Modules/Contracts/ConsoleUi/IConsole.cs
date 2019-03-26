using System;

namespace Contracts.ConsoleUi
{
    public interface IConsole
	{
		string AskInput(string message);
	    string ReadLine();
	    ConsoleKeyInfo ReadKey();
	    void WriteEntity<T>(T entity);
	    void WriteLine(string line);
	    void Clear();
	}
}